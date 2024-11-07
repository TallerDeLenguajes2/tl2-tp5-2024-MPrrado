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

    [HttpPost]
    [Route("AltaPresupuesto")]
    public IActionResult AltaPresupuesto([FromForm]Presupuesto presupuesto)
    {
        return Ok();
    }

    [HttpPost]
    [Route("AgregarProductoAPresupuesto")]
    public IActionResult AgregarProductoAPresupuesto(int idPresupuesto, int idProducto, int cantidad)
    {

        return Ok();
    }

}