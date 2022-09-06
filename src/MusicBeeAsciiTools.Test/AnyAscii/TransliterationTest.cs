// Adapted from AnyAscii
// https://raw.githubusercontent.com/anyascii/anyascii/0.3.1/impl/csharp/test/TransliterationTest.cs

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnyAscii.Test
{
	[TestClass]
	public class TransliterationTest
	{
		[TestMethod]
		public void Test()
		{
			Check("", "");
			Check("\u0000\u0001\t\n\u001f ~\u007f", "\u0000\u0001\t\n\u001f ~\u007f");
			Check("sample", "sample");

			Check(0x0080, "");
			Check(0x00ff, "y");
			Check(0xe000, "");
			Check(0xffff, "");
			Check(0x000e0020, " ");
			Check(0x000e007e, "~");
			Check(0x000f0000, "");
			Check(0x000f0001, "");
			Check(0x0010ffff, "");

			Check("René François Lacôte", "Rene Francois Lacote");
			Check("Blöße", "Blosse");
			Check("Trần Hưng Đạo", "Tran Hung Dao");
			Check("Nærøy", "Naeroy");
			Check("Φειδιππίδης", "Feidippidis");
			Check("Δημήτρης Φωτόπουλος", "Dimitris Fotopoylos");
			Check("Борис Николаевич Ельцин", "Boris Nikolaevich El'tsin");
			Check("Володимир Горбулін", "Volodimir Gorbulin");
			Check("Търговище", "T'rgovishche");
			Check("深圳", "ShenZhen");
			Check("深水埗", "ShenShuiBu");
			Check("화성시", "HwaSeongSi");
			Check("華城市", "HuaChengShi");
			Check("さいたま", "saitama");
			Check("埼玉県", "QiYuXian");
			Check("ደብረ ዘይት", "debre zeyt");
			Check("ደቀምሓረ", "dek'emhare");
			Check("دمنهور", "dmnhwr");
			Check("Աբովյան", "Abovyan");
			Check("სამტრედია", "samt'redia");
			Check("אברהם הלוי פרנקל", "'vrhm hlvy frnkl");
			Check("⠠⠎⠁⠽⠀⠭⠀⠁⠛", "+say x ag");
			Check("ময়মনসিংহ", "mymnsimh");
			Check("ထန်တလန်", "thntln");
			Check("પોરબંદર", "porbmdr");
			Check("महासमुंद", "mhasmumd");
			Check("ಬೆಂಗಳೂರು", "bemgluru");
			Check("សៀមរាប", "siemrab");
			Check("ສະຫວັນນະເຂດ", "sahvannaekhd");
			Check("കളമശ്ശേരി", "klmsseri");
			Check("ଗଜପତି", "gjpti");
			Check("ਜਲੰਧਰ", "jlmdhr");
			Check("රත්නපුර", "rtnpur");
			Check("கன்னியாகுமரி", "knniyakumri");
			Check("శ్రీకాకుళం", "srikakulm");
			Check("สงขลา", "sngkhla");
			Check("👑 🌴", ":crown: :palm_tree:");
			Check("☆ ♯ ♰ ⚄ ⛌", "* # + 5 X");
			Check("№ ℳ ⅋ ⅍", "No M & A/S");

			Check("トヨタ", "toyota");
			Check("ߞߐߣߊߞߙߌ߫", "konakri");
			Check("𐬰𐬀𐬭𐬀𐬚𐬎𐬱𐬙𐬭𐬀", "zarathushtra");
			Check("ⵜⵉⴼⵉⵏⴰⵖ", "tifinagh");
			Check("𐍅𐌿𐌻𐍆𐌹𐌻𐌰", "wulfila");
			Check("ދިވެހި", "dhivehi");
			Check("ᨅᨔ ᨕᨘᨁᨗ", "bs ugi");
			Check("ϯⲙⲓⲛϩⲱⲣ", "timinhor");
			Check("𐐜 𐐢𐐮𐐻𐑊 𐐝𐐻𐐪𐑉", "Dh Litl Star");
			Check("ꁌꐭꑤ", "pujjytxiep");
			Check("ⰳⰾⰰⰳⱁⰾⰹⱌⰰ", "glagolica");
			Check("ᏎᏉᏯ", "SeQuoYa");
			Check("ㄓㄨㄤ ㄅㄥ ㄒㄧㄠ", "zhuang beng xiao");
			Check("ꚩꚫꛑꚩꚳ ꚳ꛰ꛀꚧꚩꛂ", "ipareim m'shuoiya");
			Check("ᓀᐦᐃᔭᐍᐏᐣ", "nehiyawewin");
			Check("ᠤᠯᠠᠭᠠᠨᠴᠠᠪ", "ulaganqab");
		}

		static void Check(string s, string expected)
		{
			Assert.AreEqual(s.IsAscii(), s.Equals(expected));
			Assert.IsTrue(expected.IsAscii());
			Assert.AreEqual(expected, s.Transliterate());
		}

		static void Check(int utf32, string expected)
		{
			Assert.IsTrue(expected.IsAscii());
			Assert.AreEqual(expected, Transliteration.Transliterate(utf32));
		}
	}
}
