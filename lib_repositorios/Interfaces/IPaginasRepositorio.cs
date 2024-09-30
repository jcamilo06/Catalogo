using lib_entidades;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{

    public interface IPaginasRepositorio
    {
        List<Paginas> Listar();
        List<Paginas> Buscar(Expression<Func<Paginas, bool>> condiciones);
        Paginas Guardar(Paginas entidad);
        Paginas Modificar(Paginas entidad);
        Paginas Borrar(Paginas entidad);
        
    }
}