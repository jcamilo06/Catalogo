﻿using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_utilidades;
namespace mst_pruebas.Comunicaciones
{
    [TestClass]
    public class PromocionesPruebaUnitaria
    {
        private IPromocionesComunicacion? iComunicacion = null;
        private Promociones? entidad = null;
        private List<Promociones>? lista = null;
        public PromocionesPruebaUnitaria()
        {
            iComunicacion = new PromocionesComunicacion();
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
            lista = JsonConversor.ConvertirAObjeto<List<Promociones>>(
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
            lista = JsonConversor.ConvertirAObjeto<List<Promociones>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }
        
        public void Guardar()
        {
            var datos = new Dictionary<string, object>();
            entidad = new Promociones()
            {
                Nombre = "Prueba",
                Descuento = 0.3,
                Inicio = DateTime.Now,
                Final = DateTime.Now
            };
            datos["Entidad"] = entidad!;
            var task = iComunicacion!.Guardar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            entidad = JsonConversor.ConvertirAObjeto<Promociones>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
        
        public void Modificar()
        {
            var datos = new Dictionary<string, object>();
            entidad!.Nombre = "LG";
            datos["Entidad"] = entidad!;
            var task = iComunicacion!.Modificar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));
            entidad = JsonConversor.ConvertirAObjeto<Promociones>(
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
            entidad = JsonConversor.ConvertirAObjeto<Promociones>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
    }
}