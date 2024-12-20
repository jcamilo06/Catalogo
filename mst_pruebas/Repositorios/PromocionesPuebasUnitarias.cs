﻿using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;

namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class PromocionesPruebasUnitarias
    {
        private IPromocionesRepositorio? iRepositorio = null;
        private Promociones? entidad = null;

        public PromocionesPruebasUnitarias()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=DESKTOP-4PBEEL2\\DEV;database=db_catalogo;uid=sa;pwd=LOmejordelomejoR;TrustServerCertificate=true;";
            var auditoria = new AuditoriasRepositorio(conexion);
            iRepositorio = new PromocionesRepositorio(conexion, auditoria);
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
            entidad = new Promociones()
            {
                Nombre = "Prueba",
                Descuento = 0.3,
                Inicio = DateTime.Now,
                Final = DateTime.Now
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
