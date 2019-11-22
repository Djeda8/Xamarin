using EnglishApp.dou.com.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EnglishApp.dou.com.Services.DataStore
{
    public class DataStoreService : IDataStoreService
    {
        protected HttpClient _client;

        public IList<Word> words;

        public DataStoreService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _client.MaxResponseContentBufferSize = 256000;
        }
        
        public async Task ReadWords()
        {
            var uri = new Uri($"{GlobalSettings.UrlServices}words");

            try
            {
                var response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var returnMessage = await response.Content.ReadAsStringAsync();
                    words = JsonConvert.DeserializeObject<IList<Word>>(returnMessage);
                }
                else
                {
                    var returnMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception("Usuario y/o contraseña incorrectos");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message != null && ex.Message.Contains("Unable to resolve host"))
                    throw new Exception("No hay conexión con el servidor");
                else
                    throw new Exception(ex.Message);
            }
        }

        public IList<Word> GetWords()
        {
            return words;
        }
    }
}
