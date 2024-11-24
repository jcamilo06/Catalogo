using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Paginas
    {
        [Key] public int Id { get; set; }
        public string? Titulo { get; set; }
        public DateTime? Fecha { get; set; }
        public double Costo { get; set; }
        public string? Ciudad { get; set; }
        public int Producto { get; set; }
        public int Imagen { get; set; }
        public int Promocion { get; set; }
        [ForeignKey("Producto")] public Productos? _Producto { get; set; }
        [ForeignKey("Imagen")] public Imagenes? _Imagen { get; set; }
        [ForeignKey("Promocion")] public Promociones? _Promocion { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Titulo) ||
                Fecha == null ||
                Costo < 0 ||
                string.IsNullOrEmpty(Ciudad) ||
                Producto < 0 ||
                Imagen < 0 ||
                Promocion < 0)
                return false;
            return true;
        }
    }
}
