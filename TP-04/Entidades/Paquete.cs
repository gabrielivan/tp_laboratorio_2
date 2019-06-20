using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;

namespace Entidades 
{
    public class Paquete : IMostrar<Paquete> //Implementa la interface IMostrar, siendo su tipo genérico Paquete.
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public delegate void DelegadoSQLException(object paquete, Exception exception);

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        /// <summary>
        /// Contructor de clase, instancia los atributos con los valores recibidos por parametro.
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }

        /// <summary>
        /// Propiedad de lectura y escritura.
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura.
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura.
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        /// <summary>
        /// Metodo que cambia de estado el paquete.
        /// Coloca una demora de 4 segundos, luego pasa el paquete al siguiente estado.
        /// Informa el estado a través del evento InformarEstado, EventArgs no tendrá ningún dato extra.
        /// Repite estas acciones hasta que el estado sea Entregado
        /// Finalmente guardar los datos del paquete en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.Estado < EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado = EEstado.EnViaje;
                this.InformarEstado(this, null);
                Thread.Sleep(4000);
                this.Estado = EEstado.Entregado;
                this.InformarEstado(this, null);

                try
                {
                    PaqueteDAO.InsertarPaquete(this);
                }
                catch (Exception exception)
                {
                    this.InformarSQlException(this, exception); //Informa el error atraves del evento InformarSQlException
                }
            }
        }

        /// <summary>
        ///  Metodo MostrarDatos, utiliza string.Format con el siguiente formato 
        /// "{0} para {1}", p.trackingID, p.direccionEntrega para compilar la información del paquete.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
           return string.Format("{0} para {1} \n", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }

        /// <summary>
        /// Sobrecarga del método ToString que retorna la información del paquete.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Sobrecarga del operador != 
        /// Dos paquetes son distintos si su TrackingID no es igual.
        /// </summary>
        /// <param name="pqt1"></param>
        /// <param name="pqt2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete pqt1, Paquete pqt2)
        {
            return !(pqt1 == pqt2);
        }

        /// <summary>
        /// Sobrecarga del operador == 
        /// Dos paquetes son iguales si su TrackingID es igual.
        /// </summary>
        /// <param name="pqt1"></param>
        /// <param name="pqt2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete pqt1, Paquete pqt2)
        {
            bool retorno = false;
            if (pqt1.TrackingID == pqt2.TrackingID)
            {
                retorno = true;
            }
            return retorno;
        }

        public event DelegadoEstado InformarEstado;
        public event DelegadoSQLException InformarSQlException;

        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
    }
}
