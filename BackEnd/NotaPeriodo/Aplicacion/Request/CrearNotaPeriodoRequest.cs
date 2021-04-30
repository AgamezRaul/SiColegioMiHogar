using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.NotaPeriodo.Aplicacion.Request
{
    public class CrearNotaPeriodoRequest
    {
        public int id { get; set; }
        public double nota { get; set; }
        public string observacion { get; set; }
        public int idPeriodo { get; set; }
        public int idMateria { get; set; }
    }
    public class CrearNotaPeriodoResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Curso Creado Exitosamente");
        }
    }
}
