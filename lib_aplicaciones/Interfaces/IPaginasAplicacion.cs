using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface IPaginasAplicacion
    {
        void Configurar(string string_conexion);
        List<Paginas> Buscar(Paginas entidad, string tipo);
        List<Paginas> Listar();
        Paginas Guardar(Paginas entidad);
        Paginas Modificar(Paginas entidad);
        Paginas Borrar(Paginas entidad);
    }
}