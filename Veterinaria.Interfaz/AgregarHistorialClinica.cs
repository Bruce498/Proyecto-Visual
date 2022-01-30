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

    public partial class AgregarHistorialClinica : Form
    {
        AgregarHistoria DatosHistoria = null;


        public AgregarHistorialClinica()
        {
            InitializeComponent();
            Inicio();
            DatosHistoria = new AgregarHistoria();
        }

        private void Inicio() //Firma de funcion
        {
            //Metodo de la funcion
            cedula.Text = "";
            btnBuscar.Enabled = true;
            btnBorrar.Enabled = false;
            dgvMascotas.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            btnAgregar.Enabled = false;
            lblEnfermedad.Visible = false;
            lblVeterinarios.Visible = false;
        }

        private void CargarComboBoxVeterinario()
        {
            ConexionBD conexionBD = new ConexionBD();
            List<Veterinario> veterinarios = conexionBD.ListarVeterinarios();

            if (veterinarios.Count > 0 )
            {
                comboBox2.DataSource = veterinarios;
            }
        }
        private void CargarComboBoxEnfermedad()
        {
            ConexionBD conexionBD = new ConexionBD();
            List<Enfermedad> enfermedades = conexionBD.ListaEnfermedades();

            if (enfermedades.Count > 0)
            {
                comboBox1.DataSource = enfermedades;
            }
        }
        private void AgregarHistorialClinicocs_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Acciones acciones = new Acciones();
            acciones.Show();
            this.Dispose();
        }


        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DatosHistoria = new AgregarHistoria();
            cedula.Text = "";
            Inicio();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            ConexionBD conexionBD = new ConexionBD();
            if (!string.IsNullOrEmpty(this.cedula.Text) && int.TryParse(this.cedula.Text, out int cedula))
            {
                List<Seleccionarmascota> mascotas = conexionBD.Seleccionarmascota(this.cedula.Text);
                if (mascotas.Count > 0)
                {
                    this.dgvMascotas.DataSource = mascotas;
                    dgvMascotas.Visible = true;
                    btnBorrar.Enabled = true;
                    btnBuscar.Enabled = false;
                    this.cedula.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No hay mascotas vinculadas al Socio");
                }
            }
            else
            {
                MessageBox.Show("Cedula incorrecta!");
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            ConexionBD conexionBD = new ConexionBD();
            DatosHistoria.FechadeEnfermedad = DateTime.Now;
            bool AgregarExitoso = conexionBD.AgregarHistoriaClinica(DatosHistoria);

            if (AgregarExitoso)
            {
                MessageBox.Show("Datos guardados correctamente!");

            }
            else
            {
                MessageBox.Show("Error al cargar los datos");
            }
            Inicio();
        }

        private void dgvMascotas_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection FilasSeleccionadas = dgvMascotas.SelectedRows;
            if (FilasSeleccionadas.Count > 0)
            {
                Seleccionarmascota mascota = (Seleccionarmascota)FilasSeleccionadas[0].DataBoundItem;
                float.TryParse(mascota.IdAnimal, out float idAnimal);
                DatosHistoria.IdAnimal = idAnimal;
                CargarComboBoxVeterinario();
                comboBox2.Visible = true;
                lblVeterinarios.Visible = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DatosHistoria.IdAnimal >0)
            {
                Veterinario veterinario = (Veterinario)comboBox2.SelectedItem;
                DatosHistoria.Idveterinario = veterinario.IdVeterinario;
                CargarComboBoxEnfermedad();
                comboBox1.Visible = true;
                lblEnfermedad.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DatosHistoria.IdAnimal >0)
            {
                Enfermedad enfermedad = (Enfermedad)comboBox1.SelectedItem;
                DatosHistoria.Idenfermedad = enfermedad.IdEnfermedad;
                btnAgregar.Enabled = true;
            }
        }
    }
}
