using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApi2.Models
{
    public class Login
    {
        public string idUsuario { get; set; }
        public string password { get; set; }
        public string nombreUsuario { get; set; }

        public string email { get; set; }
    }
}