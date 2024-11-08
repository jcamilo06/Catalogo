﻿using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    public class Tipos_producto
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                return false;
            return true;
        }
    }
}
