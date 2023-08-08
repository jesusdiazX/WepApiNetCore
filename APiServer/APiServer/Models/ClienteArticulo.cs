namespace APiServer.Models
{
    public class ClienteArticulo
    {
       
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int ArtClienteId { get; internal set; }
    }
}
