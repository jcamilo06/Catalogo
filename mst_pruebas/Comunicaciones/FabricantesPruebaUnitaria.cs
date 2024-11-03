using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_utilidades;
namespace mst_pruebas.Comunicaciones
{
    [TestClass]
    public class FabricantesPruebaUnitaria
    {
        private IFabricantesComunicacion? iComunicacion = null;
        private Fabricantes? entidad = null;
        private List<Fabricantes>? lista = null;
        public FabricantesPruebaUnitaria()
        {
            iComunicacion = new FabricantesComunicacion();
        }
        [TestMethod]
        public void Executar()
        {
            // Guardar();
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
            lista = JsonConversor.ConvertirAObjeto<List<Fabricantes>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }
        private void Buscar()
        {
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos["Tipo"] = "NOMBRE";
            var task = iComunicacion!.Buscar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            lista = JsonConversor.ConvertirAObjeto<List<Fabricantes>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }
        /*
        public void Guardar()
        {
            var datos = new Dictionary<string, object>();
            entidad = new Fabricantes()
            {
                Persona = "Test 2",
                Nota1 = 1.2m,
                Nota2 = 2.5m,
                Nota3 = 4.5m,
                Nota4 = 3.8m,
                Nota5 = 4.3m,
                Final = 0.0m,
                Fecha = DateTime.Now,
            };
            datos["Entidad"] = entidad!;
            var task = iComunicacion!.Guardar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            entidad = JsonConversor.ConvertirAObjeto<Fabricantes>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
        */
        public void Modificar()
        {
            var datos = new Dictionary<string, object>();
            entidad!.Nombre = "LG";
            datos["Entidad"] = entidad!;
            var task = iComunicacion!.Modificar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            entidad = JsonConversor.ConvertirAObjeto<Fabricantes>(
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
            entidad = JsonConversor.ConvertirAObjeto<Fabricantes>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
    }
}