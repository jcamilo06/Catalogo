using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Usuarios
    {
        [Key] public int Id { get; set; }
        public string? Email { get; set; }
        public string? Contraseña { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Contraseña))
                return false;
            return true;
        }
    }
}
