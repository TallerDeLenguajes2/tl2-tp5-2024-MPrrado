using EspacioProductos;

namespace EspacioRepositorios
{
    internal interface IPresupuestoRespository
    {
        public void AltaPresupuesto(Presupuesto presupuesto);
        public List<Presupuesto> GetListaPresupuesto();
        public Presupuesto GetDetallePresupuesto(int idPresupuesto);
        public void AgregarProductoYCantidad(int idPresupuesto);
        public void EliminarPresupuesto(int idPresupuesto);
    }

    public class PresupuestoRepository : IPresupuestoRespository
    {
        public void AgregarProductoYCantidad(int idPresupuesto)
        {
            throw new NotImplementedException();
        }

        public void AltaPresupuesto(Presupuesto presupuesto)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}