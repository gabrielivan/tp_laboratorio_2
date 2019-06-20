using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        Correo correo;

        public FrmPpal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Método ActualizarEstados, limpia los 3 ListBox y luego recorre
        /// la lista de paquetes agregando cada uno de ellos en el listado que corresponda.
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete pqt in this.correo.Paquetes)
            {
                if (pqt.Estado == Paquete.EEstado.Ingresado)
                {
                    lstEstadoIngresado.Items.Add(pqt);
                }
                else if (pqt.Estado == Paquete.EEstado.EnViaje)
                {
                    lstEstadoEnViaje.Items.Add(pqt);
                }
                else if((pqt.Estado == Paquete.EEstado.Entregado))
                {
                    lstEstadoEntregado.Items.Add(pqt);
                }
            }
        }

        /// <summary>
        /// Al cerrarse el formulario, llama al método FinEntregas con el fin de cerrar todos los hilos abiertos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// Mostrará los datos del parametro "elemento" en el rtbMostrar.
        /// Utiliza el método de extensión para guardar los datos en un archivo llamado salida.txt.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            //se crea la ruta del archivo.
            string rutaArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\salida.txt";

            if (elemento != null)//pregunta que el elemnto no sea null
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    GuardaString.Guardar(this.rtbMostrar.Text, rutaArchivo);
                }
                catch(Exception e)//Si ocurre algun error en el intento de guardar el archivo capturo la excepcion.
                {
                    MessageBox.Show(e.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);//muestro la excepcion
                }
                
            }
        }

        /// <summary>
        /// El evento click del botón btnAgregar realiza las siguientes acciones con el siguiente orden:
        /// Crea un nuevo paquete y asocia al evento InformaEstado el método paq_InformaEstado.
        /// Agrega el paquete al correo, controlando las excepciones que puedan derivar de dicha acción.
        /// Llama al método ActualizarEstados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete paqueteNuevo = new Paquete(textBoxDireccion.Text, maskedTextBoxTrackingID.Text);//crea un nuevo paquete
                paqueteNuevo.InformarEstado += paq_InformarEstado;//asocia el evento(InformarEstado) al manejador de eventos(paq_InformarEstado).
                paqueteNuevo.InformarSQlException += informar_SQLException;//asocia el evento(InformarSQlException) al manejador de eventos(informar_SQLException).
                correo += paqueteNuevo;//Agrega el paquete nuevo a la lista de paquetes de la clase correo
                ActualizarEstados(); //actualiza los estados con el metodo ActualizarEstados().
            }
            catch (TrackingIdRepetidoException exception) // Captura la posible excepcion de que un paquete tenga el mismo TrackingId que otro paquete.
            {
                MessageBox.Show(exception.Message,"Paquete repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

        }

        /// <summary>
        /// Metodo que muestra en el rtbMostrar, todos los paquetes de la lista de paquetes de la clase correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Manejador del evento InformarEstado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformarEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformarEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        /// <summary>
        /// Manejador del evento InformarSQlException
        /// </summary>
        /// <param name="paquete"></param>
        /// <param name="exception"></param>
        private void informar_SQLException(object paquete, Exception exception)
        {
            MessageBox.Show(string.Format("Se ha producido un error en la carga de datos del paquete: {0} \n Mas informacion: \n {1}", paquete.ToString(), exception.Message),
                "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Instancia un nuevo correo
        /// Deshabilita el rtbMostrar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_Load(object sender, EventArgs e)
        {
            this.correo = new Correo();
            rtbMostrar.Enabled = false;
        }

        /// <summary>
        /// Metodo que muestra el paquete que se le hizo click derecho, en el rtbMostrar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
