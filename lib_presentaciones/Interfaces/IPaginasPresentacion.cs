using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IPaginasPresentacion
    {
        Task<List<Paginas>> Listar();
        Task<List<Paginas>> Buscar(Paginas entidad, string tipo);
        Task<Paginas> Guardar(Paginas entidad);
        Task<Paginas> Modificar(Paginas entidad);
        Task<Paginas> Borrar(Paginas entidad);
    }
}