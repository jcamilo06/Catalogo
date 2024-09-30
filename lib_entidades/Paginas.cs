using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades
{
    public class Paginas
    {
        [Key] public int Id { get; set; }
        public string? Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public double Costo { get; set; }
        public string? Ciudad { get; set; }
        public int Producto { get; set; }
        public int Imagen { get; set; }
        public int Promocion { get; set; }

        [NotMapped] public Productos? _Producto { get; set; }
        [NotMapped] public Imagenes? _Imagen { get; set; }
        [NotMapped] public Promociones? _Promocion { get; set; }

        /*
        public Paginas ObtenerPagina()
        {

        }
        public void CrearPagina()
        {

        }
        public void EditarPagina()
        {

        }
        public void EliminarPagina()
        {

        }
        public List<Paginas> FiltrarPorFecha()
        {

        }
        */
    }
}
