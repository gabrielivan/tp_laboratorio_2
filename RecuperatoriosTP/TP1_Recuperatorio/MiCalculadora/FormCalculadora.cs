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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Boton: "Operar", Opera con el metodo Operar de la clase MiCalculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = 0;

            resultado = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            lblResultado.Text = Convert.ToString(resultado);

        }

        /// <summary>
        /// Boton: "Limpiar", Limpia la calculadora, vaciando los campos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }

        /// <summary>
        /// Boton: "Cerrar", Cierra la calculadora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Boton: "Convertir a Binario", Calcula la operacion llamando al metodo DecimalBinario de la clase Numero.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            if (lblResultado.Text != "")
            {
                lblResultado.Text = numero.DecimalBinario(lblResultado.Text);
            }
        }

        /// <summary>
        /// Boton: "Convertir a Decimal", Calcula la operacion llamando al metodo BinarioDecimal de la clase Numero.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            if (lblResultado.Text != "")
            {
                lblResultado.Text = numero.BinarioDecimal(lblResultado.Text);
            }
        }

        /// <summary>
        /// Calcula la operacion llamando al metodo Operar de la clase Calculadora
        /// </summary>
        /// <param name="numero1">Parametro de tipo string que se le envia al metodo Operar de la clase Calculadora</param>
        /// <param name="numero2">Parametro de tipo string que se le envia al metodo Operar de la clase Calculadora</param>
        /// <param name="operador">Parametro de tipo string que se le envia al metodo Operar de la clase Calculadora</param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero numeroUno = new Numero(numero1);
            Numero numeroDos = new Numero(numero2);
            double resultado = Calculadora.Operar(numeroUno, numeroDos, operador);
            return resultado;
        }
    }
}
