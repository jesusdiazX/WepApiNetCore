using APiServer.Dao;
using APiServer.Models;

namespace APiServer.Logic
{
    internal class ArticulosL : IArticulos
    {
        public Articulo addPost(Articulo cl)
        {
            var ArticuloDao = new ArticulosDAO();

            return ArticuloDao.addPost(cl);
        }

        public Articulo DeleteArticulo(int ArticuloId)
        {
            var ArticuloDao = new ArticulosDAO();

            return ArticuloDao.DeleteArticulo(ArticuloId);
        }

        public Articulo getArticulo(int ArticuloId)
        {
            var ArticuloDao = new ArticulosDAO();

            return ArticuloDao.GetArticulo(ArticuloId);
        }

        public List<Articulo> lista()
        {
            var ArticuloDao = new ArticulosDAO();

            return ArticuloDao.lista();
        }

        public Articulo UpdatePut(Articulo cl)
        {
            var ArticuloDao = new ArticulosDAO();

            return ArticuloDao.UpdatePut(cl);
        }
    }
}
