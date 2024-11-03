using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;

namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class ProductosPruebasUnitarias
    {
        private IProductosRepositorio? iRepositorio = null;
        private Productos? entidad = null;

        public ProductosPruebasUnitarias()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=DESKTOP-4PBEEL2\\DEV;database=db_catalogo;uid=sa;pwd=LOmejordelomejoR;TrustServerCertificate=true;";
            iRepositorio = new ProductosRepositorio(conexion);
        }

        [TestMethod]
        public void Ejecutar()
        {
            Guardar();
            Listar();
            Buscar();
            Modificar();
            Borrar();
        }

        private void Guardar()
        {
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
            entidad = iRepositorio!.Guardar(entidad);
            Assert.IsTrue(entidad.Id != 0);
        }

        private void Listar()
        {
            var lista = iRepositorio!.Listar();
            Assert.IsTrue(lista.Count > 0);
        }

        public void Buscar()
        {
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }

        private void Modificar()
        {
            entidad!.Nombre_producto = "Test";
            entidad = iRepositorio!.Modificar(entidad!);

            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }

        private void Borrar()
        {
            entidad = iRepositorio!.Borrar(entidad!);

            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count == 0);
        }
    }
}
