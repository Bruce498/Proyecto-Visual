﻿using Proyecto_Final;
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


        //***SELECCIONAR DATOS***

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

        // INSERTAR SOCIO
        public bool AgregarSocio(AgegarSocio insertarsocio)
        {

            string sqlInsert = "INSERT INTO [dbo].[Cliente] ([Nombre] ,[SegundoNombre] ," +
                                                             "[Apellido],[CedulaIdentidad]," +
                                                             "[CuentaBancaria],[Direccion]," +
                                                             "[Telefono],[Ciudad]) " +
                                "VALUES (@nombre, @segundoNombre, @apellido, " +
                                        "@ci, @cuentaBancaria, @direccion, @telefono, @ciudad)";


            var conn = new SqlConnection("Data Source = DESKTOP-IKAKVR4; Initial Catalog=VeterinariaPetVet; Integrated Security=True");


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
                //string resultado;
                //if (r > 0)
                //{
                //    resultado = "Datos insertados correctamente";
                //}
                //else
                //{
                //    resultado = "Error al insertar los datos";
                //}
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
        public void ModificarSocio()
        {

            ModificarSocio socio = new ModificarSocio();

            ///SE DEBE HACER LA CONSULTA PARA SABER DE QUE SOCIO ESTAMOS MODIFICANDO

            socio.direccion = "Direccion nueva";
            socio.ciudad = "Maldonado";
            socio.telefono = 26006000;
            socio.cuentabancaria = 1719859635;

            string sqlUpdate = "Update Persona Set Nombre = " + socio.direccion + ", " + socio.telefono + "," + socio.cuentabancaria + "," + socio.ciudad;

            var conn = new SqlConnection("DESKTOP-IKAKVR4; Initial Catalog=VeterinariaPetVet; Integrated Security=True");


            conn.Open();
            var comm = new SqlCommand
            {
                Connection = conn,
                CommandType = CommandType.Text,
                CommandText = sqlUpdate,
            };


            // Ejecuto la Query (la consulta)
            // Si el resultado es OK, se intertó correctamente, sino, hubo un ERROR
            try
            {
                int r = comm.ExecuteNonQuery();
                string resultado;
                if (r > 0)
                {
                    resultado = "Datos actualziados correctamente";
                }
                else
                {
                    resultado = "Error al actualziar los datos";
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

        //ELIMINAR SOCIO

        public void EliminarSocio()
        {

            EliminarSocio socio = new EliminarSocio();

            socio.cedulaidentidad = 42144468;

            string sqlDelete = "Delete Cliente Set Nombre =" + socio.cedulaidentidad;

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

        //SELECCIONAR MASCOTA

        public List<string> Seleccionarmascota(string nombre)
        {
            string sqlSelect = "select * from Animal";
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

        // INSERTAR MASCOTA

        public void Agregarmascota()
        {

            Agregarmascota insertarmascota = new Agregarmascota();

            insertarmascota.nombre = "Simba";
            insertarmascota.especie = "Canino";
            insertarmascota.raza = "Labrador";
            insertarmascota.color = "Negro";
            //insertarmascota.fechanacimiento = 04/10/2018;



            //string sqlInsert = "Insert into Animal (Nombre, Especie, Raza, Color, Fecha nacimiento) Values ('" + insertarmascota.nombre + "', '" + insertarmascota.especie + "''" + insertarmascota.raza + "', '" + insertarmascota.color + "''" + insertarmascota.fechanacimiento + "')";

            //INSERT INTO table_name(column1, column2, column3, ...) VALUES(value1, value2, value3, ...); ***FUNCION DE INSERTAR DATOS***

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

    //ELIMINAR MASCOTA


}




