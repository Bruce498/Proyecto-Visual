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
    public partial class ConsultarSocio : Form
    {
        public ConsultarSocio()
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
            var socio = conexionBD.BuscarSocio(int.Parse(this.cedula.Text));
            if (socio != null)
            {
                this.socioBindingSource.DataSource = new List<Socio> { socio };
            }
            else 
            {
                MessageBox.Show("Socio inexistente");
                this.socioBindingSource.DataSource = null;
            }
        }
    }
}
