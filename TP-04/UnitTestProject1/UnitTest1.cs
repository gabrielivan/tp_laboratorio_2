using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test que verifica que la lista de Paquetes del Correo esté instanciada.
        /// </summary>
        [TestMethod]
        public void TestListaPaquetesCorreoInstanciada()
        {
            //Arrange
            Correo correo = new Correo(); //Instancia el correo
            //Act
            Assert.IsNotNull(correo.Paquetes); //Si da true, esta Ok, sino falla el test.
        }

        /// <summary>
        /// Test que verifica que no se puedan cargar dos Paquetes con el mismo Tracking ID.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TestNoPoderCargarDosPaquetesConMismoTrackingID()
        {
            //Arrange
            Correo correo = new Correo();//Instancio el correo
            Paquete pqtUno = new Paquete("Alberdi", "540"); //Instancio un paquete con el TrackingId "540"
            Paquete pqtDos = new Paquete("Quilmes", "540"); //Instancio otro paquete con el mismo TrackingId.

            //Act
            correo += pqtUno; //agrego el primer paquete a la lista de paquetes del correo
            correo += pqtDos; //agrego el segundo paquete a la lista de paquetes del correo

            //Assert
            //[ExpectedException(typeof(TrackingIdRepetidoException))]
            //Da Ok el test si y solo si al agregar los paquetes a la lista
            //con el mismo TrackingId, lanze la excepcion TrackingIdRepetidoException.
            //caso contrario, falla el test
        }
    }
}
