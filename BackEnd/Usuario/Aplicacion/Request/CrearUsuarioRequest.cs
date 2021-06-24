using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Usuario.Aplicacion.Request
{
    public class CrearUsuarioRequest
    {
        public int id { get; set; }
        public string Correo { get; set; }
        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoNombre { get; set; }
        public string SegundoApellido { get; set; }
        public string Identificacion { get; set; }
        public string Password { get; set; }
        public string TipoUsuario { get; set; }
    }
    public class CrearUsuarioResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Usuario Creado Exitosamente");
        }
    }
}
