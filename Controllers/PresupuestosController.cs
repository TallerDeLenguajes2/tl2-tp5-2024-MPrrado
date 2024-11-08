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
        if()
        if(productoRepository.GetDetalleProducto(idProducto) != null)
        {

        }
        return Ok();
    }

}