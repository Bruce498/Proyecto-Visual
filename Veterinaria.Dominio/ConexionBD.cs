using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Veterinaria.Dominio
{
    public class ConexionBD
    {
        private string cadena = "Data Source = DESKTOP-IKAKVR4; Initial Catalog=VeterinariaPetVet; Integrated Security=True";
        private SqlConnection conectarbd = new SqlConnection();

        public ConexionBD()
        {
            conectarbd.ConnectionString = cadena;
        }

        public void Cerrar()
        {
            conectarbd.Close();
        }

        //***CONSULTAR DATOS***
        public List<Consultar_Datos> Seleccionar()
        {
            string sqlSelect = "SELECT [Nombre],[SegundoNombre], [Apellido],[CedulaIdentidad],[CuentaBancaria],[Direccion],[Telefono],[Ciudad],[IdCliente] " +
                               "FROM [VeterinariaPetVet].[dbo].[Cliente]";


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

                    consultar_Datos.Nombre = r["Nombre"].ToString();
                    consultar_Datos.SegundoNombre = r["SegundoNombre"].ToString();
                    consultar_Datos.Apellido = r["Apellido"].ToString();
                    consultar_Datos.Direccion = r["Direccion"].ToString();
                    consultar_Datos.Ciudad = r["Ciudad"].ToString();
                    consultar_Datos.CuentaBancaria = int.Parse(r["CuentaBancaria"].ToString());
                    consultar_Datos.CedulaIdentidad = int.Parse(r["CedulaIdentidad"].ToString());
                    consultar_Datos.Telefono = int.Parse(r["telefono"].ToString());


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

            comm.Parameters.AddWithValue("nombre", insertarsocio.Nombre);
            comm.Parameters.AddWithValue("segundoNombre", insertarsocio.SegundoNombre);
            comm.Parameters.AddWithValue("apellido", insertarsocio.Apellido);
            comm.Parameters.AddWithValue("ci", insertarsocio.Cedula);
            comm.Parameters.AddWithValue("cuentaBancaria", insertarsocio.CuentaBancaria);
            comm.Parameters.AddWithValue("direccion", insertarsocio.Direccion);
            comm.Parameters.AddWithValue("telefono", insertarsocio.Telefono);
            comm.Parameters.AddWithValue("ciudad", insertarsocio.Ciudad);


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
            catch
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
        public bool EliminarSocio(EliminarSocio eliminarSocio)
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


            comm.Parameters.AddWithValue("ci", eliminarSocio.Cedula);



            // Ejecuto la Query (la consulta)
            // Si el resultado es OK, se intertó correctamente, sino, hubo un ERROR
            try
            {
                int r = comm.ExecuteNonQuery();
                return r < 0;
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

                    Datos.Nombre = r["Nombre"].ToString();
                    Datos.Especie = r["Especie"].ToString();
                    Datos.Raza = r["Raza"].ToString();
                    Datos.Color = r["Color"].ToString();
                    Datos.FechaNacimiento = r.GetDateTime(r.GetOrdinal("FechaNacimiento"));


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

        //ELIMINAR MASCOTA
        public void Eliminarmascota()
        {

            Eliminarmascota mascota = new Eliminarmascota();

            //Hacer la consulta para saber que animal corresponde al socio

            mascota.CedulaIdentidad = 42144468;
            mascota.IdAnimal = 1;


            string sqlDelete = "Delete Animal Set Animal = " + mascota.IdAnimal + mascota.CedulaIdentidad;

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




