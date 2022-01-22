using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.Dominio;

namespace Veterinaria.Interfaz
{
    public partial class Ingreso_Mascota : Form
    {
        public Ingreso_Mascota()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Acciones acciones = new Acciones();
            acciones.Show();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConexionBD conexionBD = new ConexionBD();
            bool ok = conexionBD.Agregarmascota(new Agregarmascota
            {
                Cedula = int.Parse(this.cedula.Text),
                Color = this.color.Text,
                Especia = this.especie.Text,
                FechaNacimiento = this.fechaNac.Text,
                Nombre = this.nombre.Text,
                Raza = this.raza.Text
            });
            if (ok)
            {

                Acciones acciones = new Acciones();
                acciones.Show();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("La mascota no se ha podido ingresar.");
            }

        }

        private void Ingreso_Mascota_Load(object sender, EventArgs e)
        {

        }

        private void cedula_TextChanged(object sender, EventArgs e)
        {
            if (cedula == null)
            {
                MessageBox.Show("Cliente inexistente");
                return;
            }

        }


        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
