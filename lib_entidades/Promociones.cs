using System.ComponentModel.DataAnnotations;

namespace lib_entidades
{
    public class Promociones
    {
        [Key] private int Id { get; set; }
        private string? Nombre { get; set; }
        private float Descuento { get; set; }
        private DateTime Inicio { get; set; }
        private DateTime Final { get; set; }

        /*
        private void CrearPromocion()
        {

        }
        */
    }
}
