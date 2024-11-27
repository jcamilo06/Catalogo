﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Fabricantes
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Contacto { get; set; }
        //[NotMapped] public virtual ICollection<Productos>? Productos { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre) ||
                string.IsNullOrEmpty(Contacto))
                return false;
            return true;
        }
    }
}
