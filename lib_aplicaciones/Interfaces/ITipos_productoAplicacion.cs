using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface ITipos_productoAplicacion
    {
        void Configurar(string string_conexion);
        List<Tipos_producto> Buscar(Tipos_producto entidad, string tipo);
        List<Tipos_producto> Listar();
        Tipos_producto Guardar(Tipos_producto entidad);
        Tipos_producto Modificar(Tipos_producto entidad);
        Tipos_producto Borrar(Tipos_producto entidad);
    }
}