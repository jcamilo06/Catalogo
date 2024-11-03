using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    public class Imagenes
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Url { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre) ||
                string.IsNullOrEmpty(Url))
                return false;
            return true;
        }
    }
}
