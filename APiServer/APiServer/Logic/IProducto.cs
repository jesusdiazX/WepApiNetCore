using APiServer.Models;

namespace APiServer.Logic
{
    public interface IProducto
    {

       public List<APiServer.Models.Producto> lista();


        public APiServer.Models.Producto addPost(Models.Producto prod);
        public APiServer.Models.Producto UpdatePut(Models.Producto prod);
       public  Models.Producto DeleteProducto(int productoId);
    }
}
