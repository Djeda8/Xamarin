using System;
using System.IO;
using PreferencesService.Droid.Services.Sqlite;
using PreferencesService.Services.Sqlite;
using Xamarin.Forms;

[assembly: Dependency(typeof(PathService))]
namespace PreferencesService.Droid.Services.Sqlite
{
    public class PathService : IPathService
    {
        public string GetDatabasePath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, AppSettings.DatabaseName);
        }
    }
}