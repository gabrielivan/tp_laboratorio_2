using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// Sobrecarga del Equals, retorna true si el objeto es del tipo Universitario
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }

        /// <summary>
        /// Metodo MostrarDatos, retorna los datos de la base(Persona) y agrega el legajo del Universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder datosPersona = new StringBuilder();
            datosPersona.AppendFormat("{0} \n Legajo: {1}", base.ToString(), this.legajo);
            return datosPersona.ToString();
        }

        /// <summary>
        /// Sobrecarga del operador != para dos universitarios
        /// </summary>
        /// <param name="primerUniversitario"></param>
        /// <param name="segundoUniversitario"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario primerUniversitario, Universitario segundoUniversitario)
        {
            return !(primerUniversitario == segundoUniversitario);
        }

        /// <summary>
        /// Dos Universitario serán iguales si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="primerUniversitario"></param>
        /// <param name="segundoUniversitario"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario primerUniversitario, Universitario segundoUniversitario)
        {
            bool retorno = false;

            if (primerUniversitario.Equals(segundoUniversitario) && ((primerUniversitario.legajo == segundoUniversitario.legajo) || (primerUniversitario.DNI == segundoUniversitario.DNI)))
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Metodo abstracto sera implementado por sus clases derivadas
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();


        /// <summary>
        /// 
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
    }
}
