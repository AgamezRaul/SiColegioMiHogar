﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.materias.Aplicacion.Request
{
    public class CrearMateriaRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdDocente { get; set; }
        public int IdCurso { get; set; }
    }
    public class CrearMateriaResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Materia creada exitosamente");
        }
    }
}