namespace EspacioProductos
{
    public class Producto
    {
        private int idProducto;
        private string descripcion;
        private int precio;

        public Producto()
        {
        }
        public Producto(string descripcion, int precio)
        {
            this.descripcion = descripcion;
            this.precio = precio;
        }

        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Precio { get => precio; set => precio = value; }
        public int IdProducto { get => idProducto; }

        public void SetIdProducto(int idProducto)
        {
            this.idProducto = idProducto;
        }
    }
}