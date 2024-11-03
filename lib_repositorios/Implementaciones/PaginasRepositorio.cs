using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class PaginasRepositorio : IPaginasRepositorio
    {
        private Conexion? conexion = null;

        public PaginasRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Paginas> Listar()
        {
            return conexion!.Listar<Paginas>();
        }

        public List<Paginas> Buscar(Expression<Func<Paginas, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Paginas Guardar(Paginas entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Paginas Modificar(Paginas entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Paginas Borrar(Paginas entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}