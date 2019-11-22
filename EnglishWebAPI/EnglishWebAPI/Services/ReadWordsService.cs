using EnglishWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EnglishWebAPI.Services
{
    public class ReadWordsService : IReadWordsService
    {
        public async Task<IList<Word>> ReadWords()
        {
            IList<Word> words = new List<Word>();

            int counter = 0;
            string line;
            Word word;
            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"c:\x\test.txt");
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                String[] campos = line.Split(';');

                word = new Word()
                {
                    EN_Word = campos[0],
                    SP_Word = campos[1],
                };

                words.Add(word);
                
                counter++;
            }
            file.Close();
            return words;
        }
    }
}   