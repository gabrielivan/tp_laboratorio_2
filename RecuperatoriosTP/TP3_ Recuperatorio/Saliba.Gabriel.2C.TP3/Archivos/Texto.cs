﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        StreamWriter streamWriter;
        StreamReader streamReader;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                streamWriter = new StreamWriter(archivo, true); // si append es true, se agregarán datos al archivo exis
                streamWriter.WriteLine(datos); //Escribe los datos en el archivo provocando salto de línea.
                return true;
            }
            catch (Exception exception)
            {
                throw new ArchivosException(exception);
            }
            finally
            {
                //Cierro conexion con el archivo
                streamWriter.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                streamReader = new StreamReader(archivo); //Especifico de donde leo los datos.

                datos = streamReader.ReadToEnd(); //Lee todo el archivo hasta el final 
                                                  //y lo retorna como una cadena de caracteres al parametro recibido (datos).

                return true;
            }
            catch (Exception exception)
            {
                throw new ArchivosException(exception);
            }
            finally
            {
                //Cierro conexion con el archivo
                streamReader.Close();
            }
        }
    }
}
