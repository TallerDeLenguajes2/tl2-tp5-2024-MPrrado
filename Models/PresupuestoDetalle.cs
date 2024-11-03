namespace EspacioProductos
{
    public class Presupuesto
    {
        private int idPresupuesto;
        private string nombreDestinatario;
        private List<PresupuestoDetalle> detalle;

        public double MontoPresupuesto()
        {   
            double montoTotal = 0;
            foreach(var presupuesto in detalle)
            {
                montoTotal += presupuesto.Producto.Precio * presupuesto.Cantidad;
            }
            return montoTotal;
        }

        public double MontoPresupuestoConIVA()
        {
            return MontoPresupuesto() * 1.21;
        }

        public int CantidadProductos()
        {
            return detalle.Count();
        }
    }
}