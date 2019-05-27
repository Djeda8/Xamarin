using PreferencesService.Models;
using System.Threading.Tasks;

namespace PreferencesService.Services.Sqlite
{
    public interface ISqliteService
    {
        // Obtiene el objeto de configuracion (1)
        Task<PreferencesDataObject> GetPreferencesDataObject();

        // Inserta/actualiza un objeto de configuracion (2)
        Task InsertPreferencesDataObject(PreferencesDataObject preferencesDataObject);
    }
}
