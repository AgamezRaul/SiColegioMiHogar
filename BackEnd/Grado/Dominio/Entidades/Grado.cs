using BackEnd.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Grado.Dominio
{
  public  class Grado : Entity<int>
    {
        public string Nombre { get; set; }
        public Grado(string nombre)
        {
            Nombre = nombre;
        }
    }
}
