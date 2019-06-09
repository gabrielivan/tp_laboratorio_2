using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        /// <summary>
        /// Propiedad de lectura y escritura.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                string apellidoAux;
                apellidoAux = ValidarNombreApellido(value);

                if (apellidoAux != "")
                {
                    this.apellido = value;
                }
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura.
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                if (this.ValidarDni(this.nacionalidad, value.ToString()) == 1)
                {
                    this.dni = value;
                }
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                string nombreAux;
                nombreAux = ValidarNombreApellido(value);

                if (nombreAux != "")
                {
                    this.nombre = value;
                }
            }
        }

        /// <summary>
        /// Propiedad de solo lectura 
        /// </summary>
        public string StringToDNI
        {
            set
            {
                if (this.ValidarDni(this.nacionalidad, value) == 1)
                {
                    this.dni = Convert.ToInt32(value);
                }
            }
        }

        /// <summary>
        /// Constructor de persona
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Sobrecarga del Constructor de Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Sobrecarga del Constructor de Persona que recibe el dni como int.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, Convert.ToString(dni), nacionalidad)
        {

        }

        /// <summary>
        /// Sobrecarga del Constructor de Persona que recibe el dni como string.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Sobreescritura del ToString, muestra el nombre, apellido y nacionalidad de Persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder datosPersona = new StringBuilder();
            datosPersona.AppendFormat("\n Apellido: {0}", this.Apellido);
            datosPersona.AppendFormat("\n Nombre: {0}", this.Nombre);
            datosPersona.AppendFormat("\n Nacionalidad: {0}", this.Nacionalidad);
            datosPersona.AppendFormat("\n DNI: {0}", this.DNI);
            return datosPersona.ToString();

        }

        /// <summary>
        /// Metodo que valida el dni con la nacionalidad de la persona
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = 0;

            if (nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999)
            {
                retorno = 1;
            }
            else if (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
            {
                retorno = 1;
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }

            return retorno;
        }

        /// <summary>
        /// Valida que el DNI recibido como string sea numerico, despues utiliza el metodo validarDni que recibe un (int)
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = 0;
            try
            {
                this.ValidarDni(nacionalidad, Convert.ToInt32(dato));
                retorno = 1;
            }
            catch (FormatException e)
            {
                throw new DniInvalidoException("El DNI tiene un formato invalido", e);
            }

            return retorno;
        }

        /// <summary>
        /// Valida el nombre/apellido de la persona
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            for (int i = 0; i < dato.Length; i++)
            {
                if (!Char.IsLetter(dato, i) && dato[i] != ' ')
                {
                    return "";
                }
            }

            return dato;
        }

        /// <summary>
        /// Enumerado de las Nacionalidades
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }
}
