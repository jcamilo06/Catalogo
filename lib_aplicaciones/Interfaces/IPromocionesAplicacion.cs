using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface IPromocionesAplicacion
    {
        void Configurar(string string_conexion);
        List<Promociones> Buscar(Promociones entidad, string tipo);
        List<Promociones> Listar();
        Promociones Guardar(Promociones entidad);
        Promociones Modificar(Promociones entidad);
        Promociones Borrar(Promociones entidad);
    }
}