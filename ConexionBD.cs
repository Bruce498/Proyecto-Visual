using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Visual
{
    class ConexionBD
    {

        string cadena = "Data Source = DESKTOP-IKAKVR4; Initial Catalog=VeterinariaPetVet; Integrated Security=True";
        public SqlConnection conectarbd = new SqlConnection();

        public ConexionBD()
        {
            conectarbd.ConnectionString = cadena;
        }

        public void abrir()
        {
            try
            {
                conectarbd.Open();
                //Console.Write("Conexion Abierta");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la base de Datos" + ex.Message);
            }
        }

        public void cerrar()
        {
            conectarbd.Close();
        }

        public List<string> Seleccionar(string nombre)
        {
            string sqlSelect = "select * from Cliente where Nombre = '" + nombre + "'";

            List<string> listaNombres = new List<string>();


            var comm = new SqlCommand
            {
                Connection = conectarbd,
                CommandType = CommandType.Text,
                CommandText = sqlSelect,
            };
            try
            {
                SqlDataReader r = comm.ExecuteReader();

                while (r.Read())
                {

                    string nombreRecibido = r["Nombre"].ToString();

                    string apellido = r["Apellido"].ToString();


                    listaNombres.Add(nombreRecibido);

                    // Acá se obtienen los datos del Reader, lo que devuelve la Base de Datos de esa consulta
                }

                return listaNombres;
            }
            catch (Exception ex)
            {

            }
            return listaNombres;
        }





    }
}
