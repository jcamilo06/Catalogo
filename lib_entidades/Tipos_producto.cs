using System.ComponentModel.DataAnnotations;

namespace lib_entidades
{
    public class Tipos_producto
    {
        [Key] public int Id { get; set; }
        private string? Nombre { get; set; }

        /*
        private void EliminarTipo_Producto()
        {
            
        }
        */
    }
}
