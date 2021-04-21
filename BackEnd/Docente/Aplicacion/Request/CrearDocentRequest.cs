using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Docente.Aplicacion.Request
{
    public class CrearDocenteRequest
    {
        public int id { get; set; }
        public string NombreCompleto { get; set; }
        public string NumTarjetaProf { get; set; }
        public string Cedula { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
    }
    public class CrearDocenteResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Docente Creado Exitosamente");
        }
    }

}
