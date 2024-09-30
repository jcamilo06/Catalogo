﻿using lib_entidades;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{

    public interface IProductosRepositorio
    {
        List<Productos> Listar();
        List<Productos> Buscar(Expression<Func<Productos, bool>> condiciones);
        Productos Guardar(Productos entidad);
        Productos Modificar(Productos entidad);
        Productos Borrar(Productos entidad);
        
    }
}