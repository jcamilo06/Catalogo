using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Productos
    {
        [Key] public int Id { get; set; }
        public string? Codigo_producto { get; set; }
        public string? Nombre_producto { get; set; }
        public string? Descripcion { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public int Tipo_producto { get; set; }
        public int Fabricante { get; set; }
        [ForeignKey("Tipo_producto")] public Tipos_producto? _Tipo_producto { get; set; }
        [ForeignKey("Fabricante")] public Fabricantes? _Fabricante { get; set; }
        //[NotMapped] public virtual ICollection<Paginas>? Paginas { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Codigo_producto) ||
                string.IsNullOrEmpty(Nombre_producto) ||
                string.IsNullOrEmpty(Descripcion) ||
                Precio < 0 ||
                Stock < 0 ||
                Tipo_producto < 0 ||
                Fabricante < 0)
                return false;
            return true;
        }
    }
}
