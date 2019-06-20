using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        /// <summary>
        /// Constructor de clase, que instancia las listas.
        /// </summary>
        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Propiedad de lectura y escritura.
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        
        /// <summary>
        /// Metodo que cierra todos los hilos activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread tAux in mockPaquetes)
            {
                if (tAux.IsAlive)
                {
                    tAux.Abort();
                }
            }
        }

        /// <summary>
        /// Expone la informacion de los paquetes que hay dentro de la clase Correo.
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string datos = "";
            foreach (Paquete pqtAux in ((Correo)elementos).Paquetes)
            {
                datos += string.Format("{0} para {1} ({2}) \n", pqtAux.TrackingID, pqtAux.DireccionEntrega, pqtAux.Estado.ToString());
            }
            return datos;
        }

        /// <summary>
        /// Sobrecarga del operador + 
        /// Controla si el paquete ya está en la lista. Si esta, 
        /// se lanzará la excepción TrackingIdRepetidoException.
        /// si no esta, agrega el paquete a la lista de paquetes.
        /// Crea un hilo para el método MockCicloDeVida del paquete, y agrega dicho hilo a mockPaquetes.
        /// por ultimo Ejecuta el hilo.
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="paquete"></param>
        /// <returns></returns>
        public static Correo operator +(Correo correo, Paquete paquete)
        {
            foreach (Paquete pqtAux in correo.paquetes)
            {
                if (paquete == pqtAux)
                {
                    throw new TrackingIdRepetidoException(string.Format("El Tracking ID {0} ya figura en la lista de envios.", paquete.TrackingID));
                }
            }

            correo.paquetes.Add(paquete);//se agrega el paquete a la lista.

            Thread MockCicloDeVidaHilo = new Thread(paquete.MockCicloDeVida);//Se instancia el hilo
            correo.mockPaquetes.Add(MockCicloDeVidaHilo);//agrega dicho hilo a la lista de hilos
            MockCicloDeVidaHilo.Start();//ejecuta el hilo

            return correo;
        }
    }
}
