﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.PreMatricula.Aplicacion.Request
{
    public class EliminarPreMatriculaRequest
    {
        public int UsuarioId { get; set; }
    }
    public class EliminarPreMatriculaResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("PreMatricula Eliminado Exitosamente");
        }
    }
}