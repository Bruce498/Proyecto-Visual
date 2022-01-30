using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Veterinaria.Dominio;

namespace Veterinaria.Interfaz
{
    public partial class Ingreso_de_Socio : Form
    {
        public Ingreso_de_Socio()
        {
            InitializeComponent();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            int cedula = 0;
            bool cedulaOk = int.TryParse(this.txtCedula.Text, out cedula);

            cedulaOk = cedulaOk && this.txtCedula.Text.Length == 8;

            int Telefono = 0;
            bool TelefonoOk = int.TryParse(this.txtTelefono.Text, out Telefono);

            TelefonoOk = TelefonoOk && this.txtTelefono.Text.Length == 9;


            bool cuentabancariaOK = Int64.TryParse(this.txtCuentaBancaria.Text, out Int64 CuentaBancaria);

            cuentabancariaOK = CuentaBancaria > 0 ? true : false;

            string Nombre;
            string Apellido;

            if (String.IsNullOrEmpty(this.Nombre.Text) || !Regex.IsMatch(this.Nombre.Text, @"^[a-zA-Z]+$")) //Esta condicion lo que hace es que si el nombre esta vacio salta error.
                                                                                                            //y tiene la condicion que debe de ser solo letras lo q ingrese.             
            {
                MessageBox.Show("Nombre es incorrecto");
                return;
            }

            else if (String.IsNullOrEmpty(this.txtApellido.Text))
            {
                MessageBox.Show("Apellido es incorrecto");
                return;
            }

            else if (!cedulaOk)
            {
                MessageBox.Show("Cedula no es correcta");
                return;
            }

            else if (!cuentabancariaOK)
            {

                MessageBox.Show("Numero de Cuenta Bancaria incorrecto");
                return;

            }
            ConexionBD conexionBD = new ConexionBD();
            Socio socio = conexionBD.BuscarSocio(Convert.ToInt32(this.txtCedula.Text));
            if (socio != null)
            {
                MessageBox.Show("Socio ya existente");
                LimpiarFormulario();
                return;
            }

            AgegarSocio agegarSocio = new AgegarSocio
            {
                Nombre = this.Nombre.Text,
                SegundoNombre = this.txtSegundoNombre.Text,
                Apellido = this.txtApellido.Text,
                Cedula = Convert.ToInt32(this.txtCedula.Text),
                Ciudad = this.txtCiudad.Text,
                CuentaBancaria = Convert.ToInt64(this.txtCuentaBancaria.Text),
                Direccion = this.txtDireccion.Text,
                Telefono = Convert.ToInt32(this.txtTelefono.Text),

            };


            bool ok = conexionBD.AgregarSocio(agegarSocio);

            if (ok)
            {
                MessageBox.Show("Datos insertados correctamente");
                //volver a atras
                Acciones acciones = new Acciones();
                acciones.Show();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Error al insertar los datos");
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Acciones acciones = new Acciones();
            acciones.Show();
            this.Dispose();
        }





        private void LimpiarFormulario()
        {
            txtApellido.Text = ""; // borra los datos que se ingresaron
            txtCiudad.Text = ""; // borra los datos que se ingresaron
            txtCedula.Text = "";
            txtCuentaBancaria.Text = "";
            txtDireccion.Text = "";
            txtSegundoNombre.Text = "";
            txtTelefono.Text = "";
        }
    }
}
