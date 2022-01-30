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
    public partial class ModificarSocio : Form
    {
        public ModificarSocio()
        {
            InitializeComponent();
            Inicio();
        }
        private void Inicio() 
        {
            btnBorrar.Enabled = false;
            cedula.Text = "";
            Modificar.Enabled = false;
            //labels y caja de textos de informacion socio todos OCULTOS
            
        }
        private void FormModificarSocio() 
        {
            //BLOQUEAR CAJA DE TEXTO DE CAMPOS NO MODIFICABLES 
            //EJ: NOMBRE.ENABLE=FALSE;
        }
        private void ModificarSocio_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Acciones acciones = new Acciones();
            acciones.Show();
            this.Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cedula.Text) && int.TryParse(cedula.Text, out int cedulaParceada))
            {
                ConexionBD conexion = new ConexionBD();
                Socio socioEncontrado = conexion.BuscarSocio(cedulaParceada);
                if (socioEncontrado != null)
                {
                    //CARGAR LOS DATOS EN LAS CAJAS DE TEXTO 
                    //RECORDAR AÑÀDIR EN SOCIO ATRIBUTO SEGUNDO NOMBRE 
                    //EJ:
                    txtApellido.Text = socioEncontrado.Apellido;
                    //RECORDAR BLOQUEAR EN EL METODO DE LA LINEA 63 LAS CAJAS DE TEXTO QUE NO QUEREMOS QUE EL USUARIO MODIFIQUE
                    FormModificarSocio();
                    btnBorrar.Enabled = true;
                    btnBuscar.Enabled = false;
                    cedula.Enabled = false;
                    Modificar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No existe socio con esa cedula");
                }
            }
            else 
            {
                MessageBox.Show("Cedula incorrecta.");
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            
            ConexionBD conexionBD = new ConexionBD();
            bool exito = conexionBD.ModificarSocio(new Dominio.ModificarSocio 
            { cuentabancaria = Convert.ToInt32(txtCuentaBancaria.Text), 
                telefono = Convert.ToInt32(txtTelefono.Text), 
                direccion = txtDireccion.Text, 
                ciudad = txtCiudad.Text ,
                cedula= Convert.ToInt32(cedula.Text)
            }
            );
            if (exito) 
            { MessageBox.Show("Socio modificado correctamente"); } 
            else 
            { MessageBox.Show("Error al querer modificar socio."); }

            Inicio();
        }
    }
}
