using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Usuario.Aplicacion.Request
{
    public class LoginRequest
    {
        public string Correo { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public string TipoUsuario { get; set; }


        public bool isOk()
        {
            return this.Message.Equals("Usuario y Contraseña Correctos");
        }
    }
}
