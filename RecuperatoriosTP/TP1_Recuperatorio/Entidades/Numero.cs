using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Propiedad que setea un numero(antes validado) al atributo numero.
        /// </summary>
        private string SetNumero
        {
            set
            {
                double numeroValidado = ValidarNumero(value);
                this.numero = numeroValidado;
            }
        }
        /// <summary>
        /// Constructor por defecto, setea al atributo numero con 0.
        /// </summary>

        public Numero() : this(0)
        {
            
        }

        /// <summary>
        /// Constructor que setea el atributo número con el valor recibido por párametro
        /// </summary>
        /// <param name="numero"></param>

        public Numero(double numero) : this(numero.ToString()) 
        {

        }

        /// <summary>
        /// Constructor que setea el atributo número con el valor recibido por párametro
        /// </summary>
        /// <param name="strnumero"></param>

        public Numero(string strnumero)
        {
            this.SetNumero = strnumero;
        }

        /// <summary>
        /// Metodo que recibe un numero binario de tipo string  y lo transforma a un numero decimal de tipo string.
        /// </summary>
        /// <param name="binario">string con el numero binario</param>
        /// <returns>Retorna el numero decimal de tipo string.</returns>

        public string BinarioDecimal(string binario)
        {
            string resultado;
            char[] array = binario.ToCharArray();
            if (array[0] != '-')
            {
                Array.Reverse(array);
                int suma = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        suma += (int)Math.Pow(2, i);
                    }
                }
                resultado = suma.ToString();
                return resultado;
            }
            else
            {
                resultado = "Valor Invalido";
                return resultado;
            }
        }

        /// <summary>
        /// Recibe un numero decimal de tipo double y lo convierte a binario de tipo string
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Retorna el numero recibido por parametro ya convertido, caso contrario retorna "Valor Invalido".</returns

        public string DecimalBinario(double numero)
        {
            string cadena;

            if (numero > 0)
            {
                cadena = "";
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        cadena = "0" + cadena;
                    }
                    else
                    {
                        cadena = "1" + cadena;
                    }
                    numero = (int)(numero / 2);
                }
                return cadena;
            }
            else
            {
                if (numero == 0)
                {
                    cadena = "0";
                }
                else
                {
                    cadena = "Valor Invalido";
                    Console.ReadLine();
                }
                return cadena;
            }
        }

        /// <summary>
        /// Recibe un numero decimal de tipo string y lo convierte a binario de tipo string.
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Retorna el numero recibido por parametro ya convertido, caso contrario retorna "Valor Invalido"</returns

        public string DecimalBinario(string numero)
        {
            string cadena;
            double numeroDecimal;

            if (Double.TryParse(numero, out numeroDecimal))
            {
                if (numeroDecimal > 0)
                {
                    cadena = "";
                    while (numeroDecimal > 0)
                    {
                        if (numeroDecimal % 2 == 0)
                        {
                            cadena = "0" + cadena;
                        }
                        else
                        {
                            cadena = "1" + cadena;
                        }
                        numeroDecimal = (int)(numeroDecimal / 2);
                    }
                }
                else
                {
                    if (numeroDecimal == 0)
                    {
                        cadena = "0";
                    }
                    else
                    {
                        cadena = "Valor Invalido";
                    }
                }
                return cadena;
            }
            else
            {
                cadena = "Valor Invalido";
                return cadena;
            }

        }

        /// <summary>
        /// Verifica que el valor que se recibe sea numérico.Caso contrario, retorna 0.
        /// </summary>
        /// <param name="strNumero">Numero a validar de tipo string</param>
        /// <returns>Numero validado de tipo double</returns>

        private static double ValidarNumero(string strNumero)
        {
            double numeroValido;

            if (Double.TryParse(strNumero, out numeroValido))
            {
                return numeroValido;
            }
            else
            {
                numeroValido = 0;
                return numeroValido;

            }
        }

        /// <summary>
        ///  //Sobrecarga del operador '-' para poder restar dos objetos del tipo Numero.
        /// </summary>

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        ///  //Sobrecarga del operador '*' para poder multiplicar dos objetos del tipo Numero.
        /// </summary>

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        ///  //Sobrecarga del operador '/' para poder dividir dos objetos del tipo Numero.
        /// </summary>

        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            else
            {
                return double.MinValue;
            }
            
        }

        /// <summary>
        ///  //Sobrecarga del operador '+' para poder sumar dos objetos del tipo Numero.
        /// </summary>

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

    }
}
