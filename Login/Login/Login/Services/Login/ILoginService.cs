using System.Threading.Tasks;
using Login.Models;

namespace Login.Services.Login
{
    public interface ILoginService
    {
        Task<Models.Login> Login(string idUsuario, string password);
    }
}