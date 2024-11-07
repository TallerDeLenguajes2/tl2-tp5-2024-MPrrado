namespace EspacioProductos
{
    public class Presupuesto
    {
        private int idPresupuesto;
        private string nombreDestinatario;
        private List<PresupuestoDetalle> detalle;

        public Presupuesto()
        {
        }

        public List<PresupuestoDetalle> Detalle { get => detalle; set => detalle = value; }
        public string NombreDestinatario { get => nombreDestinatario; set => nombreDestinatario = value; }
        public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }

        public double MontoPresupuesto()
        {   
            double montoTotal = 0;
            foreach(var presupuesto in detalle)
            {
                montoTotal += (double)(presupuesto.Producto.Precio * presupuesto.Cantidad);
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