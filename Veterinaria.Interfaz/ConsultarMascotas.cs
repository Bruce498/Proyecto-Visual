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
    public partial class ConsultarMascotas : Form
    {
        public ConsultarMascotas()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Acciones acciones = new Acciones();
            acciones.Show();
            this.Dispose();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            ConexionBD conexionBD = new ConexionBD();
            var mascotas = conexionBD.Seleccionarmascota(this.cedula.Text);
            this.seleccionarmascotaBindingSource.DataSource = mascotas;
        }
    }
}
