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
            OcultarCampos(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OcultarCampos(false);
            cedula.Text = "";
            cedula.Enabled = true;
        }

        private void OcultarCampos(bool habilitar)
        {
            label2.Visible = habilitar;
            label3.Visible = habilitar;
            label4.Visible = habilitar;
            label5.Visible = habilitar;
            label6.Visible = habilitar;

            nombre.Visible = habilitar;
            raza.Visible = habilitar;
            color.Visible = habilitar;
            especie.Visible = habilitar;
            fechaNac.Visible = habilitar;
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


        private void cedula_TextChanged(object sender, EventArgs e)
        {
            if (cedula == null)
            {
                MessageBox.Show("Cliente inexistente");
                return;
            }

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Acciones acciones = new Acciones();
            acciones.Show();
            this.Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ConexionBD conexion = new ConexionBD();
            int.TryParse(cedula.Text, out int ci);
            if (ci != 0)
            {
                Socio socioBuscado = conexion.BuscarSocio(ci);

                if (socioBuscado != null)
                {
                    OcultarCampos(true);
                    cedula.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Cedula de Identidad No Encontrada");
                    cedula.Text = "";
                    return;
                }
            }
            else
            {
                MessageBox.Show("Cedula de Identidad Incorrecta");
                cedula.Text = "";
                return;
            }

        }
    }
}