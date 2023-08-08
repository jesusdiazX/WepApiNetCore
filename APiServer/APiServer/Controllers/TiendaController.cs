using APiServer.Logic;
using APiServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace APiServer.Controllers
{
  
    [ApiController]
    [Route("[controller]")]

   
    public class tiendaController : ControllerBase
    {
        private readonly ITienda _producto;
        public tiendaController(ITienda producto)
        {
            _producto = producto;


        }

        [HttpGet]
        [Route("Getienda")]
        public List<Models.Tienda> Getienda()
        {
            var ls = _producto.lista();

            return ls.ToList();
        }
        [HttpGet]
        [Route("Gettiendaid")]
        public Models.Tienda Get( int id)
        {
            var ls = _producto.getArticulo(id);

            return ls;
        }
        [HttpPost]
        [Route("PostTienda")]
        public Models.Tienda PostTienda(Models.Tienda cl)
        {
            var students = _producto.addPost(cl);

            return students;
        }

        [HttpPut]
        [Route("PutTienda")]
        public Models.Tienda PutTienda(Tienda cl)
        {
            var students = _producto.UpdatePut(cl);

            return students;
        }


        [HttpDelete]
        [Route("DeleteTienda")]
        public Models.Tienda DeleteTienda(int Tiendaid)
        {
            var students = _producto.DeleteArticulo(Tiendaid);

            return students;
        }


        [HttpPost]
        [Route("Relacionventas")]
        public Models.Tienda Relacionventas(int Tiendaid)
        {
            var students = _producto.DeleteArticulo(Tiendaid);

            return students;
        }
    }
}
