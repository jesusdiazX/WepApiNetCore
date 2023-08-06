namespace APiServer.Logic
{
    public interface ITienda
    {
        public List<APiServer.Models.Tienda> lista();
        public APiServer.Models.Tienda getArticulo(int ArticuloId);
        public APiServer.Models.Tienda addPost(Models.Tienda cl);
        public APiServer.Models.Tienda UpdatePut(Models.Tienda cl);
        public Models.Tienda DeleteArticulo(int ArticuloId);
    }
}
