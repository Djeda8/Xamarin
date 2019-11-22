using MyWebApi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebApi2.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public IHttpActionResult loginusuario(Login login)
        {
            if (login.idUsuario.Equals("daniel") && login.password.Equals("12345"))
            {
                login.nombreUsuario = "Daniel Ojeda";
                return Ok(login);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
