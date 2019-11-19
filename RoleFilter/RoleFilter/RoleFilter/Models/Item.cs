using System;
using System.Collections.Generic;
using System.Text;

namespace RoleFilter.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get => ($"{Text} - {Role}"); }

        public string Role { get; set; }
    }
}
