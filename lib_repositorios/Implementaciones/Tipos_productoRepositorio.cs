using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class Tipos_productoRepositorio : ITipos_productoRepositorio
    {
        private Conexion? conexion = null;

        public Tipos_productoRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Tipos_producto> Listar()
        {
            return conexion!.Listar<Tipos_producto>();
        }

        public List<Tipos_producto> Buscar(Expression<Func<Tipos_producto, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Tipos_producto Guardar(Tipos_producto entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Tipos_producto Modificar(Tipos_producto entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Tipos_producto Borrar(Tipos_producto entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}