using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_utilidades;
namespace mst_pruebas.Comunicaciones
{
    [TestClass]
    public class PaginasPruebaUnitaria
    {
        private IPaginasComunicacion? iComunicacion = null;
        private Paginas? entidad = null;
        private List<Paginas>? lista = null;
        public PaginasPruebaUnitaria()
        {
            iComunicacion = new PaginasComunicacion();
        }
        [TestMethod]
        public void Executar()
        {
            Guardar();
            Listar();
            Buscar();
            Modificar();
            Borrar();
        }
        private void Listar()
        {
            var datos = new Dictionary<string, object>();
            var task = iComunicacion!.Listar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            lista = JsonConversor.ConvertirAObjeto<List<Paginas>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }
        private void Buscar()
        {
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos["Tipo"] = "Prueba";
            var task = iComunicacion!.Buscar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            lista = JsonConversor.ConvertirAObjeto<List<Paginas>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }
        
        public void Guardar()
        {
            var datos = new Dictionary<string, object>();
            entidad = new Paginas()
            {
                Titulo = "Prueba",
                Fecha = DateTime.Now,
                Costo = 800000.0,
                Ciudad = "Ciudad1",
                Producto = 1,
                Imagen = 2,
                Promocion = 1
            };
            datos["Entidad"] = entidad!;
            var task = iComunicacion!.Guardar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            entidad = JsonConversor.ConvertirAObjeto<Paginas>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
        
        public void Modificar()
        {
            var datos = new Dictionary<string, object>();
            entidad!.Titulo = "LG";
            datos["Entidad"] = entidad!;
            var task = iComunicacion!.Modificar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            entidad = JsonConversor.ConvertirAObjeto<Paginas>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
        public void Borrar()
        {
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            var task = iComunicacion!.Borrar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            entidad = JsonConversor.ConvertirAObjeto<Paginas>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
    }
}