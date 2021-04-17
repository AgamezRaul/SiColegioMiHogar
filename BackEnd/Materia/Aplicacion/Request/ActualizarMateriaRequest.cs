﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Materia.Aplicacion.Request
{
    public class ActualizarMateriaRequest
    {
        public int Id { get; set; }
        public string NombreMateria { get; set; }
        public int IdDocente { get; set; }
    }
    public class ActualizarMateriaResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Materia actualizado exitosamente");
        }
    }
}
