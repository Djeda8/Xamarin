using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishWebAPI.Models;

namespace EnglishWebAPI.Services
{
    public interface IReadWordsService
    {
        Task<IList<Word>> ReadWords();
    }
}