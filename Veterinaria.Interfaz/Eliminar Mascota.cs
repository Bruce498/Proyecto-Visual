using System;
using System.Windows.Forms;
using Veterinaria.Dominio;

namespace Veterinaria.Interfaz
{
    public partial class Eliminar_Mascota : Form
    {
        public Eliminar_Mascota()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Eliminar_Mascota_Load(object sender, EventArgs e)
        {

        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            ConexionBD conexionDB = new ConexionBD();
            Eliminarmascota eliminarmascota = new Eliminarmascota
            {

                CedulaIdentidad = int.Parse(this.cedula.Text)
            };
            bool ok = conexionDB.Eliminarmascota(eliminarmascota);

            if (ok)
            {
                MessageBox.Show("Se elimino la mascota correctamente");
            }
            else
            {
                MessageBox.Show("NO se pudo eliminar la mascota.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Acciones acciones = new Acciones();
            acciones.Show();
            this.Dispose();
        }
    }
}
