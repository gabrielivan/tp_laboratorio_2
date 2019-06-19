using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Metodo Validar Operador, se usa para que el operador que ingresa el usuario sea valido.
        /// Si no es valido retorna +.
        /// </summary>
        /// <param name="operador">Es el operador a validar.</param>
        /// <returns>Operador ya validado.</returns>

        private static string ValidarOperador(string operador)
        {
            string resultado = "";
            if (operador == "*" || operador == "/" || operador == "+" || operador == "-")
            {
                resultado = operador;
            }
            else
            {
                resultado = "+";
            }
            return resultado;
        }

        /// <summary>
        /// Metodo Operar, se usa para realizar calculos.
        /// </summary>
        /// <param name="num1">Numero que se recibe para operar.</param>
        /// <param name="num2">Numero que se recibe para operar.</param>
        /// <param name="operador">Operador a utilizar.</param>
        /// <returns>Resultado de la operacion solicitada.</returns>

        public static double Operar(Numero num1, Numero num2, string operador)
        {
            string operadorValidado = ValidarOperador(operador);
            double resultado = 0;

            switch (operadorValidado)
            {
                case "+":
                    {
                        resultado = num1 + num2;
                        break;
                    }
                case "-":
                    {
                        resultado = num1 - num2;
                        break;
                    }
                case "*":
                    {
                        resultado = num1 * num2;
                        break;
                    }
                case "/":
                    {
                        resultado = num1 / num2;
                        break;
                    }
            }
            return resultado;
        }
    }
}
