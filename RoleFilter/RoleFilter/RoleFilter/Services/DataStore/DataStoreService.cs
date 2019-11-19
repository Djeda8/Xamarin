using RoleFilter.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoleFilter.Services.DataStore
{
    public class DataStoreService : IDataStoreService
    {
        public IList<Item> mockItems;

        public DataStoreService()
        {
            mockItems = new List<Item>()
            {
                new Item { Text = "First item", Role = "Admin" },
                new Item { Text = "Second item", Role="Admin" },
                new Item { Text = "Third item", Role="Editor" },
                new Item { Text = "Fourth item", Role="Editor" },
                new Item { Text = "Fifth item",  Role="Student" },
                new Item { Text = "Sixth item",  Role="Student" },
            };

        }
        public async Task<IList<Item>> GetItemsAsync()
        {
            return mockItems;
        }
    }
}
