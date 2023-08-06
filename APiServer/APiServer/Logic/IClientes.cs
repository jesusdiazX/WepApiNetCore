namespace APiServer.Logic
{
    public interface ICliente
    {
        public List<APiServer.Models.Clientes> Lista();
        public List<APiServer.Models.ClienteArticulo> RelacionCliente();
        public APiServer.Models.Clientes Cliente(int ClienteId);
        
        public APiServer.Models.Clientes addPost(Models.Clientes cl);
        public APiServer.Models.Clientes UpdatePut(Models.Clientes cl);
        public Models.Clientes DeleteProducto(int ClienteId);
        public APiServer.Models.Clientes login(string user,string password);
    }
}
