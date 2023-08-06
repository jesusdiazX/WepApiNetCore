using APiServer.Dao;
using APiServer.Models;

namespace APiServer.Logic
{
    internal class Producto: IProducto
    {
      private readonly ProductosDao _ProductosDao;

        public Models.Producto addPost(Models.Producto prod)
        {
            var ProductosDao = new ProductosDao();

            return ProductosDao.addPost(prod);
        }

        public Models.Producto DeleteProducto(int productoId)
        {
            var ProductosDao = new ProductosDao();

            return ProductosDao.DeleteProducto(productoId);
        }

        public  List<APiServer.Models.Producto>lista()
        {
            var ProductosDao = new ProductosDao();

            return ProductosDao.lista();
        }

        public Models.Producto UpdatePut(Models.Producto prod)
        {
            var ProductosDao = new ProductosDao();
            return ProductosDao.UpdatePut(prod);

        }
    }
}
