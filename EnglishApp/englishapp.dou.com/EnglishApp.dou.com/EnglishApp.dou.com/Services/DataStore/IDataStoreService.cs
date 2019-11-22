using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishApp.dou.com.Models;

namespace EnglishApp.dou.com.Services.DataStore
{
    public interface IDataStoreService
    {
        IList<Word> GetWords();
        Task ReadWords();
    }
}