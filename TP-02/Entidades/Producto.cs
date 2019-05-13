using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum MarcaProducto
        {
            Serenisima,
            Campagnola,
            Arcor,
            Ilolay,
            Sancor,
            Pepsico
        }

        private MarcaProducto marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;

        /// <summary>
        /// Constructor que setea los 3 atributos con los valores recibidos por parametro
        /// </summary>
        /// <param name="codigoDeBarras">es el valor a setear en el atributo codigoDeBarras</param>
        /// <param name="marca">es el valor a setear en el atributo marca</param>
        /// <param name="color">es el valor a setear en el atributo colorPrimarioEmpaque</param>
        public Producto(string codigoDeBarras, MarcaProducto marca, ConsoleColor color)
        {
            this.colorPrimarioEmpaque = color;
            this.marca = marca;
            this.codigoDeBarras = codigoDeBarras;
        }
        
        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias del producto
        /// </summary>
        protected abstract short CantidadCalorias { get; }

        /// <summary>
        /// Muestra todos los datos del Producto.
        /// </summary>
        /// <returns>Retornara un string con todos los datos del producto</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Convierte el producto reciibido en un string con todos sus datos
        /// </summary>
        /// <param name="producto">Producto a convertir</param>
        public static explicit operator string(Producto producto)
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendFormat("CODIGO DE BARRAS: {0}\r\n", producto.codigoDeBarras);
            datos.AppendFormat("MARCA          : {0}\r\n", producto.marca.ToString());
            datos.AppendFormat("COLOR EMPAQUE  : {0}\r\n", producto.colorPrimarioEmpaque.ToString());
            datos.AppendLine("---------------------");

            return datos.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="productoUno">Es el primer producto a comparar</param>
        /// <param name="productoDos">Es el segundo producto a comparar</param>
        /// <returns>Retornara True si son iguales o False en caso contrario</returns>
        public static bool operator ==(Producto productoUno, Producto productoDos)
        {
            return (productoUno.codigoDeBarras == productoDos.codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="productoUno">Es el primer producto a comparar</param>
        /// <param name="productoDos">Es el segundo producto a comparar</param>
        /// <returns>Retornara True si no son iguales o False en caso contrario</returns>
        public static bool operator !=(Producto productoUno, Producto productoDos)
        {
            return !(productoUno == productoDos);
        }
    }
}
