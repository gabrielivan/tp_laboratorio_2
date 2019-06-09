using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using EntidadesAbstractas;
using Archivos;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Prueba que se Lanze la excepcion DniInvalidoException si el Dni tiene un formato invalido
        /// La prueba se reliza tratando de instanciar un alumno con un dni que tenga un fromato erroneo.
        /// </summary>
        [TestMethod]
        public void TestExceptionUno()
        {
            //La sección Arrange de un método de prueba unitaria inicializa objetos y establece el valor de los datos que se pasa al método en pruebas.
            //La sección Act invoca al método en pruebas con los parámetros organizados.
            //La sección Assert comprueba si la acción del método en pruebas se comporta de la forma prevista.

            //Arrange

            Alumno alumno;
            string nombre = "Gabriel";
            string apellido = "Saliba";
            string dni = "AA00BB11";
            int legajo = 1;
            Universidad.EClases claseQueToma = Universidad.EClases.Laboratorio;
            Persona.ENacionalidad nacionalidad = Persona.ENacionalidad.Argentino;

            //Act
            try
            {
                alumno = new Alumno(legajo, nombre, apellido, dni, nacionalidad, claseQueToma);
            }
            catch (DniInvalidoException dniException)
            {
                //Assert
                Assert.Fail(dniException.Message);
            }

        }

        /// <summary>
        /// Prueba que se lanze la excepcion NacionalidadInvalidaException si la nacionalidad no coincide con el numero de dni
        /// La prueba que realiza es que instancie a un profesor con un dni que sea para una nacionalidad argentina pero 
        /// pero la nacionalidad sea extranjera
        /// </summary>
        [TestMethod]
        public void TestExceptionDos()
        {
            //La sección Arrange de un método de prueba unitaria inicializa objetos y establece el valor de los datos que se pasa al método en pruebas.
            //La sección Act invoca al método en pruebas con los parámetros organizados.
            //La sección Assert comprueba si la acción del método en pruebas se comporta de la forma prevista.

            //Arrange

            Profesor profesor;
            string nombre = "Federico";
            string apellido = "Davila";
            string dni = "30000000";
            int legajo = 2;
            Persona.ENacionalidad nacionalidad = Persona.ENacionalidad.Extranjero;

            //Act
            try
            {
                profesor = new Profesor(legajo, nombre, apellido, dni, nacionalidad);
            }
            catch (NacionalidadInvalidaException nacionalidadException)
            {
                //Assert
                Assert.Fail(nacionalidadException.Message);
            }

        }

        /// <summary>
        /// Prueba que el dato de tipo string recibido sea numerico 
        /// </summary>
        [TestMethod]
        public void TestValidarValorNumerico()
        {
            //La sección Arrange de un método de prueba unitaria inicializa objetos y establece el valor de los datos que se pasa al método en pruebas.
            //La sección Act invoca al método en pruebas con los parámetros organizados.
            //La sección Assert comprueba si la acción del método en pruebas se comporta de la forma prevista.

            //Arrange

            string legajo = "A";
            bool resultado;
            
            bool ValidarValorNumerico(string Strnumero)
            {
                int numeroValido;
                return int.TryParse(Strnumero, out numeroValido);
            }

            //Act

            resultado = ValidarValorNumerico(legajo);

            //Assert

            Assert.IsTrue(resultado, "El dato recibido no es numerico");

        }

        /// <summary>
        /// Prueba que algun atributo de alguna clase no sea null
        /// si es null lanza el mensaje de Assert.isNotNull con el mensaje (El *x atributo* es null)
        /// en este test se valida los atributos nombre y apellido de la clase Profesor
        /// La prueba se puede realizar comentando la propiedad Apellido o Nombre de la clase Persona
        /// </summary>
        [TestMethod]
        public void TestValidarValorNull()
        {
            //La sección Arrange de un método de prueba unitaria inicializa objetos y establece el valor de los datos que se pasa al método en pruebas.
            //La sección Act invoca al método en pruebas con los parámetros organizados.
            //La sección Assert comprueba si la acción del método en pruebas se comporta de la forma prevista.

            //Arrange

            Profesor profesor = new Profesor(1, "Federico", "Davila", "30000000", Persona.ENacionalidad.Argentino);

            //Assert

            Assert.IsNotNull(profesor.Nombre, "El nombre es null");
            Assert.IsNotNull(profesor.Apellido, "El apellido es null");

        }
    }
}
