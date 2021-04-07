using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.RelacionUR.Dominio
{
   public class RelacionUR : Entity<int>
    {
       
        public int IdResponsable { get; set; }
        public int IdUsuario { get; set; }
        public RelacionUR(int idResponsable, int idUsuario)
        {
            IdResponsable = idResponsable;
            IdUsuario = idUsuario;
        }
        public IReadOnlyList<string> CanCrear(RelacionUR relacionUR)
        {
            var errors = new List<string>();

            
            if (relacionUR.IdResponsable == 0)
                errors.Add("Campo identiificacion  de responsable vacio");
            if (relacionUR.IdUsuario == 0)
                errors.Add("Campo identiificacion  de responsable vacio");
            return errors;
        }
    }
}
