using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_MantenimientoVehicular.BLL;
using Proyecto_MantenimientoVehicular.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_MantenimientoVehicular.BLL.Tests
{
    [TestClass()]
    public class ArticuloBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Articulos articulos = new Articulos();

            articulos.ArticuloId = Convert.ToInt32("0");
            articulos.Articulo = "Neumatico";
            articulos.Categoria = "Desgatables";
            articulos.Existencia = Convert.ToDecimal("0");
            articulos.Precio = Convert.ToDecimal("100");
            articulos.Fecha = DateTime.Now;

            paso = BLL.ArticuloBLL.Guardar(articulos);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CalcularItbisTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CalcularImporteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CalcularSubtotalTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CalcularTotalTest()
        {
            Assert.Fail();
        }
    }
}