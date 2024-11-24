using lib_entidades.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace lib_repositorios
{
    public class Conexion : DbContext
    {
        public string? StringConnection { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConnection!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected DbSet<Auditorias>? Auditorias { get; set; }
        protected DbSet<Tipos_producto>? Tipos_producto { get; set; }
        protected DbSet<Fabricantes>? Fabricantes { get; set; }
        protected DbSet<Productos>? Productos { get; set; }
        protected DbSet<Imagenes>? Imagenes { get; set; }
        protected DbSet<Promociones>? Promociones { get; set; }
        protected DbSet<Paginas>? Paginas { get; set; }

        public virtual DbSet<T> ObtenerSet<T>() where T : class, new()
        {
            return this.Set<T>();
        }

        public virtual List<T> Listar<T>() where T : class, new()
        {
            return this.Set<T>().ToList();
        }

        public virtual List<T> Buscar<T>(Expression<Func<T, bool>> condiciones) where T : class, new()
        {
            return this.Set<T>().Where(condiciones).ToList();
        }

        //public virtual List<Tipos_producto> Buscar(Expression<Func<Tipos_producto, bool>> condiciones)
        //{
        //    return this.Set<Tipos_producto>()
        //        .Include(x => x.Productos)
        //        .Where(condiciones)
        //        .ToList();
        //}
        public virtual List<Productos> Buscar(Expression<Func<Productos, bool>> condiciones)
        {
            return this.Set<Productos>()
                .Include(x => x._Tipo_producto)
                .Include(x => x._Fabricante)
                //.Include(x => x.Paginas)
                .Where(condiciones)
                .ToList();
        }

        public virtual List<Paginas> Buscar(Expression<Func<Paginas, bool>> condiciones)
        {
            return this.Set<Paginas>()
                .Include(x => x._Imagen)
                //.Include(t => t._Imagen!.Paginas)
                .Include(x => x._Producto)
                //.Include(x => x._Producto!.Paginas)
                .Include(x => x._Producto!._Tipo_producto)
                //.Include(x => x._Producto!._Tipo_producto!.Productos)
                .Include(x => x._Producto!._Fabricante)
                //.Include(x => x._Producto!._Fabricante!.Productos)
                .Include(x => x._Promocion)
                //.Include(x => x._Promocion!.Paginas)
                .Where(condiciones)
                .ToList();
        }

        public virtual bool Existe<T>(Expression<Func<T, bool>> condiciones) where T : class, new()
        {
            return this.Set<T>().Any(condiciones);
        }

        public virtual void Guardar<T>(T entidad) where T : class, new()
        {
            this.Set<T>().Add(entidad);
        }

        public virtual void Modificar<T>(T entidad) where T : class
        {
            var entry = this.Entry(entidad);
            entry.State = EntityState.Modified;
        }

        public virtual void Borrar<T>(T entidad) where T : class, new()
        {
            this.Set<T>().Remove(entidad);
        }

        public virtual void Separar<T>(T entidad) where T : class, new()
        {
            this.Entry(entidad).State = EntityState.Detached;
        }

        public virtual void GuardarCambios()
        {
            this.SaveChanges();
        }
    }
}
