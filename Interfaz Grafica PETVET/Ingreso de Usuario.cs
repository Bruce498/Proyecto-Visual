﻿using System;
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
    public partial class Ingreso_de_Usuario : Form
    {
        public Ingreso_de_Usuario()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Ingreso_de_Usuario_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click(object sender, EventArgs e)

        {
            if (txtID.Text == "Simon" && txtcontra.Text == "04101989")
            {
                MessageBox.Show("Se ha iniciado la sesion.");
                Acciones acciones = new Acciones();
                acciones.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error en el ID o Contraseña..Ingrese nuevamente!");

                txtID.Text = ""; // borra los datos que se ingresaron
                txtcontra.Text = ""; // borra los datos que se ingresaron
                txtID.Focus(); // prioriza el primer campo de datos
            }
        }

        private void txtcontra_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}