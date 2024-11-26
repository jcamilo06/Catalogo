using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_utilidades;
namespace mst_pruebas.Comunicaciones
{
    [TestClass]
    public class ProductosPruebaUnitaria
    {
        private IProductosComunicacion? iComunicacion = null;
        private Productos? entidad = null;
        private List<Productos>? lista = null;
        public ProductosPruebaUnitaria()
        {
            iComunicacion = new ProductosComunicacion();
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
            lista = JsonConversor.ConvertirAObjeto<List<Productos>>(
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
            lista = JsonConversor.ConvertirAObjeto<List<Productos>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }
        
        public void Guardar()
        {
            var datos = new Dictionary<string, object>();
            entidad = new Productos()
            {
                Codigo_producto = "005",
                Nombre_producto = "Prueba",
                Descripcion = "Prueba Prueba Prueba Prueba Prueba",
                Precio = 1100.0,
                Stock = 5,
                Tipo_producto = 1,
                Fabricante = 1
            };
            datos["Entidad"] = entidad!;
            var task = iComunicacion!.Guardar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            entidad = JsonConversor.ConvertirAObjeto<Productos>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
        
        public void Modificar()
        {
            var datos = new Dictionary<string, object>();
            entidad!.Nombre_producto = "LG";
            datos["Entidad"] = entidad!;
            var task = iComunicacion!.Modificar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            entidad = JsonConversor.ConvertirAObjeto<Productos>(
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
            entidad = JsonConversor.ConvertirAObjeto<Productos>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
    }
}