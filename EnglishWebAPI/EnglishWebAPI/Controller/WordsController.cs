using EnglishWebAPI.Models;
using EnglishWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EnglishWebAPI.Controller
{
    public class WordsController : ApiController
    {
        public IList<Word> _words;
        protected IReadWordsService ReadWordsService;

        public WordsController()
        {
            ReadWordsService = new ReadWordsService();
        }

        public async Task<IList<Word>> Get()
        {
            //_words = new List<Word>()
            //{
            //    new Word(){ Id=1, EN_Word="Red",SP_Word="Rojo", }
            //};
            _words = await ReadWordsService.ReadWords();

            return _words;
        }
    }
}
