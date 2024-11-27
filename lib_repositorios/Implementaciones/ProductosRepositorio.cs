﻿using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class ProductosRepositorio : IProductosRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public ProductosRepositorio(Conexion conexion, IAuditoriasRepositorio iAuditoriasRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriasRepositorio = iAuditoriasRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Productos> Listar()
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Tabla = "Productos",
                Referencia = 0,
                Accion = "Listar"
            });
            return Buscar(x => x != null);
        }

        public List<Productos> Buscar(Expression<Func<Productos, bool>> condiciones)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Tabla = "Productos",
                Referencia = 0,
                Accion = "Buscar"
            });
            return conexion!.Buscar(condiciones);
        }

        public Productos Guardar(Productos entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Tabla = "Productos",
                Referencia = entidad.Id,
                Accion = "Guardar"
            });
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Productos Modificar(Productos entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Tabla = "Productos",
                Referencia = entidad.Id,
                Accion = "Modificar"
            });
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Productos Borrar(Productos entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Tabla = "Productos",
                Referencia = entidad.Id,
                Accion = "Borrar"
            });
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}