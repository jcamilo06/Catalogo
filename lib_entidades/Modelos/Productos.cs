﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Productos
    {
        [Key] public int Id { get; set; }
        public string? Codigo_producto { get; set; }
        public string? Nombre_producto { get; set; }
        public string? Descripcion { get; set; }
        public double? Precio { get; set; }
        public int? Stock { get; set; }
        public int? Tipo_producto { get; set; }
        public int? Fabricante { get; set; }

        [NotMapped] public Tipos_producto? _Tipo_producto { get; set; }
        [NotMapped] public Fabricantes? _Fabricante { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Codigo_producto) ||
                string.IsNullOrEmpty(Nombre_producto) ||
                string.IsNullOrEmpty(Descripcion) ||
                Precio == null ||
                Stock == null ||
                Tipo_producto == null ||
                Fabricante == null)
                return false;
            return true;
        }
    }
}
