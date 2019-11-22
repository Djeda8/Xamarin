using System.Collections.Generic;
using System.Threading.Tasks;
using RoleFilter.Models;

namespace RoleFilter.Services.DataStore
{
    public interface IDataStoreService
    {
        Task<IList<Item>> GetItemsAsync();
    }
}