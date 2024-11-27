using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

namespace asp_presentacion
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
            // Comunicaciones
            services.AddScoped<IFabricantesComunicacion, FabricantesComunicacion>();
            services.AddScoped<IImagenesComunicacion, ImagenesComunicacion>();
            services.AddScoped<IPaginasComunicacion, PaginasComunicacion>();
            services.AddScoped<IProductosComunicacion, ProductosComunicacion>();
            services.AddScoped<IPromocionesComunicacion, PromocionesComunicacion>();
            services.AddScoped<ITipos_productoComunicacion, Tipos_productoComunicacion>();
            services.AddScoped<IUsuariosComunicacion, UsuariosComunicacion>();
            // Presentaciones
            services.AddScoped<IFabricantesPresentacion, FabricantesPresentacion>();
            services.AddScoped<IImagenesPresentacion, ImagenesPresentacion>();
            services.AddScoped<IPaginasPresentacion, PaginasPresentacion>();
            services.AddScoped<IProductosPresentacion, ProductosPresentacion>();
            services.AddScoped<IPromocionesPresentacion, PromocionesPresentacion>();
            services.AddScoped<ITipos_productoPresentacion, Tipos_productoPresentacion>();
            services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}