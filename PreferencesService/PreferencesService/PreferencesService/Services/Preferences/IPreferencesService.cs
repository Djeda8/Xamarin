using PreferencesService.Models;
using System.Threading.Tasks;

namespace PreferencesService.Services.Preferences
{
    public interface IPreferencesService
    {
        // Obtiene el objeto de configuracion (1)
        Task<PreferencesDataObject> GetPreferencesDataObject();

        // Crea un nuevo objeto de configuracion (2)
        Task NewPreferencesDataObject();

        // Obtiene datos de configuracion (3)
        Task GetPreferencesData();

        // Establece los datos de configuracion (4)
        Task SetConfigData();
    }
}
