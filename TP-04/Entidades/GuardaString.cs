using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        static StreamWriter streamWriter;

        /// <summary>
        /// Metodo de extencion para la clase String.
        /// Guarda el archivo de texto recibido en el escritorio de la maquina
        /// Si el archivo existe, agrega informancion en el mismo
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            try
            {
                streamWriter = new StreamWriter(archivo, true);// si append es true, se agregarán datos al archivo existente
                streamWriter.WriteLine(texto);//Escribe los datos en el archivo provocando salto de línea.
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                streamWriter.Close();//Cierro conexion con el archivo
            }
        }
    }
}
