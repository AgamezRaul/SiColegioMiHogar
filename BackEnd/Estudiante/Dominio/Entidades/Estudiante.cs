using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Estudiante.Dominio
{
    public class Estudiante : Entity<int>
    {
        public string IdeEstudiante { get; set; }
        public string NomEstudiante { get; set; }
        public DateTime FecNacimiento { get; set; }
        public string LugNacimiento { get; set; }
        public string LugExpedicion { get; set; }
        public string InsProcedencia { get; set; }
        public string DirResidencia { get; set; }
        public double CelEstudiante { get; set; }
        public string TipSangre { get; set; }
        public string GradoEstudiante { get; set; }
        public string Eps { get; set; }
        public string Correo { get; set; }
        public string Sexo { get; set; }
        public string TipoDocumento { get; set; }
        public string TelEstudiante { get; set; }

        public Estudiante(string ideEstudiante, string nomEstudiante, DateTime fecNacimiento, string lugNacimiento, string lugExpedicion, 
            string insProcedencia, string dirResidencia, double celEstudiante, string tipSangre, string gradoEstudiante, string eps, 
            string correo, string sexo, string tipoDocumento, string telEstudiante)
        {
            IdeEstudiante = ideEstudiante;
            NomEstudiante = nomEstudiante;
            FecNacimiento = fecNacimiento;
            LugNacimiento = lugNacimiento;
            LugExpedicion = lugExpedicion;
            InsProcedencia = insProcedencia;
            DirResidencia = dirResidencia;
            CelEstudiante = celEstudiante;
            TipSangre = tipSangre;
            GradoEstudiante = gradoEstudiante;
            Eps = eps;
            Correo = correo;
            Sexo = sexo;
            TipoDocumento = tipoDocumento;
            TelEstudiante = telEstudiante;
        }

        public IReadOnlyList<string> CanCrear(Estudiante estudiante)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(estudiante.IdeEstudiante))
                errors.Add("Campo Identificacion estudiante vacio");
            if (string.IsNullOrEmpty(estudiante.NomEstudiante))
                errors.Add("Campo Nombre estudiante vacio");
            if (string.IsNullOrEmpty(estudiante.FecNacimiento.ToString()))
                errors.Add("Campo Fecha nacimiento vacio");
            if (string.IsNullOrEmpty(estudiante.LugNacimiento))
                errors.Add("Campo Lugar nacimiento vacio");
            if (string.IsNullOrEmpty(estudiante.LugExpedicion))
                errors.Add("Campo Lugar expedicion vacio");
            if (string.IsNullOrEmpty(estudiante.InsProcedencia))
                errors.Add("Campo Institución de procedencia vacio");
            if (string.IsNullOrEmpty(estudiante.DirResidencia))
                errors.Add("Campo Dirección residencia vacio");
            if (estudiante.CelEstudiante == 0)
                errors.Add("Campo Celular estudiante vacio");
            if (string.IsNullOrEmpty(estudiante.TipSangre))
                errors.Add("Campo Tipo sangre vacio");
            if (string.IsNullOrEmpty(estudiante.GradoEstudiante))
                errors.Add("Campo Grado estudiante vacio");
            if (string.IsNullOrEmpty(estudiante.Eps))
                errors.Add("Campo Eps vacio");
            if (string.IsNullOrEmpty(estudiante.Correo))
                errors.Add("Campo Correo estudiante vacio");
            if (string.IsNullOrEmpty(estudiante.Sexo))
                errors.Add("Campo Sexo estudiante vacio");
            if (string.IsNullOrEmpty(estudiante.TipoDocumento))
                errors.Add("Campo Tipo documento vacio");
            if (string.IsNullOrEmpty(estudiante.TelEstudiante))
                errors.Add("Campo Telefono estudiante vacio");
            return errors;
        }
    }
}
