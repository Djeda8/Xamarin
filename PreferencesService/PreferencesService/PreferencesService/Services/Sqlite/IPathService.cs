using System;
using System.Collections.Generic;
using System.Text;

namespace PreferencesService.Services.Sqlite
{
    public interface IPathService
    {
        string GetDatabasePath();
    }
}
