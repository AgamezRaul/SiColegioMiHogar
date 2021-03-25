﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Usuario.Aplicacion.Request
{
   public class ActualizarUsuarioRequest
    {
        public int id { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string NomUsuario { get; set; }
        public string TipoUsuario { get; set; }
    }
    public class ActualizarUsuarioResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Usuario Actualizado Exitosamente");
        }
    }
}