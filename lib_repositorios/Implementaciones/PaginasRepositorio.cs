using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class PaginasRepositorio : IPaginasRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public PaginasRepositorio(Conexion conexion, IAuditoriasRepositorio iAuditoriasRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriasRepositorio = iAuditoriasRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Paginas> Listar()
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Tabla = "Paginas",
                Referencia = 0,
                Accion = "Listar"
            });
            return Buscar(x => x != null);
        }

        public List<Paginas> Buscar(Expression<Func<Paginas, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Paginas Guardar(Paginas entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Tabla = "Paginas",
                Referencia = entidad.Id,
                Accion = "Guardar"
            });
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Paginas Modificar(Paginas entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Tabla = "Paginas",
                Referencia = entidad.Id,
                Accion = "Modificar"
            });
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Paginas Borrar(Paginas entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Tabla = "Paginas",
                Referencia = entidad.Id,
                Accion = "Borrar"
            });
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}