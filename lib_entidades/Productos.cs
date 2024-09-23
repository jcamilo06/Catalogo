using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades
{
    public class Productos
    {
        //Atributos
        [Key] private int Id { get; set; }
        private string? Codigo_producto { get; set; }
        private string? Nombre_producto { get; set; }
        private string? Descripcion { get; set; }
        private float Precio { get; set; }
        private int Stock { get; set; }
        private int Tipo_producto { get; set; }
        private int Fabricante { get; set; }

        [NotMapped] public Tipos_producto? _Tipo_producto { get; set; }
        [NotMapped] public Fabricantes? _Fabricante { get; set; }

        /*
         private Productos ObtenerProducto()
        {

        }
        private void AgregarProducto()
        {

        }
        private void EliminarProducto()
        {

        }
        */
    }
}
