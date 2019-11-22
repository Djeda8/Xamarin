using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishWebAPI.Models
{
    public class Word
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string EN_Word { get; set; }
        public string EN_definition { get; set; }
        public string SP_Word { get; set; }
        public string SP_Definition { get; set; }
    }
}