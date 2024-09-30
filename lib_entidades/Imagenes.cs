using System.ComponentModel.DataAnnotations;

namespace lib_entidades
{
    public class Imagenes
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Url { get; set; }

        /*
        public Imagenes ObtenerImagen()
        {

        }
        public void AgregarImagen()
        {

        }
        public void EliminarImagen()
        {

        }
        */
    }
}
