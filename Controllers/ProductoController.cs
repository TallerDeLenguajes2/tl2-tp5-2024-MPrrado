using EspacioProductos;
using EspacioRepositorios;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private ProductoRepository productoRepository;

    public ProductoController()
    {
        productoRepository = new ProductoRepository();
    }

    [HttpPost]
    [Route("AltaProducto")]
    public IActionResult AltaProducto([FromForm] Producto producto)
    {
        productoRepository.AltaProducto(producto);
        return Ok(producto);
    }

    [HttpGet]
    [Route("ObtenerListaProductos")]
    public IActionResult ObtenerListaProductos()
    {
        return Ok(productoRepository.GetListaProductos());
    }

    [HttpPut]
    [Route("ModificarProducto")]
    public IActionResult ModificarProducto(int idProducto)
    {
        var listaProductos = productoRepository.GetListaProductos();
        var producto = listaProductos.Find(p => p.IdProducto == idProducto);

        return Ok();
    }
}