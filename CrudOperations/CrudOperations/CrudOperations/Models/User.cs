using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudOperations.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        //[Unique]
        public int  Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
