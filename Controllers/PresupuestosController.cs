using EspacioProductos;
using EspacioRepositorios;
using Microsoft.AspNetCore.Mvc;

[Controller]
public class PresupuestosController : ControllerBase
{
    private PresupuestoRepository presupuestoRepository;
    public PresupuestosController()
    {
        presupuestoRepository = new PresupuestoRepository();
    }

    [HttpGet]
    [Route("ObtenerListaPresupuestos")]
    public IActionResult ObtenerListaPresupuestos()
    {
        return Ok(presupuestoRepository.GetListaPresupuesto());
    }

    [HttpPost]
    [Route("AltaPresupuesto")]
    public IActionResult AltaPresupuesto([FromForm]Presupuesto presupuesto)
    {
        presupuestoRepository.AltaPresupuesto(presupuesto);
        return Ok(presupuesto);
    }

    [HttpPost]
    [Route("AgregarProductoAPresupuesto")]
    public IActionResult AgregarProductoAPresupuesto(int idPresupuesto, int idProducto, int cantidad)
    {
        ProductoRepository productoRepository = new ProductoRepository();
        if(presupuestoRepository.GetListaPresupuesto().Find(p => p.IdPresupuesto == idPresupuesto)!= null)
        {
            if(productoRepository.GetProducto(idProducto) != null)
            {
                presupuestoRepository.AgregarProductoYCantidad(idPresupuesto,idProducto,cantidad);
                return Ok(productoRepository.GetProducto(idProducto));
            }else
            {
                return NotFound("No se encontro producto con idProducto ingresada");
            }
        }else
        {
            return NotFound("No se encontro presupuesto con la idPresupuesto ingresada");
        }
    }

    [HttpGet]
    [Route("ObtenerDetallePresupuesto")]
    public IActionResult ObtenerDetallePresupuesto(int idPresupuesto)
    {
        if(presupuestoRepository.GetListaPresupuesto().Find(p => p.IdPresupuesto == idPresupuesto)!= null)
        {
            return Ok(presupuestoRepository.GetDetallePresupuesto(idPresupuesto));
        }else
        {
            return NotFound("No se encontro presupuesto con la idPresupuesto ingresada");
        }
    }
}