using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Usuario.Dominio
{
   public class Usuario : Entity<int>
    {
        public string Correo { get; set; }
        public string Password { get; set; }
        public string NomUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public Usuario(string correo, string password, string nomUsuario, string tipoUsuario)
        {
            Correo = correo;
            Password = password;
            NomUsuario = nomUsuario;
            TipoUsuario = tipoUsuario;
        }
        public IReadOnlyList<string> CanCrear(Usuario usuario)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(usuario.Correo))
                errors.Add("Campo Correo vacio");
            if (string.IsNullOrEmpty(usuario.Password))
                errors.Add("Campo Contraseña vacio");
            if (string.IsNullOrEmpty(usuario.NomUsuario))
                errors.Add("Campo Nombre de usuario vacio");
            if (string.IsNullOrEmpty(usuario.TipoUsuario))
                errors.Add("Campo Tipo de usuario vacio");
            return errors;
        }

    }
}
