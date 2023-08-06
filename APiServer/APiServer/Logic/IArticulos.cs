namespace APiServer.Logic
{
    public interface IArticulos
    {
        public List<APiServer.Models.Articulo> lista();
        public APiServer.Models.Articulo getArticulo(int ArticuloId);
        public APiServer.Models.Articulo addPost(Models.Articulo cl);
        public APiServer.Models.Articulo UpdatePut(Models.Articulo cl);
        public Models.Articulo DeleteArticulo(int ArticuloId);
    }
}
