using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Responsable.Aplicacion.Request
{
    public class ActualizarResponsableRequest
    {
        public int id { get; set; }
        public string IdeResponsable { get; set; }
        public string NomResponsable { get; set; }
        public DateTime FecNacimiento { get; set; }
        public string LugNacimiento { get; set; }
        public string LugExpedicion { get; set; }
        public string TipDocumento { get; set; }
        public int CelResponsable { get; set; }
        public string ProfResponsable { get; set; }
        public string OcuResponsable { get; set; }
        public string EntResponsable { get; set; }
        public int CelEmpresa { get; set; }
        public string TipoResponsable { get; set; }
        public string Correo { get; set; }
        public string Acudiente { get; set; }
        public int IdEstudiante { get; set; }
    }
    public class ActualizarResponsableResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Responsable Actualizado Exitosamente");
        }
    }

}
