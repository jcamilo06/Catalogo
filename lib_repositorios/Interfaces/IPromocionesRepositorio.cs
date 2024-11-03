using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IPromocionesRepositorio
    {
        void Configurar(string string_conexion);
        List<Promociones> Listar();
        List<Promociones> Buscar(Expression<Func<Promociones, bool>> condiciones);
        Promociones Guardar(Promociones entidad);
        Promociones Modificar(Promociones entidad);
        Promociones Borrar(Promociones entidad);
    }
}