# ASCII Tools #

ASCII Tools is a plugin for [MusicBee](https://getmusicbee.com/) which provides functionality for converting text to ASCII.

It relies on [AnyAscii](https://github.com/anyascii/anyascii) to perform the transliteration of characters from Unicode to ASCII.

## Installation ##

1. Download the latest release zip file from https://github.com/jonthysell/MusicBeeAsciiTools/releases/latest
2. Extract the zip file
3. Make sure MusicBee is closed
4. Place the `mb_AsciiTools.dll` file into MusicBee's `Plugins` folder
5. Start MusicBee
6. Enable the plugin under `Preferences > Plugins`

## Usage ##

ASCII Tools provides a single custom function: TransliterateToAscii

This function will take any Unicode text passed to it and transliterate the text into ASCII characters. It can be used anywhere custom functions can be used, though its primary use is for (re)naming files when ripping CDs, syncing to devices, etc., where the target filesystem does not support Unicode filenames.

For example given a track with the following Unicode metadata:

* **Artist:** Israel Kamakawiwoʻole
* **Title:** Lā ʻElima

and setting the naming template to:

```
$TransliterateToAscii(<Artist>) - $TransliterateToAscii(<Title>)
```

you would get the ASCII filename:

```
Israel Kamakawiwo`ole - La `Elima.flac
```

**Note:** The function drops spaces between multiple tags. I.e. the template:

```
$TransliterateToAscii(<Artist> - <Title>)
```

will produce:

```
Israel Kamakawiwo`ole-La `Elima.flac
```

So it's best to wrap each tag you want to transliterate with its own call to the function.

## Errata ##

ASCII Tools is open-source under the MIT license.

Copyright (c) 2022 Jon Thysell

MusicBee Copyright (c) 2008-2022, Steven Mayall

AnyAscii Copyright (c) 2020-2022, Hunter WB <hunterwb.com>
