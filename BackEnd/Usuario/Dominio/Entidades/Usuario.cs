using BackEnd.Base;
using BackEnd.Usuario.Dominio.Entidades;
using System.Collections.Generic;

namespace BackEnd.Usuario.Dominio
{
    public class Usuario : Entity<int>
    {
        public string Correo { get; set; }
        public string Password { get; set; }
        public string TipoUsuario { get; set; }

        private const string SharedSecret = "MiHogarPass123";
        public Crypto Crypto;

        public Usuario() { }
        public Usuario(string correo, string password, string tipoUsuario)
        {
            Correo = correo;
            Crypto = new Crypto();
            if (!string.IsNullOrEmpty(password) && (password.Length >= 5))
            {
                Password = Encriptar(password);
            }
            else
            {
                Password = password;
            }
            TipoUsuario = tipoUsuario;
        }
        public Usuario(string correo, string password)
        {
            Correo = correo;
            Crypto = new Crypto();
            if (!string.IsNullOrEmpty(password) && !(password.Length < 6))
            {
                this.Password = Encriptar(password);
            }
            else
            {
                this.Password = password;
            }
        }
        public IReadOnlyList<string> CanCrear(Usuario usuario)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(usuario.Correo))
                errors.Add("Campo Correo vacio");
            if (string.IsNullOrEmpty(usuario.Password))
                errors.Add("Campo Contraseña vacio");
            if (string.IsNullOrEmpty(usuario.TipoUsuario))
                errors.Add("Campo Tipo de usuario vacio");
            return errors;
        }
        public string Encriptar(string password)
        {
            string outPass = Crypto.EncryptStringAES(password, SharedSecret);
            return outPass;
        }
        public string Desencriptar(string password)
        {
            string outPass = Crypto.DecryptStringAES(password, SharedSecret);
            return outPass;
        }

    }
}
