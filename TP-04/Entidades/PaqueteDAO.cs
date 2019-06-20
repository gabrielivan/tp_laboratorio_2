using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    static class PaqueteDAO
    {
        static SqlCommand comando;
        static SqlConnection conexion;

        static PaqueteDAO()
        {
            string connectionStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=correo-sp-2017; Integrated Security = True";

            try
            {
                conexion = new SqlConnection(connectionStr);
                comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexion;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Metodo estatico, inserta un paquete en la tabla Paquetes
        /// Con los valores correspondientes
        /// El campo alumno de la base de datos deberá contener el nombre del alumno que está realizando el TP.
        /// </summary>
        /// <param name="pqt"></param>
        /// <returns></returns>
        public static bool InsertarPaquete(Paquete pqt)
        {
            bool respuesta = false;

            try
            {
                string insertarPersona = String.Format("INSERT INTO Paquetes (direccionEntrega, trackingid, alumno) VALUES ('{0}','{1}','{2}')", pqt.DireccionEntrega, pqt.TrackingID, "Saliba Gabriel");
                comando.CommandText = insertarPersona;
                conexion.Open();
                comando.ExecuteNonQuery();
                respuesta = true;
            }

            catch (Exception e)
            {
                throw e;
            }

            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return respuesta;
        }
    }
}
