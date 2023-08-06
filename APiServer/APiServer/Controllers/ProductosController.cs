using APiServer.Logic;
using APiServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.ComponentModel;

namespace APiServer.Controllers
{


    public class ProductosController : ControllerBase
    {
        private readonly IProducto _producto;
        private readonly ILogger<ProductosController> _logger;

        //public ProductosController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}
        public ProductosController(ILogger<ProductosController> logger, IProducto producto) {
        _producto = producto;
            _logger = logger;

        }    

        [HttpGet(Name = "GetProductos")]
        public  List<Models.Producto> Get()
        {
            var students =  _producto.lista().ToList();

            return students;
        }

        [HttpPost(Name = "PostProducto")]
        public Models.Producto PostProducto(Models.Producto prod)
        {
            var students = _producto.addPost(prod);

            return students;
        }

        [ HttpPut(Name = "PutProducto")]
        public Models.Producto PutProducto(Models.Producto prod)
        {
            var students = _producto.UpdatePut(prod);

            return students;
        }


        [HttpDelete(Name = "DeleteProducto")]
        public Models.Producto DeleteProducto(int ProductoId)
        {
            var students = _producto.DeleteProducto(ProductoId);

            return students;
        }
    }
}
