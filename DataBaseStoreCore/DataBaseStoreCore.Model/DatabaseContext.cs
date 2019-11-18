using DataBaseStoreCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseStoreCore.Model
{
    public class DatabaseContext : DbContext
    {
        private string _dbPath;

        public DbSet<Line> Lines { get; set; }

        public DatabaseContext()
        {

        }

        public DatabaseContext(string dbPath)
        {
            this._dbPath = dbPath;
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }
    }

}
