using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using EntidadesAbstractas;
using Archivos;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class Tests
    {
        /// <summary>
        /// Prueba que se Lanze la excepcion DniInvalidoException si el Dni tiene un formato invalido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniException()
        {
            //La sección Arrange de un método de prueba unitaria inicializa objetos y establece el valor de los datos que se pasa al método en pruebas.
            //La sección Act invoca al método en pruebas con los parámetros organizados.
            //La sección Assert comprueba si la acción del método en pruebas se comporta de la forma prevista.

            //Arrange

            Alumno alumno;
            string nombre = "Gabriel";
            string apellido = "Saliba";
            string dni = "2345678A";
            int legajo = 1;
            Universidad.EClases claseQueToma = Universidad.EClases.Laboratorio;
            Persona.ENacionalidad nacionalidad = Persona.ENacionalidad.Argentino;

            //Act
            alumno = new Alumno(legajo, nombre, apellido, dni, nacionalidad, claseQueToma);
            
            //Assert
        }

        /// <summary>
        /// Prueba que se lanze la excepcion NacionalidadInvalidaException si la nacionalidad no coincide con el numero de dni
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadInvalidaException()
        {
            //La sección Arrange de un método de prueba unitaria inicializa objetos y establece el valor de los datos que se pasa al método en pruebas.
            //La sección Act invoca al método en pruebas con los parámetros organizados.
            //La sección Assert comprueba si la acción del método en pruebas se comporta de la forma prevista.

            //Arrange

            Profesor profesor;
            string nombre = "Federico";
            string apellido = "Davila";
            string dni = "99999999";
            int legajo = 2;
            Persona.ENacionalidad nacionalidad = Persona.ENacionalidad.Argentino;

            profesor = new Profesor(legajo, nombre, apellido, dni, nacionalidad);

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

            string numero = "A";
            bool resultado;
            
            bool ValidarValorNumerico(string Strnumero)
            {
                int numeroValido;
                return int.TryParse(Strnumero, out numeroValido);
            }

            //Act

            resultado = ValidarValorNumerico(numero);

            //Assert

            Assert.IsFalse(resultado, "El dato recibido no es numerico");

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
