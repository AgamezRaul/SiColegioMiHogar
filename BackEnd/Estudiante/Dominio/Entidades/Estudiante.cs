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
        public string CelEstudiante { get; set; }
        public string TipSangre { get; set; }
        public string GradoEstudiante { get; set; }
        public string Eps { get; set; }
        public string Correo { get; set; }
        public string Sexo { get; set; }
        public string TipoDocumento { get; set; }
        public string TelEstudiante { get; set; }
        public int IdUsuario { get; set; }

        public Estudiante() { }
        public Estudiante(string ideEstudiante, string nomEstudiante, DateTime fecNacimiento, string lugNacimiento, string lugExpedicion, 
            string insProcedencia, string dirResidencia, string celEstudiante, string tipSangre, string gradoEstudiante, string eps, 
            string correo, string sexo, string tipoDocumento, string telEstudiante, int idUsuario)
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
            IdUsuario = idUsuario;
        }
    }
}
