using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    public class Promociones
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public double? Descuento { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Final { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre) ||
                Descuento == null ||
                Inicio == null ||
                Final == null)
                return false;
            return true;
        }
    }
}
