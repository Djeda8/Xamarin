using EnglishApp.dou.com.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishApp.dou.com.Services.DataStore
{
    public class DataStoreService
    {
        static IList<Word> words;

        public DataStoreService()
        {
            ReadWords();

        }

        private void ReadWords()
        {
            throw new NotImplementedException();
        }
    }
}
