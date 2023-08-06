using ApiServiceTienda.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiServiceTienda.Controllers
{

  

    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {


        private readonly DBConecxion _myWorldDbContext;

        public ProductoController(DBConecxion myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }

        [HttpGet(Name = "GetProducto")]
        public async Task<IActionResult> GetAsync()
        {
            var students = await _myWorldDbContext.Producto.ToListAsync();
            return Ok(students);
        }
        [HttpGet(Name = "GetDemo")]
        public async Task<IActionResult> GetdemoAsync()
        {
            var students = await _myWorldDbContext.Demo.ToListAsync();
            return Ok(students);
        }

    }
}
