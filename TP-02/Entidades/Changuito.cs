using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        private List<Producto> productos;
        private int espacioDisponible;

        public enum TipoProducto
        {
            Dulce,
            Leche,
            Snacks,
            Todos
        }

        #region "Constructores"

        /// <summary>
        /// Constructor que inicializa la lista de productos.
        /// </summary>
        /// <param name="espacioDisponible">valor a setear</param>
        private Changuito()
        {
            this.productos = new List<Producto>();
        }

        /// <summary>
        /// Constructor que setea al atributo espacioDisponible el valor recibido por parametro.
        /// </summary>
        /// <param name="espacioDisponible">valor a setear</param>
        public Changuito(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns>Retornara un string con todos los datos de esta clase y todos sus productos</returns>
        public override string ToString()
        {
            return Mostrar(this, TipoProducto.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="chango">Elemento a exponer</param>
        /// <param name="tipoProducto">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito chango, TipoProducto tipoProducto)
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", chango.productos.Count, chango.espacioDisponible);
            datos.AppendLine("");
            foreach (Producto producto in chango.productos)
            {
                switch (tipoProducto)
                {
                    case TipoProducto.Snacks:
                        if (producto is Snacks)
                        {
                            datos.AppendLine(producto.Mostrar());
                        }
                        break;

                    case TipoProducto.Dulce:
                        if(producto is Dulce)
                        {
                            datos.AppendLine(producto.Mostrar());
                        }
                        break;

                    case TipoProducto.Leche:
                        if (producto is Leche)
                        {
                            datos.AppendLine(producto.Mostrar());
                        }
                        break;

                    default:
                        datos.AppendLine(producto.Mostrar());
                        break;
                }
            }

            return datos.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="chango">Objeto donde se agregará el elemento</param>
        /// <param name="producto">Objeto a agregar</param>
        /// <returns>Retornara el chango ya sea si agrego el producto a la lista o no.</returns>
        public static Changuito operator +(Changuito chango, Producto producto)
        {
            bool canAdd = true;

            if (chango != null && !producto.Equals(null))
            {
                foreach (Producto productoAux in chango.productos)
                {
                    if (productoAux.Equals(null) || producto == productoAux)
                    {
                        canAdd = false;
                        break;
                    }
                }
                if (canAdd && chango.productos.Count < chango.espacioDisponible)
                {
                    chango.productos.Add(producto);
                }
                    
            }

            return chango;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="chango">Objeto donde se quitará el elemento</param>
        /// <param name="producto">Objeto a quitar</param>
        /// <returns>Retornara el chango ya sea si se quito el producto a la lista o no</returns>
        public static Changuito operator -(Changuito chango, Producto producto)
        {
            foreach (Producto productoAux in chango.productos)
            {
                if (producto == productoAux)
                {
                    chango.productos.Remove(producto);
                    return chango;
                }
            }

            return chango;
        }
        #endregion
    }
}
