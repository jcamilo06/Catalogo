﻿using lib_entidades;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{

    public interface IImagenesRepositorio
    {
        List<Imagenes> Listar();
        List<Imagenes> Buscar(Expression<Func<Imagenes, bool>> condiciones);
        Imagenes Guardar(Imagenes entidad);
        Imagenes Modificar(Imagenes entidad);
        Imagenes Borrar(Imagenes entidad);
        
    }
}