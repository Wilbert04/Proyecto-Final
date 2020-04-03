using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_MantenimientoVehicular.BLL;
using Proyecto_MantenimientoVehicular.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_MantenimientoVehicular.BLL.Tests
{
    [TestClass()]
    public class ClienteBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Clientes clientes = new Clientes();
            clientes.ClienteId = 0;
            clientes.Nombre = "Erisson";
            clientes.Cedula = "402344322";
            clientes.Telefono = "80923421";
            clientes.Direccion = "SFM";
            clientes.Email = "Erissonrd90";
            clientes.Fecha = DateTime.Now;
            paso = BLL.ClienteBLL.Guardar(clientes);

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
    }
}