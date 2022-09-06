// Copyright (c) 2020-2022, Hunter WB <hunterwb.com>
// Licensed under the ISC License.

// Adapted from AnyAscii's C# implementation.
// Original at https://github.com/anyascii/anyascii/blob/0.3.1/impl/csharp/src/Transliteration.cs
//         and https://github.com/anyascii/anyascii/blob/0.2.0/csharp/src/Transliteration.cs

using System.Text;

namespace AnyAscii
{
    public static partial class Transliteration
    {
        public static string Transliterate(this string s)
        {
            if (s.IsAscii())
            {
                return s;
            }

            StringBuilder sb = new StringBuilder(s.Length);
            Transliterate(s, sb);
            return sb.ToString();
        }

        public static void Transliterate(this string s, StringBuilder dst)
        {
            for (int i = 0; i < s.Length; i++)
            {
                int utf32 = char.ConvertToUtf32(s, i);
                if (utf32 > 0xffff) i++;
                Transliterate(utf32, dst);
            }
        }

        public static void Transliterate(int utf32, StringBuilder dst)
        {
            if (IsAscii(utf32))
            {
                dst.Append((char)utf32);
            }
            else
            {
                dst.Append(Transliterate(utf32));
            }
        }

        public static string Transliterate(int utf32)
        {
            uint blockNum = (uint)utf32 >> 8;
            var block = Block(blockNum);
            int lo = 3 * (utf32 & 0xff);
            if (block.Length <= lo) return string.Empty;

            uint l = block[lo + 2];
            int len = (int)((l & 0x80) != 0 ? l & 0x7f : 3);
            if (len <= 3)
            {
                return Encoding.ASCII.GetString(block, lo, len);
            }
            else
            {
                int i = (block[lo] << 8) | block[lo + 1];
                return Encoding.ASCII.GetString(Bank, i, len);
            }
        }

        public static bool IsAscii(this string s)
        {
            foreach (char c in s)
            {
                if (!c.IsAscii())
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsAscii(this char c)
        {
            return (c >> 7) == 0;
        }

        public static bool IsAscii(int utf32)
        {
            return (utf32 >> 7) == 0;
        }
    }
}
