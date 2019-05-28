using CrudOperations.Models;
using System.Threading.Tasks;

namespace CrudOperations.Services.Sqlite
{
    public interface ISqliteService
    {
        Task Insert(User user);
        Task<User> GetUser(string name);
        Task DeleteUser(User user);
    }
}
