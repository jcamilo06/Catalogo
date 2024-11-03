using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface ITipos_productoPresentacion
    {
        Task<List<Tipos_producto>> Listar();
        Task<List<Tipos_producto>> Buscar(Tipos_producto entidad, string tipo);
        Task<Tipos_producto> Guardar(Tipos_producto entidad);
        Task<Tipos_producto> Modificar(Tipos_producto entidad);
        Task<Tipos_producto> Borrar(Tipos_producto entidad);
    }
}