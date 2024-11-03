using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Implementaciones
{
    public class PaginasAplicacion : IPaginasAplicacion
    {
        private IPaginasRepositorio? iRepositorio = null;

        public PaginasAplicacion(IPaginasRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Paginas Borrar(Paginas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Paginas Guardar(Paginas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Paginas> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Paginas> Buscar(Paginas entidad, string tipo)
        {
            Expression<Func<Paginas, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "TITULO": condiciones = x => x.Titulo!.Contains(entidad.Titulo!); break;
                case "CIUDAD": condiciones = x => x.Ciudad!.Contains(entidad.Ciudad!); break;
                case "COMPLEJA":
                    condiciones =
                        x => x.Titulo!.Contains(entidad.Titulo!) ||
                             x.Ciudad!.Contains(entidad.Ciudad!); break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Paginas Modificar(Paginas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }
    }
}