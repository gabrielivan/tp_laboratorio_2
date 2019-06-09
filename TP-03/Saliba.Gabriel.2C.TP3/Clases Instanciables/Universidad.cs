using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

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
        public List<Profesor> Instructores
        {
            get
            {
                return profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Indexador de Jornada devuelve la Jornada en [i]
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                return jornada[i];
            }
            set
            {
                jornada[i] = value;
            }
        }

        /// <summary>
        /// Guardar es un metodo de clase, serializa los datos de la Universidad en un XML
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad universidad)
        {
            Xml<Universidad> textoUnivesidad = new Xml<Universidad>();
            return textoUnivesidad.Guardar("Universidad.xml", universidad);
        }

        /// <summary>
        /// Leer es un metodo de clase, retorna una Universidad con todos los datos serializados. 
        /// </summary>
        /// <returns></returns>
        public Universidad Leer()
        {
            Xml<Universidad> readerImporter = new Xml<Universidad>();
            Universidad retorno;
            readerImporter.Leer("Universidad.xml", out retorno);
            return retorno;
        }

        /// <summary>
        /// Muestra los datos de cada jornada en la lista de jornadas
        /// </summary>
        /// <param name="universidad"></param>
        /// <returns></returns>
        protected string MostrarDatos(Universidad universidad)
        {
            StringBuilder datosUniversidad = new StringBuilder();

            foreach (Jornada jornada in universidad.jornada)
            {
                datosUniversidad.AppendLine("\n" + jornada);
            }

            return datosUniversidad.ToString();
        }

        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad universidad, Alumno alumno)
        {
            return !(universidad == alumno);
        }

        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad universidad, Profesor profesor)
        {
            return !(universidad == profesor);
        }

        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad universidad, EClases clase)
        {
            foreach (Profesor profesorAux in universidad.profesores)
            {
                if (profesorAux != clase)
                {
                    return profesorAux;
                }
            }
            return null;
        }

        /// <summary>
        /// Sobrecarga del operador ==
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad universidad, Alumno alumno)
        {
            foreach (Alumno alumnoAux in universidad.alumnos)
            {
                if (alumno == alumnoAux)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga del operador ==
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad universidad, Profesor profesor)
        {
            foreach (Profesor profesorAux in universidad.profesores)
            {
                if (profesor == profesorAux)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga del operador ==
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad universidad, EClases clase)
        {
            foreach (Profesor profesorAux in universidad.profesores)
            {
                if (profesorAux == clase)
                {
                    return profesorAux;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Sobrecarga del operador +
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad universidad, EClases clase)
        {
            Jornada jornadaAux = new Jornada(clase, (universidad == clase));
            foreach (Alumno alumnoAux in universidad.alumnos)
            {
                if (alumnoAux == clase)
                {
                    jornadaAux.Alumnos.Add(alumnoAux);
                }
            }
            universidad.jornada.Add(jornadaAux);
            return universidad;
        }

        /// <summary>
        /// Sobrecarga del operador +
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad universidad, Alumno alumno)
        {
            if (universidad != alumno)
            {
                universidad.alumnos.Add(alumno);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return universidad;
        }

        /// <summary>
        /// Sobrecarga del operador +
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad universidad, Profesor profesor)
        {
            if (universidad != profesor)
            {
                universidad.profesores.Add(profesor);
            }
            return universidad;
        }

        /// <summary>
        /// Sobrecarga del metodo ToString() reutiliza el metodo MostrarDatos()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        /// <summary>
        /// Constructor de instancia, inicializa todas las listas
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }

        /// <summary>
        /// Enumerado de las clases
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}
