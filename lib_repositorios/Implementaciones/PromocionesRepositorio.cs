using lib_entidades;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class PromocionesRepositorio : IPromocionesRepositorio
    {
        private Conexion? conexion = null;

        public PromocionesRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public List<Promociones> Listar()
        {
            return conexion!.Listar<Promociones>();
        }

        public List<Promociones> Buscar(Expression<Func<Promociones, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Promociones Guardar(Promociones entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Promociones Modificar(Promociones entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Promociones Borrar(Promociones entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}