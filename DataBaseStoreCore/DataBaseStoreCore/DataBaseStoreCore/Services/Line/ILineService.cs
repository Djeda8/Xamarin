using System.Collections.Generic;
using DataBaseStoreCore.Models;

namespace DataBaseStoreCore.Services.Line
{
    public interface ILineService
    {
        void DeleteAll();
        IList<Models.Line> getAll();
        void Insert(Models.Line line);
        void Remove(Models.Line line);
    }
}