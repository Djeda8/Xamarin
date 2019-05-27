using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PreferencesService.Helpers;
using PreferencesService.Models;
using SQLite;
using Xamarin.Forms;

namespace PreferencesService.Services.Sqlite
{
    public class SqliteService : ISqliteService
    {
        private static readonly AsyncLock Mutex = new AsyncLock();
        private SQLiteAsyncConnection _sqlCon;
        public SqliteService()
        {
            var databasePath = DependencyService.Get<IPathService>().GetDatabasePath();
            _sqlCon = new SQLiteAsyncConnection(databasePath);

            CreateDatabaseAsync();
        }
        public async void CreateDatabaseAsync()
        {
            await _sqlCon.CreateTableAsync<PreferencesDataObject>().ConfigureAwait(false);
        }

        // Obtiene el objeto de configuracion (1)
        public async Task<PreferencesDataObject> GetPreferencesDataObject()
        {
            PreferencesDataObject item;
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                item = await _sqlCon.Table<PreferencesDataObject>()
                .FirstOrDefaultAsync();
            }
            return item;
        }

        // Inserta/actualiza un objeto de configuracion (2)
        public async Task InsertPreferencesDataObject(PreferencesDataObject preferencesDataObject)
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                var item = await _sqlCon.Table<PreferencesDataObject>()
                            .Where(c => c.Id == preferencesDataObject.Id)
                            .FirstOrDefaultAsync();
                if (item == null)
                {
                    await _sqlCon.InsertAsync(preferencesDataObject).ConfigureAwait(false);
                }
                else
                {
                    await _sqlCon.UpdateAsync(preferencesDataObject).ConfigureAwait(false);
                }
            }
        }
    }
}
