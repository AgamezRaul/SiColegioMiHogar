using BackEnd.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Responsable.Dominio
{
    public class Responsable: Entity<int>
    {
      
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
        public Responsable(string ideResponsable, string nomResponsable, DateTime fecNacimiento, string lugNacimiento, 
            string lugExpedicion, string tipDocumento, string celResponsable, string profResponsable, string ocuResponsable, 
            string entResponsable, string celEmpresa, string tipoResponsable, string correo, string acudiente, int idUsuario)
        {
            IdeResponsable = ideResponsable;
            NomResponsable = nomResponsable;
            FecNacimiento = fecNacimiento;
            LugNacimiento = lugNacimiento;
            LugExpedicion = lugExpedicion;
            TipDocumento = tipDocumento;
            CelResponsable = celResponsable;
            ProfResponsable = profResponsable;
            OcuResponsable = ocuResponsable;
            EntResponsable = entResponsable;
            CelEmpresa = celEmpresa;
            TipoResponsable = tipoResponsable;
            Correo = correo;
            Acudiente = acudiente;
            IdUsuario = idUsuario;
        }
    }
}
