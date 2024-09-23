using System.ComponentModel.DataAnnotations;

namespace lib_entidades
{
    public class Imagenes
    {
        [Key] private int Id { get; set; }
        private string? Nombre { get; set; }
        private string? Url { get; set; }

        /*
        private Imagenes ObtenerImagen()
        {

        }
        private void AgregarImagen()
        {

        }
        private void EliminarImagen()
        {

        }
        */
    }
}
