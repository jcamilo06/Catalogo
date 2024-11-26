using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;

// Test
namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class FabricantesPruebasUnitarias
    {
        private IFabricantesRepositorio? iRepositorio = null;
        private Fabricantes? entidad = null;

        public FabricantesPruebasUnitarias()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=DESKTOP-4PBEEL2\\DEV;database=db_catalogo;uid=sa;pwd=LOmejordelomejoR;TrustServerCertificate=true;";
            var auditoria = new AuditoriasRepositorio(conexion);
            iRepositorio = new FabricantesRepositorio(conexion, auditoria);
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
            entidad = new Fabricantes()
            {
                Nombre = "Prueba",
                Contacto = "300 000 0000"
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
            entidad!.Nombre = "Test";
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
