using Android;
using DataBaseStoreCore.Droid.Services.Database;
using DataBaseStoreCore.Services.Database;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]
namespace DataBaseStoreCore.Droid.Services.Database
{
    public class DatabaseService : IDatabaseService
    {
        readonly string[] PermissionsLocation =
        {
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.ReadExternalStorage
        };

        const int RequestLocationId = 0;

        public string GetDatabasePath()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                GlobalSettings.DatabaseName);
        }

        public void CopyBDToSD()
        {
            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), GlobalSettings.DatabaseName);

            System.IO.File.Copy(path, System.IO.Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath, GlobalSettings.DatabaseName), true);
        }
    }
}