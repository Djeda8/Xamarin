using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace MultilingualApp
{
    class AppSettings
    {
        public static string LanguageSettingsDefecto = "es-ES";

        public static string LanguageSettings
        {
            get { return Preferences.Get("LanguageSettings", AppSettings.LanguageSettingsDefecto); }
        }
    }
}
