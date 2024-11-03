using EspacioProductos;
using Microsoft.Data.Sqlite;

namespace EspacioRepositorios
{
    internal interface IProductoRepository
    {
        public void AltaProducto(Producto producto);
        public void ModificarProducto(int idProducto, Producto producto);
        public List<Producto> GetListaProductos();
        public Producto GetDetalleProducto(int idProducto);
        public void EliminarProducto(int idProducto);
    }
    public class ProductoRepository : IProductoRepository
    {
        public void AltaProducto(Producto producto)
        {
            if (producto != null)
            {
                string query = @"INSERT INTO Productos (Descripcion, Precio) VALUES (@Descripcion, @Precio)";
                string cadenaDeConexion = "Data Source=db/Tienda.db;Cache=Shared";
                using (SqliteConnection connection = new SqliteConnection(cadenaDeConexion))
                {
                    connection.Open();
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.Add(new SqliteParameter("@Descripcion", producto.Descripcion));
                        command.Parameters.Add(new SqliteParameter("@Precio", producto.Precio));
                        int a = command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
        }

        public void EliminarProducto(int idProducto)
        {
            throw new NotImplementedException();
        }

        public Producto GetDetalleProducto(int idProducto)
        {
            throw new NotImplementedException();
        }

        public List<Producto> GetListaProductos()
        {
            List<Producto> listaProductos = new List<Producto>();
            string query = @"SELECT Descripcion, Precio FROM Productos";
            string cadenaDeConexion = "Data Source=db/Tienda.db;Cache=Shared";
            using (SqliteConnection connection = new SqliteConnection(cadenaDeConexion))
            {
                connection.Open();
                var command = new SqliteCommand(query, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Producto productoDB = new Producto(reader["Descripcion"].ToString(), Convert.ToInt32(reader["Precio"]));
                        listaProductos.Add(productoDB);
                        // productoDB.Descripcion = reader["Descripcion"].ToString();
                    }
                }
                connection.Close();
            }
            return listaProductos;
        }

        public void ModificarProducto(int idProducto, Producto producto)
        {
            throw new NotImplementedException();
        }
    }
}