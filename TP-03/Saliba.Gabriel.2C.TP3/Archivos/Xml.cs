using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            //Objeto que escribirá en XML.
            XmlTextWriter XmlWriter = new XmlTextWriter(archivo, Encoding.UTF8); //Se indica ubicación del archivo XML y su codificación.

            //Se indica el tipo de objeto ha serializar.
            XmlSerializer objetoSerializador = new XmlSerializer(typeof(T));

            try
            {
                //Serializa el objeto de tipo <T> (datos) en el archivo contenido en Xmlwriter(archivo).

                objetoSerializador.Serialize(XmlWriter, datos); //se le manda el XmlWriter por que este contiene al archivo en donde se va a dejar el objeto serializado(datos).
                //Cierro la conexion con el archivo
                XmlWriter.Close();
                return true;
            }
            catch (ArchivosException exception)
            {
                XmlWriter.Close();
                throw exception.InnerException;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            //Objeto que leerá en XML.
            XmlTextReader XmlReader = new XmlTextReader(archivo);  //Se indica ubicación del archivo XML
            //Objeto que Deserializará.
            XmlSerializer objetoDeserializador = new XmlSerializer(typeof(T)); //Se indica el tipo de objeto ha Deserializar.
            try
            {
                //Deserializa el archivo contenido en XmlReader, lo guarda en datos
                datos = (T)objetoDeserializador.Deserialize(XmlReader);
                //Cierro conexion con el archivo
                XmlReader.Close();
                return true;
            }
            catch (ArchivosException exception)
            {
                XmlReader.Close();
                throw exception.InnerException;

            }
        }
    }
}
