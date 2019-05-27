using SQLite;

namespace PreferencesService.Models
{
    public class PreferencesDataObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Contador { get; set; }
        public int TerminalNum { get; set; }
        public string URI { get; set; }
    }
}
