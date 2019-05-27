using PreferencesService.Models;
using PreferencesService.Services.Sqlite;
using System.Threading.Tasks;

namespace PreferencesService.Services.Preferences
{
    class PreferencesService : IPreferencesService
    {
        protected readonly ISqliteService _sqliteService;

        public PreferencesService(ISqliteService sqliteService)
        {
            _sqliteService = sqliteService;
        }

        //Obtiene el objeto de configuracion (1)
        public async Task<PreferencesDataObject> GetPreferencesDataObject()
        {
            PreferencesDataObject preferencesDataObject = await _sqliteService.GetPreferencesDataObject();
            return preferencesDataObject;
        }

        // Crea un nuevo objeto de configuracion (2)
        public async Task NewPreferencesDataObject()
        {
            PreferencesDataObject preferencesDataObject = new PreferencesDataObject
            {
                Contador = AppSettings.Contador,
                TerminalNum = AppSettings.TerminalNum,
                URI = AppSettings.URI
            };
            await _sqliteService.InsertPreferencesDataObject(preferencesDataObject);
        }

        // Obtiene datos de configuracion (3)
        public async Task GetPreferencesData()
        {
            PreferencesDataObject preferencesDataObject = await GetPreferencesDataObject();

            AppSettings.Contador = preferencesDataObject.Contador;
            AppSettings.TerminalNum = preferencesDataObject.TerminalNum;
            AppSettings.URI = preferencesDataObject.URI;
        }

        // Establece los datos de configuracion (4)
        public async Task SetConfigData()
        {
            PreferencesDataObject preferencesDataObject = await GetPreferencesDataObject();
            preferencesDataObject.Contador = AppSettings.Contador;
            preferencesDataObject.TerminalNum = AppSettings.TerminalNum;
            preferencesDataObject.URI = AppSettings.URI;
            await _sqliteService.InsertPreferencesDataObject(preferencesDataObject);
        }
    }
}
