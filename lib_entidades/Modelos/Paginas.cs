using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Paginas
    {
        [Key] public int Id { get; set; }
        public string? Titulo { get; set; }
        public DateTime? Fecha { get; set; }
        public double? Costo { get; set; }
        public string? Ciudad { get; set; }
        public int? Producto { get; set; }
        public int? Imagen { get; set; }
        public int? Promocion { get; set; }

        [NotMapped] public Productos? _Producto { get; set; }
        [NotMapped] public Imagenes? _Imagen { get; set; }
        [NotMapped] public Promociones? _Promocion { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Titulo) ||
                Fecha == null ||
                Costo == null ||
                string.IsNullOrEmpty(Ciudad) ||
                Producto == null ||
                Imagen == null ||
                Promocion == null)
                return false;
            return true;
        }
    }
}
