﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Matricula.Aplicacion.Request
{
    public class ActualizarMatriculaRequest
    {
        public int id { get; set; }
        public DateTime FecConfirmacion { get; set; }
        public int IdePreMatricula { get; set; }

    }
    public class ActualizarMatriculaResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Matricula Actualizada Exitosamente");
        }
    }
}
