using System.ComponentModel.DataAnnotations;

namespace lib_entidades
{
    public class Fabricantes
    {
        [Key] private int Id { get; set; }
        private string? Nombre { get; set; }
        private string? Contacto { get; set; }

        /*
        private Fabricantes ObtenerFabricante()
        {

        }
        private void AgregarFabricante()
        {

        }
        */
    }
}
