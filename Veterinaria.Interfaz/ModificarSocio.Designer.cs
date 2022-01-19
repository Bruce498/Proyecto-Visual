
namespace Veterinaria.Interfaz
{
    partial class ModificarSocio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarSocio));
            this.label1 = new System.Windows.Forms.Label();
            this.cedula = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Eliminar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lato Black", 40F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(365, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(508, 80);
            this.label1.TabIndex = 1;
            this.label1.Text = "Modificar Socio";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cedula
            // 
            this.cedula.BackColor = System.Drawing.SystemColors.MenuBar;
            this.cedula.Font = new System.Drawing.Font("Lato Black", 16F, System.Drawing.FontStyle.Bold);
            this.cedula.Location = new System.Drawing.Point(505, 150);
            this.cedula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cedula.Name = "cedula";
            this.cedula.Size = new System.Drawing.Size(217, 39);
            this.cedula.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(437, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(363, 41);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ingrese Cedula del Socio";
            // 
            // Eliminar
            // 
            this.Eliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Eliminar.BackgroundImage")));
            this.Eliminar.Font = new System.Drawing.Font("Lato Black", 16F, System.Drawing.FontStyle.Bold);
            this.Eliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Eliminar.Location = new System.Drawing.Point(423, 487);
            this.Eliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(150, 39);
            this.Eliminar.TabIndex = 8;
            this.Eliminar.Text = "Modificar";
            this.Eliminar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Font = new System.Drawing.Font("Lato Black", 16F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(723, 487);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 39);
            this.button1.TabIndex = 9;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ModificarSocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1257, 573);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.cedula);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ModificarSocio";
            this.Text = "ModificarSocio";
            this.Load += new System.EventHandler(this.ModificarSocio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cedula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Button button1;
    }
}