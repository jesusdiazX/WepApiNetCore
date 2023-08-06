using APiServer.Logic;
using APiServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace APiServer.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class LoginController : ControllerBase
    {

        private readonly ICliente _producto;
      

        //public ProductosController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}
        public LoginController(ICliente producto)
        {
            _producto = producto;


        }
        [HttpPost]
        [Route("loginCliente")]
        public Models.Clientes loginCliente(login log)
        {
            var ls = _producto.login(log.user,log.pwd);

            return ls;
        }
    }
}
