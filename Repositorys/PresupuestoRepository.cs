using EspacioProductos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace EspacioRepositorios
{
    internal interface IPresupuestoRespository
    {
        public void AltaPresupuesto(Presupuesto presupuesto);
        public List<Presupuesto> GetListaPresupuesto();
        public Presupuesto GetDetallePresupuesto(int idPresupuesto);
        public void AgregarProductoYCantidad(int idPresupuesto, int idProducto, int cantidad);
        public void EliminarPresupuesto(int idPresupuesto);
    }

    public class PresupuestoRepository : IPresupuestoRespository
    {
        private string cadenaConexion = "Data Source=db/Tienda.db;Cache=Shared";
        public void AgregarProductoYCantidad(int idPresupuesto, int idProducto, int cantidad)
        {
           
            using(SqliteConnection connection = new SqliteConnection(cadenaConexion))
            {
                connection.Open();
                string query = "INSERT INTO PresupuestosDetalle (idPresupuesto,idProducto,Cantidad) VALUES(@idPresupuesto,@idProducto,@Cantidad)";
                using(SqliteCommand command = new SqliteCommand(query,connection))
                {
                    command.Parameters.Add(new SqliteParameter("@idPresupuesto",idPresupuesto));
                    command.Parameters.Add(new SqliteParameter("@idProducto",idProducto));
                    command.Parameters.Add(new SqliteParameter("@Cantidad",cantidad));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void AltaPresupuesto(Presupuesto presupuesto)
        {
            using(SqliteConnection connection = new SqliteConnection())
            {
                connection.Open();
                // string query = "SELECT NombreDestinatario,"
                connection.Close();
            }
        }

        public void EliminarPresupuesto(int idPresupuesto)
        {
            throw new NotImplementedException();
        }

        public Presupuesto GetDetallePresupuesto(int idPresupuesto)
        {
            throw new NotImplementedException();
        }

        public List<Presupuesto> GetListaPresupuesto()
        {
            List<Presupuesto> listaPresupuesto = new List<Presupuesto>();
            
            using(SqliteConnection connection = new SqliteConnection(cadenaConexion))
            {
                connection.Open();
                string query = "SELECT idPresupuesto, NombreDestinatario, idProducto, Cantidad FROM Presupuestos INNER JOIN PresupuestosDetalle USING(idPresupuesto)";
                using(SqliteCommand command = new SqliteCommand(query,connection))
                {
                    using(SqliteDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Presupuesto presupuesto = new Presupuesto();
                            presupuesto.IdPresupuesto = Convert.ToInt32(reader["idPresupuesto"]);
                            presupuesto.NombreDestinatario = reader["NombreDestinatario"].ToString();
                            PresupuestoDetalle presupuestoDetalle = new PresupuestoDetalle(); //genero mi detalle del presupuesto para luego agregarlos a la lista de detalle que contiene cada presupuesto
                            ProductoRepository productoRepository = new ProductoRepository(); //creo una instancia del repositorio de producto para poder obtener la lista de productos
                            var listaProductos = productoRepository.GetListaProductos();
                            var productoObtenido = listaProductos.Find(p => p.GetIdProducto() == Convert.ToInt32(reader["idProducto"]));
                            presupuestoDetalle.Producto = productoObtenido;
                            presupuestoDetalle.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                            presupuesto.Detalle.Add(presupuestoDetalle);
                        }

                    }
                }
                connection.Close();
            }
        }
    }
}