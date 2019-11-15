using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Login.Services.Login
{
    public class LoginService : ILoginService
    {
        protected HttpClient _client;

        public LoginService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<Models.Login> Login(string idUsuario, string password)
        {
            Models.Login _login = new Models.Login();
            _login.password = password;

            if (idUsuario.Contains("@"))
            {
                _login.email = idUsuario;
            }
            else
            {
                _login.idUsuario = idUsuario;
            }

            var uri = new Uri($"{GlobalSettings.UrlServices}login/v1/loginusuario");

            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(_login), Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var returnMessage = await response.Content.ReadAsStringAsync();
                    _login = JsonConvert.DeserializeObject<Models.Login>(returnMessage);
                    _login.idUsuario = _login.idUsuario.Trim();
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

            return _login;
        }
    }
}
