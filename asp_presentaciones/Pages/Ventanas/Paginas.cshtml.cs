using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace asp_presentacion.Pages.Ventanas
{
    public class PaginasModel : PageModel
    {
        private IPaginasPresentacion? iPresentacion = null;
        private IProductosPresentacion? iProductosPresentacion = null;
        private IPromocionesPresentacion? iPromocionesPresentacion = null;
        private IImagenesPresentacion? iImagenesPresentacion = null;

        public PaginasModel(IPaginasPresentacion iPresentacion, IProductosPresentacion iProductosPresentacion, IPromocionesPresentacion iPromocionesPresentacion, IImagenesPresentacion iImagenesPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.iProductosPresentacion = iProductosPresentacion;
                this.iPromocionesPresentacion = iPromocionesPresentacion;
                this.iImagenesPresentacion = iImagenesPresentacion;
                Filtro = new Paginas();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Paginas? Actual { get; set; }
        [BindProperty] public Paginas? Filtro { get; set; }
        [BindProperty] public List<Paginas>? Lista { get; set; }
        [BindProperty] public List<Productos>? Productos { get; set; }
        [BindProperty] public List<Promociones>? Promociones { get; set; }
        [BindProperty] public List<Imagenes>? Imagenes { get; set; }

        public virtual void OnGet() { OnPostBtRefrescar(); }

        public void OnPostBtRefrescar()
        {
            try
            {
                Filtro!.Titulo = Filtro!.Titulo ?? "";

                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.Buscar(Filtro!, "TITULO");
                task.Wait();
                Lista = task.Result;
                CargarCombox();
                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtNuevo()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                CargarCombox();
                Actual = new Paginas();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtModificar(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Editar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
                CargarCombox();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual async Task<IActionResult> OnPostBtGuardarAsync()
        {
            Accion = Enumerables.Ventanas.Editar;

            if (Actual == null)
            {
                Actual = new Paginas();
            }

            if (Actual._Imagen == null)
            {
                Actual._Imagen = new Imagenes();
            }

            try
            {
                Task<Paginas>? task = null;
                if (Actual.Id == 0)
                {
                    task = this.iPresentacion!.Guardar(Actual!);
                }
                else
                {
                    task = this.iPresentacion!.Modificar(Actual!);
                }
                task.Wait();
                Actual = task.Result;
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }

            return RedirectToPage();
        }

        public virtual void OnPostBtBorrarVal(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Borrar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrar()
        {
            try
            {
                var task = this.iPresentacion!.Borrar(Actual!);
                Actual = task.Result;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCancelar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCerrar()
        {
            try
            {
                if (Accion == Enumerables.Ventanas.Listas)
                    OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void CargarCombox()
        {
            try
            {
                if (Productos == null || Productos!.Count <= 0)
                {
                    var taskProductos = this.iProductosPresentacion!.Listar();
                    taskProductos.Wait();
                    Productos = taskProductos.Result;
                }

                if (Promociones == null || Promociones!.Count <= 0)
                {
                    var taskPromociones = this.iPromocionesPresentacion!.Listar();
                    taskPromociones.Wait();
                    Promociones = taskPromociones.Result;
                }

                if (Imagenes == null || Imagenes!.Count <= 0)
                {
                    var taskImagenes = this.iImagenesPresentacion!.Listar();
                    taskImagenes.Wait();
                    Imagenes = taskImagenes.Result;
                }
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
