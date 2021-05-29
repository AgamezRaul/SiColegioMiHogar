using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Boletin.Aplicacion.Request
{
    public class CrearBoletinRequest
    {
        public int id { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public int IdEstudiante { get; set; }
        public int IdPeriodo { get; set; }

    }
    public class CrearBoletinResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Boletin Creado Exitosamente");
        }
    }
}
