using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz_Grafica_PETVET
{
    public partial class Acciones : Form
    {
        public Acciones()
        {
            InitializeComponent();
        }

        private void bajaDeMascotaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ingresarSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ingreso_de_Socio ingreso_De_Socio = new Ingreso_de_Socio();
            ingreso_De_Socio.Show();
            this.Dispose();
        }

        private void Acciones_Load(object sender, EventArgs e)
        {

        }
    }
}
