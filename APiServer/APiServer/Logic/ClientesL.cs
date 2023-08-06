using APiServer.Dao;
using APiServer.Models;

namespace APiServer.Logic
{
    internal  class ClientesL: ICliente
    {
        public Clientes addPost(Clientes cl)
        {
            var ProductosDao = new ClientesDAO();

            return ProductosDao.addPost(cl);
        }

        public Clientes Cliente(int ClienteId)
        {
            var ProductosDao = new ClientesDAO();

            return ProductosDao.GetClientes(ClienteId);
        }

        public Clientes DeleteProducto(int ClienteId)
        {
            var ProductosDao = new ClientesDAO();

            return ProductosDao.DeleteProducto(ClienteId);
        }

        public List<APiServer.Models.Clientes> Lista()
        {
            var ProductosDao = new ClientesDAO();

            return ProductosDao.lista();
        }

        public List<APiServer.Models.ClienteArticulo> RelacionCliente()
        {
            var ProductosDao = new ClientesDAO();

            return ProductosDao.RelacionCliente();
        }
        public Clientes login(string user, string password)
        {

            var ProductosDao = new ClientesDAO();

            return ProductosDao.login(user,password);
        }

        public Clientes UpdatePut(Clientes cl)
        {
            var ProductosDao = new ClientesDAO();

            return ProductosDao.UpdatePut(cl);
        }
    }
}
