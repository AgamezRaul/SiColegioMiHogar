namespace BackEnd.Materia.Aplicacion.Request
{
    public class EliminarMateriaRequest
    {
        public int Id { get; set; }
    }
    public class EliminarMateriaResponse
    {
        public string Message { get; set; }
        public bool isOk()
        {
            return this.Message.Equals("Materia eliminada exitosamente");
        }
    }
}
