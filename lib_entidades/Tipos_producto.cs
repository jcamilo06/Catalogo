using System.ComponentModel.DataAnnotations;

namespace lib_entidades
{
    public class Tipos_producto
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }

        /*
        private void EliminarTipo_Producto()
        {
            
        }
        */
    }
}
