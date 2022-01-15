using System;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Ingreso_de_Socio_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cedula = 0;
            bool cedulaOk = int.TryParse(this.txtCedula.Text, out cedula);

            cedulaOk = cedulaOk && this.txtCedula.Text.Length == 8;

            if (!cedulaOk)
            {
                MessageBox.Show("Cedula no es correcta");
                return;
            }

            AgegarSocio agegarSocio = new AgegarSocio
            {
                Apellido = this.txtApellido.Text,
                Cedula = cedula,
                Ciudad = this.txtCiudad.Text,
                CuentaBancaria = Convert.ToInt32(this.txtCuentaBancaria.Text),
                Direccion = this.txtDireccion.Text,
                Nombre = this.txtNombre.Text,
                Telefono = Convert.ToInt32(this.txtTelefono.Text),
                SegundoNombre = this.txtSegundoNombre.Text
            };

            ConexionBD conexionBD = new ConexionBD();
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

        private void Ingreso_de_Socio_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Acciones acciones = new Acciones();
            acciones.Show();
            this.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
