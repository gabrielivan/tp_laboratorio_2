using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public NacionalidadInvalidaException() : this("La nacionalidad no coincide con el numero del Dni")
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public NacionalidadInvalidaException(string message) : base(message)
        {

        }
    }
}
