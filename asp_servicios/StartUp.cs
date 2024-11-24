using asp_servicios.Controllers;
using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            // services.AddSwaggerGen();
            services.AddScoped<Conexion, Conexion>();
            // Repositorios
            services.AddScoped<IAuditoriasRepositorio, AuditoriasRepositorio>();
            services.AddScoped<IFabricantesRepositorio, FabricantesRepositorio>();
            services.AddScoped<IImagenesRepositorio, ImagenesRepositorio>();
            services.AddScoped<IPaginasRepositorio, PaginasRepositorio>();
            services.AddScoped<IProductosRepositorio, ProductosRepositorio>();
            services.AddScoped<IPromocionesRepositorio, PromocionesRepositorio>();
            services.AddScoped<ITipos_productoRepositorio, Tipos_productoRepositorio>();
            // Aplicaciones
            services.AddScoped<IFabricantesAplicacion, FabricantesAplicacion>();
            services.AddScoped<IImagenesAplicacion, ImagenesAplicacion>();
            services.AddScoped<IPaginasAplicacion, PaginasAplicacion>();
            services.AddScoped<IProductosAplicacion, ProductosAplicacion>();
            services.AddScoped<IPromocionesAplicacion, PromocionesAplicacion>();
            services.AddScoped<ITipos_productoAplicacion, Tipos_productoAplicacion>();
            // Controladores
            services.AddScoped<TokenController, TokenController>();

            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // app.UseSwagger();
                // app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}