using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Veterinaria.Dominio
{
    public class ConexionBD
    {
        private string cadena = "Data Source = DESKTOP-IKAKVR4; Initial Catalog=VeterinariaPetVet; Integrated Security=True";
        //private string cadena = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VeterinariaPetVet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        //***CONSULTAR DATOS***
        public List<Consultar_Datos> Seleccionar()
        {
            string sql = "SELECT [Nombre],[SegundoNombre], [Apellido],[CedulaIdentidad],[CuentaBancaria],[Direccion],[Telefono],[Ciudad],[IdCliente] " +
                               "FROM [VeterinariaPetVet].[dbo].[Cliente]";


            List<Consultar_Datos> listadatos = new List<Consultar_Datos>();

            var conn = new SqlConnection(cadena);
            var comm = new SqlCommand(sql, conn);


            try
            {
                conn.Open();
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
                throw;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }

        }

        // INSERTAR SOCIO
        public bool AgregarSocio(AgegarSocio insertarsocio)
        {

            string sql = "INSERT INTO [dbo].[Cliente] ([Nombre] ,[SegundoNombre] ," +
                                                             "[Apellido],[CedulaIdentidad]," +
                                                             "[CuentaBancaria],[Direccion]," +
                                                             "[Telefono],[Ciudad]) " +
                                "VALUES (@nombre, @segundoNombre, @apellido, " +
                                        "@ci, @cuentaBancaria, @direccion, @telefono, @ciudad)";


            var conn = new SqlConnection(cadena);
            var comm = new SqlCommand(sql, conn);

            comm.Parameters.AddWithValue("nombre", insertarsocio.Nombre);
            comm.Parameters.AddWithValue("segundoNombre", insertarsocio.SegundoNombre);
            comm.Parameters.AddWithValue("apellido", insertarsocio.Apellido);
            comm.Parameters.AddWithValue("ci", insertarsocio.Cedula);
            comm.Parameters.AddWithValue("cuentaBancaria", insertarsocio.CuentaBancaria);
            comm.Parameters.AddWithValue("direccion", insertarsocio.Direccion);
            comm.Parameters.AddWithValue("telefono", insertarsocio.Telefono);
            comm.Parameters.AddWithValue("ciudad", insertarsocio.Ciudad);

            try
            {
                conn.Open();
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
        public bool EliminarSocio(EliminarSocio eliminarSocio)
        {

            var conn = new SqlConnection(cadena);
            conn.Open();
            var transaction = conn.BeginTransaction();

            var borrarCliente = new SqlCommand
            {
                Connection = conn,
                CommandText = "DELETE from [dbo].[Cliente] where CedulaIdentidad = @ci",
                Transaction = transaction
            };
            borrarCliente.Parameters.AddWithValue("ci", eliminarSocio.Cedula);

            var borrarMascota = new SqlCommand
            {
                Connection = conn,
                CommandText = "DELETE FROM Animal where IdCliente = (SELECT IdCliente FROM Cliente WHERE CedulaIdentidad = @ci)",
                Transaction = transaction
            };
            borrarMascota.Parameters.AddWithValue("ci", eliminarSocio.Cedula);


            try
            {
                int borrarMascotaResult = borrarMascota.ExecuteNonQuery();
                int borrarClienteResult = borrarCliente.ExecuteNonQuery();


                transaction.Commit();

                return borrarClienteResult > 0;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
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
            string sql = "SELECT a.* from [dbo].[Cliente] C inner join Animal A on c.IdCliente = a.IdCliente where c.cedulaidentidad = @ci";

            List<Seleccionarmascota> mascotas = new List<Seleccionarmascota>();

            var conn = new SqlConnection(cadena);
            var comm = new SqlCommand(sql, conn);

            comm.Parameters.AddWithValue("@ci", cedulaidentidad);

            try
            {
                conn.Open();
                SqlDataReader r = comm.ExecuteReader();

                while (r.Read())
                {

                    Seleccionarmascota mascota = new Seleccionarmascota();

                    mascota.Nombre = r["Nombre"].ToString();
                    mascota.Especie = r["Especie"].ToString();
                    mascota.Raza = r["Raza"].ToString();
                    mascota.Color = r["Color"].ToString();
                    mascota.FechaNacimiento = r["Fecha Nacimiento"].ToString();
                    mascota.IdAnimal = r["IdAnimal"].ToString();
                    mascotas.Add(mascota);

                    // Acá se obtienen los datos del Reader, lo que devuelve la Base de Datos de esa consulta
                }

                return mascotas;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        //CONSULTAR SOCIO

        public Socio BuscarSocio(int cedulaidentidad)
        {
            Socio BuscarSocio = null;

            string sql = "SELECT * from [dbo].[Cliente] where cedulaidentidad = @ci";

            var conn = new SqlConnection(cadena);
            var comm = new SqlCommand(sql, conn);

            comm.Parameters.AddWithValue("@ci", cedulaidentidad);

            try
            {
                conn.Open();
                SqlDataReader r = comm.ExecuteReader();

                while (r.Read())
                {


                    BuscarSocio = new Socio();
                    BuscarSocio.Nombre = r["Nombre"].ToString();
                    BuscarSocio.Apellido = r["Apellido"].ToString();
                    BuscarSocio.Cedula = r["CedulaIdentidad"].ToString();
                    BuscarSocio.Ciudad = r["Ciudad"].ToString();
                    BuscarSocio.CuentaBancaria = r["CuentaBancaria"].ToString();
                    BuscarSocio.Direccion = r["Direccion"].ToString();
                    BuscarSocio.Telefono = r["Telefono"].ToString();

                    // Acá se obtienen los datos del Reader, lo que devuelve la Base de Datos de esa consulta
                }

                return BuscarSocio;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        //BUSCAR VETERINARIO
        public List<Veterinario> ListarVeterinarios()
        {

            string sql = "SELECT * from [dbo].[Veterinario]";

            var conn = new SqlConnection(cadena);
            var comm = new SqlCommand(sql, conn);
            List<Veterinario> listaVeterinarios = new List<Veterinario>();
            try
            {
                conn.Open();
                SqlDataReader r = comm.ExecuteReader();

                while (r.Read())
                {
                    float.TryParse(r["IdVeterinario"].ToString(), out float id);
                    listaVeterinarios.Add(new Veterinario
                    {
                        Nombre = r["Nombre"].ToString(),
                        Apellido = r["Apellido"].ToString(),
                        IdVeterinario = id
                    });
                    // Acá se obtienen los datos del Reader, lo que devuelve la Base de Datos de esa consulta
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
            return listaVeterinarios;
        }


        // BUSCAR ENFERMEDAD

        public List<Enfermedad> ListaEnfermedades()
        {

            string sql = "SELECT * from [dbo].[Enfermedad]";

            var conn = new SqlConnection(cadena);
            var comm = new SqlCommand(sql, conn);
            List<Enfermedad> listaEnfermedades = new List<Enfermedad>();
            try
            {
                conn.Open();
                SqlDataReader r = comm.ExecuteReader();

                while (r.Read())
                {
                    float.TryParse(r["IdEnfermedad"].ToString(), out float id);
                    listaEnfermedades.Add(new Enfermedad
                    {
                        IdEnfermedad = id,
                        Nombre = r["Nombre"].ToString(),
                    });
                    // Acá se obtienen los datos del Reader, lo que devuelve la Base de Datos de esa consulta
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
            return listaEnfermedades;
        }


        //AGREGARHISTORIACLINICA
        public bool AgregarHistoriaClinica(AgregarHistoria agregarhistorialClinica2)
        {
            string sql = "INSERT INTO [dbo].[HistoriaClinica] ([IdAnimal],[IdVeterinario] ,[IdEnfermedad],[Fecha Enfermedad])VALUES(@Idanimal,@Idveterinario, @Idenfermedad, @fechadeenfermedad)";


            var conn = new SqlConnection(cadena);
            var comm = new SqlCommand(sql, conn);

            comm.Parameters.AddWithValue("@Idanimal", agregarhistorialClinica2.IdAnimal);
            comm.Parameters.AddWithValue("@Idveterinario", agregarhistorialClinica2.Idveterinario);
            comm.Parameters.AddWithValue("@Idenfermedad", agregarhistorialClinica2.Idenfermedad);
            comm.Parameters.AddWithValue("@fechadeenfermedad", agregarhistorialClinica2.FechadeEnfermedad);


            try
            {
                conn.Open();
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


        // INSERTAR MASCOTA
        public bool Agregarmascota(Agregarmascota insertarmascota)
        {

            string sql = "INSERT INTO [dbo].[Animal] ([IdCliente]," +
                                                     "[Nombre]," +
                                                     "[Especie]," +
                                                     "[Raza]," +
                                                     "[Color]," +
                                                     "[Fecha Nacimiento]) " +
                         "VALUES ((select idcliente from Cliente where CedulaIdentidad = @ci), " +
                                  "@nombre, " +
                                  "@especie, " +
                                  "@raza, " +
                                  "@color, " +
                                  "@fechanac)";

            SqlConnection conn = new SqlConnection(cadena);
            conn.Open();

            var comm = new SqlCommand
            {
                Connection = conn,
                CommandText = sql,
            };


            comm.Parameters.AddWithValue("@ci", insertarmascota.Cedula);
            comm.Parameters.AddWithValue("@nombre", insertarmascota.Nombre);
            comm.Parameters.AddWithValue("@especie", insertarmascota.Especia);
            comm.Parameters.AddWithValue("@raza", insertarmascota.Raza);
            comm.Parameters.AddWithValue("@color", insertarmascota.Color);
            comm.Parameters.AddWithValue("@fechanac", insertarmascota.FechaNacimiento);

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

        //ELIMINAR MASCOTA
        public bool Eliminarmascota(Eliminarmascota eliminarmascota)
        {

            string sql = "DELETE FROM Animal " +
                               "WHERE IdCliente = (SELECT IdCliente " +
                                                  "FROM Cliente " +
                                                  "WHERE CedulaIdentidad = @ci) " +
                               "AND Nombre = @nombre";

            var conn = new SqlConnection(cadena);
            var comm = new SqlCommand(sql, conn);

            comm.Parameters.AddWithValue("@ci", eliminarmascota.CedulaIdentidad);
            comm.Parameters.AddWithValue("@nombre", eliminarmascota.Nombre);

            // Ejecuto la Query (la consulta)
            // Si el resultado es OK, se intertó correctamente, sino, hubo un ERROR
            try
            {
                conn.Open();
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

        public List<Historial> Historial(string cedula)
        {
            string sql = "SELECT [IdHistoriaClinica],[IdAnimal],[IdVeterinario],[IdEnfermedad],[Fecha Enfermedad] " +
                         "FROM [dbo].[HistoriaClinica] " +
                         "where idanimal in (select idanimal " +
                                            "from animal " +
                                            "where IdCliente in (select idcliente " +
                                                                "from Cliente " +
                                                                "where CedulaIdentidad = @ci)) ";
            var conn = new SqlConnection(cadena);
            var comm = new SqlCommand(sql, conn);

            comm.Parameters.AddWithValue("@ci", cedula);

            List<Historial> historiales = new List<Historial>();

            try
            {
                conn.Open();
                SqlDataReader r = comm.ExecuteReader();

                while (r.Read())
                {

                    Historial historial = new Historial();

                    historial.IdHistoriaClinica = r["IdHistoriaClinica"].ToString();
                    historial.IdAnimal = r["IdAnimal"].ToString();
                    historial.IdVeterinario = r["IdVeterinario"].ToString();
                    historial.IdEnfermedad = r["IdEnfermedad"].ToString();
                    historial.Fecha_Enfermedad = r["Fecha Enfermedad"].ToString();

                    historiales.Add(historial);

                    // Acá se obtienen los datos del Reader, lo que devuelve la Base de Datos de esa consulta
                }

                return historiales;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }


        }
        //MODIFICAR SOCIO
        public bool ModificarSocio(ModificarSocio socio)
        {
            bool respuestaExitosa = false;
            string sql = "UPDATE [dbo].[Cliente] SET [CuentaBancaria]=@cuentaBancaria," +
                                                     "[Telefono]=@telefono," +
                                                     "[Direccion]=@direccion," +
                                                     "[Ciudad]=@cuidad WHERE CedulaIdentidad=@cedula";

            SqlConnection conn = new SqlConnection(cadena);
            conn.Open();

            var comm = new SqlCommand
            {
                Connection = conn,
                CommandText = sql,
            };


            comm.Parameters.AddWithValue("@cuentaBancaria", socio.cuentabancaria);
            comm.Parameters.AddWithValue("@telefono", socio.telefono);
            comm.Parameters.AddWithValue("@direccion", socio.direccion);
            comm.Parameters.AddWithValue("@cuidad", socio.ciudad);
            comm.Parameters.AddWithValue("@cedula", socio.cedula);

            try
            {
                int r = comm.ExecuteNonQuery();
                respuestaExitosa= r > 0;
            }
            catch (Exception ex)
            {
                return respuestaExitosa;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
            return respuestaExitosa;
        }

    }
}




