﻿using BackEnd.Base;
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

        public IReadOnlyList<string> CanCrear(Responsable responsable)
        {
            var errors = new List<string>();
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

            return errors;
        }

    }
}
