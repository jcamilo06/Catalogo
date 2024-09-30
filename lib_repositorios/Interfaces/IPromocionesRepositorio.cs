using lib_entidades;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{

    public interface IPromocionesRepositorio
    {
        List<Promociones> Listar();
        List<Promociones> Buscar(Expression<Func<Promociones, bool>> condiciones);
        Promociones Guardar(Promociones entidad);
        Promociones Modificar(Promociones entidad);
        Promociones Borrar(Promociones entidad);
        
    }
}