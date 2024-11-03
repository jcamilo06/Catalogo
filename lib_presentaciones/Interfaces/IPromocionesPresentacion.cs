using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IPromocionesPresentacion
    {
        Task<List<Promociones>> Listar();
        Task<List<Promociones>> Buscar(Promociones entidad, string tipo);
        Task<Promociones> Guardar(Promociones entidad);
        Task<Promociones> Modificar(Promociones entidad);
        Task<Promociones> Borrar(Promociones entidad);
    }
}