using BackEnd.Estudiante.Aplicacion.Request;
using BackEnd.Responsable.Aplicacion.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.PreMatricula.Aplicacion.Request
{
   public  class CrearPreMatriculaRequest 
    {
        public int id { get; set; }
        public DateTime FecPrematricula { get => DateTime.Now.Date; }
        public int IdUsuario { get; set; }
        public string Estado { get => "No confirmado"; }
        public List<CrearResponsableRequest> Responsables { get; set; }
        public CrearEstudianteRequest Estudiante { get; set; }

        public IReadOnlyList<string> CanCrear(CrearPreMatriculaRequest prematricula)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(prematricula.FecPrematricula.ToString()))
                errors.Add("Campo Fecha de Prematricula vacio");
            if (prematricula.IdUsuario == 0)
                errors.Add("Campo identificacion usuario vacio");
            if (string.IsNullOrEmpty(prematricula.Estado))
                errors.Add("Campo Estado de prematricula vacio");
            if (string.IsNullOrEmpty(prematricula.Estudiante.IdeEstudiante))
                errors.Add("Campo Identificacion estudiante vacio");
            if (string.IsNullOrEmpty(prematricula.Estudiante.NomEstudiante))
                errors.Add("Campo Nombre estudiante vacio");
            if (string.IsNullOrEmpty(prematricula.Estudiante.FecNacimiento.ToString()))
                errors.Add("Campo Fecha nacimiento vacio");
            if (string.IsNullOrEmpty(prematricula.Estudiante.LugNacimiento))
                errors.Add("Campo Lugar nacimiento vacio");
            if (string.IsNullOrEmpty(prematricula.Estudiante.LugExpedicion))
                errors.Add("Campo Lugar expedicion vacio");
            if (string.IsNullOrEmpty(prematricula.Estudiante.InsProcedencia))
                errors.Add("Campo Institución de procedencia vacio");
            if (string.IsNullOrEmpty(prematricula.Estudiante.DirResidencia))
                errors.Add("Campo Dirección residencia vacio");
            if (string.IsNullOrEmpty(prematricula.Estudiante.CelEstudiante))
                errors.Add("Campo Celular estudiante vacio");
            if (string.IsNullOrEmpty(prematricula.Estudiante.TipSangre))
                errors.Add("Campo Tipo sangre vacio");
            if (string.IsNullOrEmpty(prematricula.Estudiante.GradoEstudiante))
                errors.Add("Campo Grado estudiante vacio");
            if (string.IsNullOrEmpty(prematricula.Estudiante.Eps))
                errors.Add("Campo Eps vacio");
            if (string.IsNullOrEmpty(prematricula.Estudiante.Correo))
                errors.Add("Campo Correo estudiante vacio");
            if (string.IsNullOrEmpty(prematricula.Estudiante.Sexo))
                errors.Add("Campo Sexo estudiante vacio");
            if (string.IsNullOrEmpty(prematricula.Estudiante.TipoDocumento))
                errors.Add("Campo Tipo documento vacio");
            if (string.IsNullOrEmpty(prematricula.Estudiante.TelEstudiante))
                errors.Add("Campo Telefono estudiante vacio");
            if (prematricula.Estudiante.IdUsuario == 0)
                errors.Add("Campo Identificación usuario vacio");
            foreach (var responsable in prematricula.Responsables)
            {
                if (string.IsNullOrEmpty(responsable.IdeResponsable))
                    errors.Add("Campo Identificacion responsable vacio");
                if (string.IsNullOrEmpty(responsable.NomResponsable))
                    errors.Add("Campo Nombre responsable vacio");
                if (string.IsNullOrEmpty(responsable.FecNacimiento.ToString()))
                    errors.Add("Campo Fecha nacimiento vacio");
                if (string.IsNullOrEmpty(responsable.LugNacimiento))
                    errors.Add("Campo Lugar nacimiento vacio");
                if (string.IsNullOrEmpty(responsable.LugExpedicion))
                    errors.Add("Campo Lugar expedicion vacio");
                if (string.IsNullOrEmpty(responsable.TipDocumento))
                    errors.Add("Campo Tipo documento vacio");
                if (string.IsNullOrEmpty(responsable.CelResponsable))
                    errors.Add("Campo Celular responsable vacio");
                if (string.IsNullOrEmpty(responsable.ProfResponsable))
                    errors.Add("Campo Profesion del responsable vacio");
                if (string.IsNullOrEmpty(responsable.OcuResponsable))
                    errors.Add("Campo Ocupacion del responsable  vacio");
                if (string.IsNullOrEmpty(responsable.EntResponsable))
                    errors.Add("Campo Entidad en la cual trabaja el responsable vacio");
                if (string.IsNullOrEmpty(responsable.CelEmpresa))
                    errors.Add("Campo Celular empresa vacio");
                if (string.IsNullOrEmpty(responsable.TipoResponsable))
                    errors.Add("Campo Tipo responsable vacio");
                if (string.IsNullOrEmpty(responsable.Correo))
                    errors.Add("Campo Correo responsable vacio");
                if (string.IsNullOrEmpty(responsable.Acudiente))
                    errors.Add("Campo Acudiente vacio");
                if (responsable.IdUsuario == 0)
                    errors.Add("Campo Identificacion de estudiante vacio");
            }
            return errors;
        }
    }

    public class CrearPreMatriculaResponse
    {
        public CrearPreMatriculaResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("PreMatricula Creada Exitosamente");
        }
    }
}
