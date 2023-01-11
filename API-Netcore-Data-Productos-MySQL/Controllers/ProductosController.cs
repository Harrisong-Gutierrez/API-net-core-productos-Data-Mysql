using API_Netcore_Data_Productos_MySQL.NetCore_Cafe_Soluble.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_Cafe_Soluble.Data.Repositories;


namespace NetCore_Cafe_Soluble.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;

        public ProductosController(IProductoRepository productoRepository)
        {
            this._productoRepository = productoRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllProductos()
        {
            return Ok(await _productoRepository.GetAllProductos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductoDetails(int id)
        {
            return Ok(await _productoRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducto([FromBody] Producto producto)
        {
            if (producto == null) 
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _productoRepository.InsertProducto(producto);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProducto([FromBody] Producto producto)
        {
            if (producto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productoRepository.UpdateProducto(producto);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProducto(int  id)
        {
            await _productoRepository.DeleteProducto(new Producto { Id = id });

            return NoContent();
        }
    }
}
