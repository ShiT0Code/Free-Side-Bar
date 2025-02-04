﻿using System;

namespace Quick_Launch_Bar
{
    class SettingsManager
    {
        Windows.Storage.ApplicationDataContainer localSettings =
            Windows.Storage.ApplicationData.Current.LocalSettings;

        Windows.Storage.StorageFolder localFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;

        Windows.Storage.ApplicationDataCompositeValue composite =
            new Windows.Storage.ApplicationDataCompositeValue();


        public bool SaveBoolSetting(string name, bool value)
        {
            localSettings.Values[name] = value;

            return true;
        }

        public bool CheckBoolSetting(string name)
        {
            Object value = localSettings.Values[name];

            if (value == null)
                return false;

            bool result = (bool)value;

            return result;
        }
    }
}
