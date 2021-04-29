using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.UsarioDocente.Dominio
{
   public class UsuarioDocente : Entity<int>
    {
       

        public int IdDocente { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        
        public string TipoUsuario { get; set; }
        public UsuarioDocente() { }
        public UsuarioDocente(int idDocente, string correo, string password, string tipoUsuario)
        {
            IdDocente = idDocente;
            Correo = correo;
            Password = password;
            TipoUsuario = tipoUsuario;
        }
        public IReadOnlyList<string> CanCrear(UsuarioDocente usarioDocente)
        {
            var errors = new List<string>();

            if (usarioDocente.IdDocente == 0)
                errors.Add("Campo identifacion del docente vacio");
            if (string.IsNullOrEmpty(usarioDocente.Correo))
                errors.Add("Campo correo vacio");
            if (string.IsNullOrEmpty(usarioDocente.Password))
                errors.Add("Campo Contraseña vacio");
            return errors;
        }
    }
}
