using DataBaseStoreCore.Model;
using DataBaseStoreCore.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DataBaseStoreCore.Services.Line
{
    public class LineService : ILineService
    {
        private DatabaseContext _context;

        public LineService()
        {
            var path = DependencyService.Get<IDatabaseService>().GetDatabasePath();

            _context = new DatabaseContext(path);
        }

        public IList<Models.Line> getAll()
        {
            return _context.Lines.ToList();
        }

        public void Insert(Models.Line line)
        {
            try
            {
                _context.Lines.Add(line);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Remove(Models.Line line)
        {
            _context.Lines.Remove(line);

            _context.SaveChanges();
        }

        public void DeleteAll()
        {
            var q = _context.Lines.ToList();

            foreach (Models.Line line in q)
            {
                _context.Lines.Remove(line);
            }
            _context.SaveChanges();
        }
    }
}
