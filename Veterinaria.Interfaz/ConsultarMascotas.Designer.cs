﻿
namespace Veterinaria.Interfaz
{
    partial class ConsultarMascotas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultarMascotas));
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.Eliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lato Black", 40F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(298, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(599, 80);
            this.label1.TabIndex = 2;
            this.label1.Text = "Consultar Mascota";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Font = new System.Drawing.Font("Lato Black", 16F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(645, 523);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 39);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Eliminar
            // 
            this.Eliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Eliminar.BackgroundImage")));
            this.Eliminar.Font = new System.Drawing.Font("Lato Black", 16F, System.Drawing.FontStyle.Bold);
            this.Eliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Eliminar.Location = new System.Drawing.Point(404, 523);
            this.Eliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(150, 39);
            this.Eliminar.TabIndex = 8;
            this.Eliminar.Text = "Consultar";
            this.Eliminar.UseVisualStyleBackColor = true;
            // 
            // ConsultarMascotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1257, 573);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.label1);
            this.Name = "ConsultarMascotas";
            this.Text = "ConsultarMascotacs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Eliminar;
    }
}