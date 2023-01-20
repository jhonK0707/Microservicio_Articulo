using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Relational;
using SVJK.Ms.Articulo.Dominio.Entidades;
using SVJK.Ms.Articulo.Infraestructura.Repositorios;
using System.Threading.Tasks;

namespace SVJK.Ms.Articulo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly IArticuloRepositorio _articuloRepositorio;

        public ArticulosController(IArticuloRepositorio articuloRepositorio)
        {
            _articuloRepositorio = articuloRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> ListarArticulos()
        {
            return Ok(await _articuloRepositorio.ListarArticulos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarArticulo(int id)
        {
            return Ok(await _articuloRepositorio.BuscarArticulo(id));
        }

        [HttpPost]
        public async Task<IActionResult> CrearArticulo([FromBody] Dominio.Entidades.Articulo articulo)
        {
            if (articulo == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _articuloRepositorio.InsertarArticulo(articulo);

            return Created("creado",creado);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarArticulo([FromBody] Dominio.Entidades.Articulo articulo)
        {
            if (articulo == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _articuloRepositorio.ActualizarArticulo(articulo);

            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> EliminarArticulo(int id)
        {
            await _articuloRepositorio.EliminarArticulo(new Dominio.Entidades.Articulo() { Id=id});
            return NoContent();
        }


    }
}
