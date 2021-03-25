using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.RelacionUR.Aplicacion.Request
{
   public class CrearRelacionURRequest
    {
        public int id { get; set; }
        public int IdResponsable { get; set; }
        public int IdUsuario { get; set; }
    }
    public class CrearRelacionURResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Relacion Usuario Responsable Creada Exitosamente");
        }
    }
}
