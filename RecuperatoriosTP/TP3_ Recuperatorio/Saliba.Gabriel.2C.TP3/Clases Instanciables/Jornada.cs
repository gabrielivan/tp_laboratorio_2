using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        /// <summary>
        /// Propiedad de lectura y escritura.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return alumnos;
            }
            set
            {
                this.alumnos = value;
            }

        }

        /// <summary>
        /// Propiedad de lectura y escritura.
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return clase;
            }
            set
            {
                this.clase = value;
            }

        }

        /// <summary>
        /// Propiedad de lectura y escritura.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        /// <summary>
        /// Metodo de clase Guardar, guarda los datos de la Jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
           Texto textoAux = new Texto();
            return textoAux.Guardar("Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Constructor privado, que inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de instacia, que inicializa todos los campos con los parametros recibidos
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        /// <summary>
        /// Metodo de clase que retorna los datos de la Jornada como texto
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            string textoYaLeido;
            Texto texto = new Texto();
            texto.Leer("Jornada.txt", out textoYaLeido);
            return textoYaLeido;
        }

        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega Alumnos a la clase por medio del operador +, validando previamente que no esten en la lista de alumnos.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }

        /// <summary>
        /// Sobrecarga del operador == entre jornada y alumno, 
        /// una Jornada será igual a un Alumno si el mismo participa de la clase
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            if (!(a != j.clase))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga del ToString muestra todos los datos de la Jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder datosJornada = new StringBuilder();
            datosJornada.AppendFormat("\n Clase: {0}", this.Clase);
            datosJornada.AppendFormat("\n Instructor: {0}", this.Instructor);

            foreach (Alumno alumnoAux in this.alumnos)
            {
                datosJornada.AppendFormat("\n Alumno: {0}", alumnoAux.ToString());
            }

            return datosJornada.ToString();
        }
    }
}
