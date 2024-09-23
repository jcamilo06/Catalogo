using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades
{
    public class Paginas
    {
        private int Id { get; set; }
        private string? Titulo { get; set; }
        private DateTime Fecha { get; set; }
        private float Costo { get; set; }
        private string? Ciudad { get; set; }
        private int Producto { get; set; }
        private int Imagen { get; set; }
        private int Promocion { get; set; }

        [NotMapped] public Productos? _Producto { get; set; }
        [NotMapped] public Imagenes? _Imagen { get; set; }
        [NotMapped] public Promociones? _Promocion { get; set; }

        /*
        private Paginas ObtenerPagina()
        {

        }
        private void CrearPagina()
        {

        }
        private void EditarPagina()
        {

        }
        private void EliminarPagina()
        {

        }
        private List<Paginas> FiltrarPorFecha()
        {

        }
        */
    }
}
