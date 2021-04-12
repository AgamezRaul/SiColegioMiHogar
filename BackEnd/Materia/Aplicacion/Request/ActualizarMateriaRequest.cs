using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.materias.Aplicacion.Request
{
    class ActualizarMateriaRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdDocente { get; set; }
        public int IdCurso { get; set; }
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
