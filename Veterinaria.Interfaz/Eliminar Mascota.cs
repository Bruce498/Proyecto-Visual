using System;
using System.Windows.Forms;
using Veterinaria.Dominio;
using System.Collections.Generic;
namespace Veterinaria.Interfaz
{
    public partial class Eliminar_Mascota : Form
    {
        Seleccionarmascota mascotaSeleccionada = null;
        public Eliminar_Mascota()
        {
            InitializeComponent();
            lstMascotas.Visible = false;
            btnBorrar.Enabled = false;
        }

      

        private void Eliminar_Click(object sender, EventArgs e)
        {
            ConexionBD conexionDB = new ConexionBD();
            if (mascotaSeleccionada != null)
            {
                Eliminarmascota eliminarmascota = new Eliminarmascota
                {

                    CedulaIdentidad = int.Parse(this.cedula.Text),
                    Nombre = mascotaSeleccionada.Nombre
                };
                bool ok = conexionDB.Eliminarmascota(eliminarmascota);

                if (ok)
                {
                    MessageBox.Show("Se elimino la mascota correctamente");

                    Acciones acciones = new Acciones();
                    acciones.Show();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("NO se pudo eliminar la mascota.");
                }
                mascotaSeleccionada = null;
                lstMascotas.SelectedIndex = -1;
            }
            else { MessageBox.Show("No hay mascota seleccionada");}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Acciones acciones = new Acciones();
            acciones.Show();
            this.Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ConexionBD conexion = new ConexionBD();
            lstMascotas.Items.Clear();
            int.TryParse(cedula.Text, out int ci);
            if (ci != 0)
            {
                Socio socioBuscado = conexion.BuscarSocio(ci);
                
                if (socioBuscado != null)
                {
                    List<Seleccionarmascota> mascotas = conexion.Seleccionarmascota(cedula.Text);
                    cedula.Enabled = false;
                    btnBuscar.Enabled = false;
                    btnBorrar.Enabled = true;
                    if (mascotas.Count > 0)
                    {
                        lstMascotas.Visible = true;
                        foreach (Seleccionarmascota mascota in mascotas)
                        {
                            lstMascotas.Items.Add(mascota);
                        }
                    }
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

        private void lstMascotas_SelectedIndexChanged(object sender, EventArgs e)
        {
             mascotaSeleccionada = (Seleccionarmascota)lstMascotas.SelectedItem;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            cedula.Enabled = true;
            cedula.Text = "";
            lstMascotas.Visible = false;
            btnBuscar.Enabled = true;
            btnBorrar.Enabled = false;

        }

        private void cedula_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
