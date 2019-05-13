using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {

        /// <summary>
        /// Constructor que setea a sus atributos con los valores recibidos por parametro.
        /// </summary>
        /// <param name="marca">valor a setear en el atributo marca</param>
        /// <param name="codigoDeBarras">valor a setear en el atributo codigoDeBarras</param>
        /// <param name="color">valor a setear en el atributo colorPrimarioEmpaque</param>
        public Snacks(MarcaProducto marca, string codigoDeBarras, ConsoleColor color) : base(codigoDeBarras, marca, color)
        {

        }
        
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }


        /// <summary>
        /// Muestra todos los datos de la clase Snacks.
        /// </summary>
        /// <returns>Retornara un String con los datos de la clase Snacks</returns>
        public override sealed string Mostrar()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine("SNACKS");
            datos.AppendLine(base.Mostrar());
            datos.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            datos.AppendLine("");
            datos.AppendLine("---------------------");

            return datos.ToString();
        }
    }
}
