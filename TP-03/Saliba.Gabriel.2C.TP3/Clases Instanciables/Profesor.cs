using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        /// <summary>
        /// Metodo que Agrega 2 clases random para el atributo clasesDeldia.
        /// </summary>
        private void _randomClases()
        {
           clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 3));
           clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 3));
        }

        /// <summary>
        /// Devuelve los datos del profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder datosPersona = new StringBuilder();
            datosPersona.AppendFormat("\n {0}", base.MostrarDatos());

            foreach (Universidad.EClases clase in clasesDelDia)
            {
                datosPersona.AppendFormat("\n Clases del dia: {0}", clase);
            }

            return datosPersona.ToString();
        }

        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor p, Universidad.EClases clase)
        {
            return !(p == clase);
        }

        /// <summary>
        ///  Sobrecarga del operador == (Un profesor sera igual a una clase si el mismo dicta la clase)-
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor p, Universidad.EClases clase)
        {
            foreach (Universidad.EClases claseAux in p.clasesDelDia)
            {
                if (claseAux == clase)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Implementacion del metodo ParticiparEnClase(abstracto en su clase padre)
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder datosPersona = new StringBuilder();

            foreach (Universidad.EClases clase in clasesDelDia)
            {
                datosPersona.AppendFormat("\n CLASES DEL DIA: {0}", clase);
            }

            return datosPersona.ToString();
        }

        /// <summary>
        /// Constructor de la clase Profesor
        /// </summary>
        public Profesor()
        {

        }

        /// <summary>
        /// Constructor estatico que instancia a Random.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor de instancia que inicializa ClasesDelDia y asigna dos clases al azar al Profesor
        /// mediante el método randomClases.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Sobrecarga del ToString(), que publica los datos del profesor reutilizando el metodo mostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

    }
}
