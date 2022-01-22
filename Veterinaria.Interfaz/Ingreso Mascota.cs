using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
