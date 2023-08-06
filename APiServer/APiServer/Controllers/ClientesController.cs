using APiServer.Logic;
using APiServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace APiServer.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {



        private readonly ICliente _producto;
        private readonly ILogger<ProductosController> _logger;

        //public ProductosController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}
        public ClientesController(ICliente producto)
        {
            _producto = producto;
            

        }

        [HttpGet]
        [Route("GetCliente")]
        public List<Models.Clientes> GetCliente()
        {
            var students = _producto.Lista().ToList();

            return students;
        }

        [HttpPost]
        [Route("PostCliente")]
        public Models.Clientes PostCliente(Models.Clientes cl)
        {
            var students = _producto.addPost(cl);

            return students;
        }

        [HttpPut]
        [Route("PutClientes")]
        public Models.Clientes PutClientes(Clientes cl)
        {
            var students = _producto.UpdatePut(cl);

            return students;
        }


        [HttpDelete]
        [Route("DeleteClientes")]
        public Models.Clientes DeleteClientes(int ClienteId)
        {
            var students = _producto.DeleteProducto(ClienteId);

            return students;
        }
        [HttpGet]
        [Route("GetClienteid")]
        public Models.Clientes GetClienteid(int ClienteId)
        {
            var ls = _producto.Cliente(ClienteId);

            return ls;
        }

        [HttpGet]
        [Route("RelacionCliente")]
        public List<Models.ClienteArticulo> RelacionCliente()
        {
            var students = _producto.RelacionCliente().ToList();

            return students;
        }
    }
}
