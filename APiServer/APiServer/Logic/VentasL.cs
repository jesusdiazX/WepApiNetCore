using APiServer.Dao;
using APiServer.Models;

namespace APiServer.Logic
{
    internal class VentasL : IVentasL
    {

        public Models.Ventas addPost(Models.Ventas prod)
        {
            var ProductosDao = new VentasDAO();

            return ProductosDao.addPost(prod);
        }
    }
}
