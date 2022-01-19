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
    public partial class Acciones : Form
    {
        public Acciones()
        {
            InitializeComponent();
        }

        private void bajaDeMascotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eliminar_Mascota eliminarmascota = new Eliminar_Mascota();
            eliminarmascota.Show();
            this.Dispose();
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

        private void bajaDeSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eliminar_Socio EliminarSocio = new Eliminar_Socio();
            EliminarSocio.Show();
            this.Dispose();
        }

        private void socioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarSocio modificarsocio = new ModificarSocio();
            modificarsocio.Show();
            this.Dispose();

        }

        private void ingresarMascotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ingreso_Mascota ingreso_De_mascota = new Ingreso_Mascota();
            ingreso_De_mascota.Show();
            this.Dispose();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hisoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistorialClinica historiaclinica = new HistorialClinica();
            historiaclinica.Show();
            this.Dispose();
        }

        private void ingresarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mascotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarMascotas consultarmascotas = new ConsultarMascotas();
            consultarmascotas.Show();
            this.Dispose();
        }

        private void socioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultarSocio consultarSocio = new ConsultarSocio();
            consultarSocio.Show();
            this.Dispose();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
