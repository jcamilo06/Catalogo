using lib_entidades;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{

    public interface ITipos_productoRepositorio
    {
        List<Tipos_producto> Listar();
        List<Tipos_producto> Buscar(Expression<Func<Tipos_producto, bool>> condiciones);
        Tipos_producto Guardar(Tipos_producto entidad);
        Tipos_producto Modificar(Tipos_producto entidad);
        Tipos_producto Borrar(Tipos_producto entidad);
        
    }
}