using System;

namespace BackEnd.Responsable.Aplicacion.Request
{
    public class CrearResponsableRequest
    {
        public int id { get; set; }
        public string IdeResponsable { get; set; }
        public string NomResponsable { get; set; }
        public DateTime FecNacimiento { get; set; }
        public string LugNacimiento { get; set; }
        public string LugExpedicion { get; set; }
        public string TipDocumento { get; set; }
        public string CelResponsable { get; set; }
        public string ProfResponsable { get; set; }
        public string OcuResponsable { get; set; }
        public string EntResponsable { get; set; }
        public string CelEmpresa { get; set; }
        public string TipoResponsable { get; set; }
        public string Correo { get; set; }
        public string Acudiente { get; set; }
        public int IdUsuario { get; set; }
    }
    public class CrearResponsableResponse
    {
        public CrearResponsableResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Responsables Creados Exitosamente");
        }
    }


}
