using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IPaginasRepositorio
    {
        void Configurar(string string_conexion);
        List<Paginas> Listar();
        List<Paginas> Buscar(Expression<Func<Paginas, bool>> condiciones);
        Paginas Guardar(Paginas entidad);
        Paginas Modificar(Paginas entidad);
        Paginas Borrar(Paginas entidad);
    }
}