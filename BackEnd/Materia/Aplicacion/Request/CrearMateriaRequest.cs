namespace BackEnd.Materia.Aplicacion.Request
{
    public class CrearMateriaRequest
    {
        public int Id { get; set; }
        public string NombreMateria { get; set; }
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
