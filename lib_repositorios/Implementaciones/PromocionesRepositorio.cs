using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class PromocionesRepositorio : IPromocionesRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public PromocionesRepositorio(Conexion conexion, IAuditoriasRepositorio iAuditoriasRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriasRepositorio = iAuditoriasRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Promociones> Listar()
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Tabla = "Promociones",
                Referencia = 0,
                Accion = "Listar"
            });
            return conexion!.Listar<Promociones>();
        }

        public List<Promociones> Buscar(Expression<Func<Promociones, bool>> condiciones)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Tabla = "Promociones",
                Referencia = 0,
                Accion = "Buscar"
            });
            return conexion!.Buscar(condiciones);
        }

        public Promociones Guardar(Promociones entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Tabla = "Promociones",
                Referencia = entidad.Id,
                Accion = "Guardar"
            });
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Promociones Modificar(Promociones entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Tabla = "Promociones",
                Referencia = entidad.Id,
                Accion = "Modificar"
            });
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Promociones Borrar(Promociones entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Tabla = "Promociones",
                Referencia = entidad.Id,
                Accion = "Borrar"
            });
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}