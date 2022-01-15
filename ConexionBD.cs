using Proyecto_Final;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Visual
{
    class ConexionBD
    {
        //***CONEXION A LA BASE DE DATOS***

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
                MessageBox.Show("Conexion Abierta");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la base de Datos" + ex.Message);
            }
        }

        public void cerrar()
        {
            conectarbd.Close();
        }


        //***CONSULTAR DATOS***

        public List<Consultar_Datos> Seleccionar()
        {
            string sqlSelect = "SELECT [Nombre]" + ",[SegundoNombre]," + "[Apellido]" + ",[CedulaIdentidad]," + "[CuentaBancaria]," + "[Direccion]," + "[Telefono]," + "[Ciudad]," + 
                               "[IdCliente] FROM [VeterinariaPetVet].[dbo].[Cliente]";


            List<Consultar_Datos> listadatos = new List<Consultar_Datos>();


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
                    Consultar_Datos consultar_Datos = new Consultar_Datos();
                   
                    consultar_Datos.nombre = r ["Nombre"].ToString();
                    consultar_Datos.segundonombre = r ["SegundoNombre"].ToString();
                    consultar_Datos.apellido = r ["Apellido"].ToString();
                    consultar_Datos.direccion = r ["Direccion"].ToString();
                    consultar_Datos.ciudad = r ["Ciudad"].ToString();
                    consultar_Datos.CuentaBancaria = int.Parse(r["CuentaBancaria"].ToString());
                    CedulaIdentidad = int.Parse(r["CedulaIdentidad"].ToString();
                    consultar_Datos.telefono = int.Parse(r["telefono"].ToString());


                    listadatos.Add(consultar_Datos); // devuelve los datos en una lista

                    // Acá se obtienen los datos del Reader, lo que devuelve la Base de Datos de esa consulta
                }

                return listadatos;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        // INSERTAR SOCIO
        public bool AgregarSocio(AgegarSocio insertarsocio)
        {

            string sqlInsert = "INSERT INTO [dbo].[Cliente] ([Nombre] ,[SegundoNombre] ," +
                                                             "[Apellido],[CedulaIdentidad]," +
                                                             "[CuentaBancaria],[Direccion]," +
                                                             "[Telefono],[Ciudad]) " +
                                "VALUES (@nombre, @segundoNombre, @apellido, " +
                                        "@ci, @cuentaBancaria, @direccion, @telefono, @ciudad)";


            var conn = new SqlConnection(cadena);


            conn.Open();
            var comm = new SqlCommand
            {
                Connection = conn,
                CommandType = CommandType.Text,
                CommandText = sqlInsert,
            };

            comm.Parameters.AddWithValue("nombre", insertarsocio.nombre);
            comm.Parameters.AddWithValue("segundoNombre", insertarsocio.segundoNombre);
            comm.Parameters.AddWithValue("apellido", insertarsocio.apellido);
            comm.Parameters.AddWithValue("ci", insertarsocio.cedula);
            comm.Parameters.AddWithValue("cuentaBancaria", insertarsocio.cuentabancaria);
            comm.Parameters.AddWithValue("direccion", insertarsocio.direccion);
            comm.Parameters.AddWithValue("telefono", insertarsocio.telefono);
            comm.Parameters.AddWithValue("ciudad", insertarsocio.ciudad);


            // Ejecuto la Query (la consulta)
            // Si el resultado es OK, se insertó correctamente, sino, hubo un ERROR
            try
            {
                int r = comm.ExecuteNonQuery();
                return r > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        //MODIFICAR SOCIO
        public bool ModificarSocio(ModificarSocio modificar)
        {
            var conn = new SqlConnection(cadena);
            var comm = new SqlCommand
            {
                Connection = conn,
                CommandType = CommandType.Text,
            };

            string sql = "update Cliente set ";
            string where = " WHERE CedulaIdentidad = @cedula";

            comm.Parameters.AddWithValue("cedula", modificar.cedula);

            if (!string.IsNullOrEmpty(modificar.ciudad))
            {
                sql += " Ciudad = @ciudad,";
                comm.Parameters.AddWithValue("ciudad", modificar.ciudad);
            }

            if (modificar.cuentabancaria != 0)
            {
                sql += " CuentaBancaria = @cuentabancaria,";
                comm.Parameters.AddWithValue("cuentabancaria", modificar.cuentabancaria);
            }

            if (!string.IsNullOrEmpty(modificar.direccion))
            {
                sql += " Direccion = @direccion,";
                comm.Parameters.AddWithValue("direccion", modificar.direccion);
            }

            sql = sql.Substring(0, sql.Length - 1) + where;

            comm.CommandText = sql;
            conn.Open();

            // Ejecuto la Query (la consulta)
            // Si el resultado es OK, se intertó correctamente, sino, hubo un ERROR
            try
            {
                int r = comm.ExecuteNonQuery();
                return r > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        //ELIMINAR SOCIO

        public void EliminarSocio (EliminarSocio eliminarSocio)
        {

            string sqlDelete = "DELETE from [dbo].[Cliente] where CedulaIdentidad = @ci";
            
            var conn = new SqlConnection(cadena);


            conn.Open();
            var comm = new SqlCommand
            {
                Connection = conn,
                CommandType = CommandType.Text,
                CommandText = sqlDelete,
            };

           
            comm.Parameters.AddWithValue("ci", eliminarSocio.cedula);
            


            // Ejecuto la Query (la consulta)
            // Si el resultado es OK, se intertó correctamente, sino, hubo un ERROR
            try
            {
                int r = comm.ExecuteNonQuery();
                if (r > 0)
                {
                    MessageBox.Show("Datos elimnados correctamente");
                }
                else
                {
                    MessageBox.Show("Error al eliminar los datos");
                }
            }   
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar los datos" + ex.Message); // error tecnico de la base de datos (roptura de la tablas, error de clave foranea)
                
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        //CONSULTAR MASCOTA

        public List<Seleccionarmascota> Seleccionarmascota(string cedulaidentidad)
        {
            //a.* muestra todos los datos de la tabla animal
            string sqlSelect = "SELECT a.* from [dbo].[Cliente] C inner join Animal A on c.IdCliente = a.IdCliente where c.cedulaidentidad = @ci"; 
           
            List<Seleccionarmascota> listaDatos = new List<Seleccionarmascota>();

            
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

                    Seleccionarmascota Datos = new Seleccionarmascota();

                    Datos.nombre = r["Nombre"].ToString();
                    Datos.especie = r["Especie"].ToString();
                    Datos.raza = r["Raza"].ToString();
                    Datos.color = r["Color"].ToString();
                    Datos.FechaNacimiento = int.Parse(r["FechaNacimiento"].ToString());


                    listaDatos.Add(Datos);

                    // Acá se obtienen los datos del Reader, lo que devuelve la Base de Datos de esa consulta
                }

                return listaDatos;
            }
            catch (Exception ex)
            {

            }
            return listaDatos;
        }

        // INSERTAR MASCOTA

        public void Agregarmascota()
        {

            Agregarmascota insertarmascota = new Agregarmascota();

            




            var conn = new SqlConnection("Data Source = DESKTOP-IKAKVR4; Initial Catalog=VeterinariaPetVet; Integrated Security=True");


            conn.Open();
            var comm = new SqlCommand
            {
                Connection = conn,
                CommandType = CommandType.Text,
                CommandText = string.Empty,
            };


            // Ejecuto la Query (la consulta)
            // Si el resultado es OK, se insertó correctamente, sino, hubo un ERROR
            try
            {
                int r = comm.ExecuteNonQuery();
                string resultado;
                if (r > 0)
                {
                    resultado = "Datos insertados correctamente";
                }
                else
                {
                    resultado = "Error al insertar los datos";
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }
        public void Eliminarmascota()
        {

            Eliminarmascota mascota = new Eliminarmascota();

            //Hacer la consulta para saber que animal corresponde al socio

            mascota.cedulaidentidad = 42144468;
            mascota.idanimal = 1;


            string sqlDelete = "Delete Animal Set Animal = " + mascota.idanimal + mascota.cedulaidentidad;

            var conn = new SqlConnection("DESKTOP-IKAKVR4; Initial Catalog=VeterinariaPetVet; Integrated Security=True");


            conn.Open();
            var comm = new SqlCommand
            {
                Connection = conn,
                CommandType = CommandType.Text,
                CommandText = sqlDelete,
            };


            // Ejecuto la Query (la consulta)
            // Si el resultado es OK, se intertó correctamente, sino, hubo un ERROR
            try
            {
                int r = comm.ExecuteNonQuery();
                string resultado;
                if (r > 0)
                {
                    resultado = "Datos eliminados correctamente";
                }
                else
                {
                    resultado = "Error al eliminar los datos";
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

    }
}




