// Copyright (c) Jon Thysell <http://jonthysell.com>
// Licensed under the MIT License.

// Adapted from MusicBee API sample https://getmusicbee.com/help/api/

using System;

using AnyAscii;

namespace MusicBeePlugin
{
    public partial class Plugin
    {
        private MusicBeeApiInterface? _MusicBeeApiInterface = null;
        private PluginInfo _PluginInfo = null;

        public PluginInfo Initialise(IntPtr apiInterfacePtr)
        {
            if (_MusicBeeApiInterface is null)
            {
                _MusicBeeApiInterface = new MusicBeeApiInterface();
                _MusicBeeApiInterface?.Initialise(apiInterfacePtr);
            }

            if (_PluginInfo is null)
            {
                _PluginInfo = new PluginInfo();
                _PluginInfo.PluginInfoVersion = PluginInfoVersion;
                _PluginInfo.Name = "ASCII Tools";
                _PluginInfo.Description = "Provides tools for converting text to ASCII.";
                _PluginInfo.Author = "Jon Thysell";
                _PluginInfo.Type = PluginType.General;
                _PluginInfo.VersionMajor = 1;
                _PluginInfo.VersionMinor = 0;
                _PluginInfo.Revision = 0;
                _PluginInfo.MinInterfaceVersion = MinInterfaceVersion;
                _PluginInfo.MinApiRevision = MinApiRevision;
                _PluginInfo.ConfigurationPanelHeight = 0;
            }

            return _PluginInfo;
        }

        public string CustomFunc_TransliterateToAscii(string input)
        {
            return input.Transliterate();
        }

        public bool Configure(IntPtr panelHandle) => false;

        public void SaveSettings() { }

        public void Close(PluginCloseReason reason) { }

        public void Uninstall() { }

        public void ReceiveNotification(string sourceFileUrl, NotificationType type) { }
    }
}