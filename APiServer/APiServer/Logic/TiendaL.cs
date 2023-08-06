using APiServer.Dao;
using APiServer.Models;

namespace APiServer.Logic
{
    internal class TiendaL:ITienda
    {
        public Tienda addPost(Tienda cl)
        {
            var ProductosDao = new TiendaDAO();

            return ProductosDao.addPost(cl);
        }

        public Tienda DeleteArticulo(int ArticuloId)
        {
            var ProductosDao = new TiendaDAO();

            return ProductosDao.DeleteArticulo(ArticuloId);
        }

        public Tienda DeleteProducto(int ClienteId)
        {
            var ProductosDao = new TiendaDAO();

            return ProductosDao.DeleteArticulo(ClienteId);
        }

        public Tienda getArticulo(int ArticuloId)
        {
            var ProductosDao = new TiendaDAO();

            return ProductosDao.GetArticulo(ArticuloId);
        }

        public List<APiServer.Models.Tienda> Lista()
        {
            var ProductosDao = new TiendaDAO();

            return ProductosDao.lista();
        }

        public List<Tienda> lista()
        {
            var ProductosDao = new TiendaDAO();

            return ProductosDao.lista();
        }

        public Tienda UpdatePut(Tienda cl)
        {
            var ProductosDao = new TiendaDAO();

            return ProductosDao.UpdatePut(cl);
        }
    }
}
