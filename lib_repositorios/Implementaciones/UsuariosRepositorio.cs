﻿using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public UsuariosRepositorio(Conexion conexion, IAuditoriasRepositorio iAuditoriasRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriasRepositorio = iAuditoriasRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Usuarios> Listar()
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Tabla = "Usuarios",
                Referencia = 0,
                Accion = "Listar"
            });
            return conexion!.Listar<Usuarios>();
        }

        public List<Usuarios> Buscar(Expression<Func<Usuarios, bool>> condiciones)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Tabla = "Usuarios",
                Referencia = 0,
                Accion = "Buscar"
            });
            return conexion!.Buscar(condiciones);
        }

        public Usuarios Guardar(Usuarios entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Tabla = "Usuarios",
                Referencia = entidad.Id,
                Accion = "Guardar"
            });
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Usuarios Modificar(Usuarios entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Tabla = "Usuarios",
                Referencia = entidad.Id,
                Accion = "Modificar"
            });
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Usuarios Borrar(Usuarios entidad)
        {
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Tabla = "Usuarios",
                Referencia = entidad.Id,
                Accion = "Borrar"
            });
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}