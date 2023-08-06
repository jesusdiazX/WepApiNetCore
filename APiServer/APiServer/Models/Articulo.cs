namespace APiServer.Models
{
    public class Articulo
    {
        public int ArticuloId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
        public string imagen { get; set; }
    }
}
