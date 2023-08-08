using APiServer.Logic;
using Microsoft.AspNetCore.Mvc;

namespace APiServer.Controllers
{


    [ApiController]
    [Route("[controller]")]

    public class VentasController : ControllerBase
    {

        private readonly IVentasL _venta;
        public VentasController(IVentasL ventas)
        {
            _venta = ventas;


        }
        [HttpPost]
        [Route("PostVenta")]
        public Models.Ventas PostVenta(Models.Ventas cl)
        {
            var students = _venta.addPost(cl);

            return students;
        }
    }
}
