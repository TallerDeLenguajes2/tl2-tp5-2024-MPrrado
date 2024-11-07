using EspacioProductos;
using EspacioRepositorios;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

[ApiController]
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
    public IActionResult ModificarProducto(int idProducto, [FromForm] Producto productoModificado)
    {
        var listaProductos = productoRepository.GetListaProductos();
        if(listaProductos.Find(p => p.GetIdProducto()== idProducto) != null)
        {
            productoRepository.ModificarProducto(idProducto,productoModificado);
            return Ok(productoModificado);
        }else
        {
            return NotFound("Error no se encontro producto con la id ingresada");
        }
    }

    [HttpGet]
    [Route("ObtenerProductoSegunID")]

    public IActionResult ObtenerProductoSegunID(int idProducto)
    {
        var listaProductos = productoRepository.GetListaProductos();
        if(listaProductos.Find(p => p.GetIdProducto() == idProducto) != null)
        {
            return Ok(productoRepository.GetDetalleProducto(idProducto));
        }else
        {
            return NotFound("Error no se encontro producto con la id ingresada");
        }
    }

    [HttpDelete]
    [Route("EliminarProducto")]

    public IActionResult EliminarProducto(int idProducto)
    {
        var listaProductos = productoRepository.GetListaProductos();
        if(listaProductos.Find(p => p.GetIdProducto() == idProducto) != null)
        {
            var productoEliminado= listaProductos.Find(p => p.GetIdProducto() == idProducto);
            productoRepository.EliminarProducto(idProducto);
            return Ok(productoEliminado);
        }else
        {
            return NotFound("Error no se encontro producto con la id ingresada");
        }
    }
}