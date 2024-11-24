using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Promociones
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public double Descuento { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Final { get; set; }
        [NotMapped] public virtual ICollection<Paginas>? Paginas { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre) ||
                Descuento < 0 ||
                Descuento > 1 ||
                Inicio == null ||
                Final == null)
                return false;
            return true;
        }
    }
}
