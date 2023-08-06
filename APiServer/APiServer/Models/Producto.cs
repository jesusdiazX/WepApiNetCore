namespace APiServer.Models
{
    public class Producto
    {

        public int ProductoId { get; set; }
        public string Producto_Desc { get; set; }
        public decimal Producto_Precio { get; set; }
        public decimal Producto_Precio_unitario { get; set; }
        public decimal Producto_Precio_Venta { get; set; }
        public decimal Producto_Iva { get; set; }
        public Int16 Producto_Activo { get; set; }



    }
}
