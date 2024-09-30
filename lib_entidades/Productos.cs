using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades
{
    public class Productos
    {
        //Atributos
        [Key] public int Id { get; set; }
        public string? Codigo_producto { get; set; }
        public string? Nombre_producto { get; set; }
        public string? Descripcion { get; set; }
        public float Precio { get; set; }
        public int Stock { get; set; }
        public int Tipo_producto { get; set; }
        public int Fabricante { get; set; }

        [NotMapped] public Tipos_producto? _Tipo_producto { get; set; }
        [NotMapped] public Fabricantes? _Fabricante { get; set; }

        /*
         public Productos ObtenerProducto()
        {

        }
        public void AgregarProducto()
        {

        }
        public void EliminarProducto()
        {

        }
        */
    }
}
