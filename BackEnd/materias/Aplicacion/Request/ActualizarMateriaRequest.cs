using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.materias.Aplicacion.Request
{
    class ActualizarMateriaRequest
    {
        public int idMateria { get; set; }
        public string NombreMateria { get; set; }
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
