namespace EspacioProductos
{
    public class PresupuestoDetalle
    {
        private Producto producto;
        private int cantidad;

        public PresupuestoDetalle()
        {
        }
        public PresupuestoDetalle(Producto producto, int cantidad)
        {
            this.producto = producto;
            this.cantidad = cantidad;
        }

        public Producto Producto { get => producto; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}