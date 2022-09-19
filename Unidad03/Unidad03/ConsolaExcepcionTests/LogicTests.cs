using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoExcepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoExcepciones.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        public void DivisiónTest()
        {
            double numero1 = 5;
            double numero2 = 2;
            double resultadoEsperado = 2.5;
            double resultado = 0;
            Logic logic = new Logic();

            //Act
            resultado = logic.División(numero1, numero2);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }
    }
}