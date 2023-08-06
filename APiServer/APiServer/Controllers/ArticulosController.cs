using APiServer.Logic;
using APiServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace APiServer.Controllers
{
  
    [ApiController]
    [Route("[controller]")]

   
    public class ArticulosController : ControllerBase
    {
        private readonly IArticulos _producto;
        public ArticulosController(IArticulos producto)
        {
            _producto = producto;


        }

        [HttpGet]
        [Route("GetArticulo")]
        public List<Models.Articulo> Get()
        {
            var ls = _producto.lista();

            return ls.ToList();
        }
        [HttpGet]
        [Route("GetArticuloid")]
        public Models.Articulo Get( int id)
        {
            var ls = _producto.getArticulo(id);

            return ls;
        }
        [HttpPost]
        [Route("PostArticulo")]
        public Models.Articulo PostArticulo(Models.Articulo cl)
        {
            var students = _producto.addPost(cl);

            return students;
        }

        [HttpPut]
        [Route("PutArticulo")]
        public Models.Articulo PutArticulo(Articulo cl)
        {
            var students = _producto.UpdatePut(cl);

            return students;
        }


        [HttpDelete]
        [Route("DeleteArticulo")]
        public Models.Articulo DeleteArticulo(int ArticuloId)
        {
            var students = _producto.DeleteArticulo(ArticuloId);

            return students;
        }
    }
}
