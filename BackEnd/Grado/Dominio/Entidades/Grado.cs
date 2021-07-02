using BackEnd.Base;

namespace BackEnd.Grado.Dominio
{
    public class Grado : Entity<int>
    {
        public string Nombre { get; set; }
        public Grado(string nombre)
        {
            Nombre = nombre;
        }
    }
}
