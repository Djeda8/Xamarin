using CrudOperations.Helper;
using CrudOperations.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrudOperations.Services.Sqlite
{
    class SqliteService : ISqliteService
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
            await _sqlCon.CreateTableAsync<User>().ConfigureAwait(false);
        }

        public async Task DeleteUser(User user)
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                await _sqlCon.DeleteAsync(user);
            }
        }

        public async Task<User> GetUser(string name)
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                var existingUser = await _sqlCon.Table<User>()
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync();

                if (existingUser == null)
                {
                    return null;
                }
                else
                {
                    return existingUser;
                }
            }
        }

        public async Task Insert(User user)
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                var existingUser = await _sqlCon.Table<User>()
                .Where(x => x.Id == user.Id)
                .FirstOrDefaultAsync();

                if (existingUser == null)
                {
                    await _sqlCon.InsertAsync(user).ConfigureAwait(false);
                }
                else
                {
                    await _sqlCon.UpdateAsync(user).ConfigureAwait(false);
                }
            }
        }
    }
}
