
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        public enum TipoLeche
        {
            Entera,
            Descremada
        }

        private TipoLeche tipoLeche;

        /// <summary>
        /// Constructor que setea a sus atributos con los valores recibidos por parametro, con la diferencia que el tipoDeLeche es Entera por Defecto.
        /// </summary>
        /// <param name="marca">valor a setear en el atributo marca</param>
        /// <param name="codigoDeBarras">valor a setear en el atributo codigoDeBarras</param>
        /// <param name="color">valor a setear en el atributo colorPrimarioEmpaque</param>
        public Leche(MarcaProducto marca, string codigoDeBarras, ConsoleColor color) : this(marca, codigoDeBarras, color, TipoLeche.Entera)
        {

        }

        /// <summary>
        /// Constructor que setea a sus atributos con los valores recibidos por parametro.
        /// </summary>
        /// <param name="marca">valor a setear en el atributo marca</param>
        /// <param name="codigoDeBarras">valor a setear en el atributo codigoDeBarras</param>
        /// <param name="color">valor a setear en el atributo colorPrimarioEmpaque</param>
        /// /// <param name="tipoLeche">valor a setear en el atributo tipoLeche</param>
        public Leche(MarcaProducto marca, string codigoDeBarras, ConsoleColor color, TipoLeche tipoLeche) : base(codigoDeBarras, marca, color)
        {
            this.tipoLeche = tipoLeche;
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Muestra todos los datos de la clase Leche.
        /// </summary>
        /// <returns>Retornara un String con los datos de la clase Leche</returns>
        public override string Mostrar()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine("LECHE");
            datos.AppendLine(base.Mostrar());
            datos.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            datos.AppendLine("TIPO : " + this.tipoLeche);
            datos.AppendLine("");
            datos.AppendLine("---------------------");

            return datos.ToString();
        }
    }
}
