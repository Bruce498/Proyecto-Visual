using System;
using System.Windows.Forms;

namespace Veterinaria.Interfaz
{
    public partial class Eliminar_Socio : Form
    {
        public Eliminar_Socio()
        {
            InitializeComponent();
        }

        private void Eliminar_Sociocs_Load(object sender, EventArgs e)
        {

        }

        private void cedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void Eliminar_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Acciones acciones = new Acciones();
            acciones.Show();
            this.Dispose();
        }
    }
}
