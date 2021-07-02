using BackEnd.Base;
using System.Collections.Generic;

namespace BackEnd.Docente.Dominio
{
    public class Docente : Entity<int>
    {

        public string NombreCompleto { get; set; }
        public string NumTarjetaProf { get; set; }
        public string Cedula { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }

        public Docente(string nombreCompleto, string numTarjetaProf, string cedula, string celular, string correo, string direccion, string estado)
        {
            NombreCompleto = nombreCompleto;
            NumTarjetaProf = numTarjetaProf;
            Cedula = cedula;
            Celular = celular;
            Correo = correo;
            Direccion = direccion;
            Estado = estado;
        }

        public IReadOnlyList<string> CanCrear(Docente docente)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(docente.NombreCompleto))
                errors.Add("El campo nombre está vacío");
            if (string.IsNullOrEmpty(docente.NumTarjetaProf))
                errors.Add("El campo número de tarjeta profesional está vacío");
            if (string.IsNullOrEmpty(docente.Cedula))
                errors.Add("El campo nombre está vacío");
            if (string.IsNullOrEmpty(docente.Celular))
                errors.Add("El campo celular está vacío");
            if (string.IsNullOrEmpty(docente.Correo))
                errors.Add("El campo correo está vacío");
            if (string.IsNullOrEmpty(docente.Direccion))
                errors.Add("El campo correo está vacío");
            return errors;
        }


    }
}
