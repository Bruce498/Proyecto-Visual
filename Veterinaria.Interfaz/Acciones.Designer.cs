
namespace Veterinaria.Interfaz
{
    partial class Acciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Acciones));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ingresarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresarSocioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresarMascotaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialClinicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.socioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaDeSocioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaDeMascotaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.socioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mascotaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Lato Black", 11F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresarToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.consultarToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1257, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // ingresarToolStripMenuItem
            // 
            this.ingresarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresarSocioToolStripMenuItem,
            this.ingresarMascotaToolStripMenuItem,
            this.historialClinicoToolStripMenuItem});
            this.ingresarToolStripMenuItem.Name = "ingresarToolStripMenuItem";
            this.ingresarToolStripMenuItem.Size = new System.Drawing.Size(93, 27);
            this.ingresarToolStripMenuItem.Text = "Ingresar";
            this.ingresarToolStripMenuItem.Click += new System.EventHandler(this.ingresarToolStripMenuItem_Click);
            // 
            // ingresarSocioToolStripMenuItem
            // 
            this.ingresarSocioToolStripMenuItem.Name = "ingresarSocioToolStripMenuItem";
            this.ingresarSocioToolStripMenuItem.Size = new System.Drawing.Size(229, 28);
            this.ingresarSocioToolStripMenuItem.Text = "Socio";
            this.ingresarSocioToolStripMenuItem.Click += new System.EventHandler(this.ingresarSocioToolStripMenuItem_Click);
            // 
            // ingresarMascotaToolStripMenuItem
            // 
            this.ingresarMascotaToolStripMenuItem.Name = "ingresarMascotaToolStripMenuItem";
            this.ingresarMascotaToolStripMenuItem.Size = new System.Drawing.Size(229, 28);
            this.ingresarMascotaToolStripMenuItem.Text = "Mascota";
            this.ingresarMascotaToolStripMenuItem.Click += new System.EventHandler(this.ingresarMascotaToolStripMenuItem_Click);
            // 
            // historialClinicoToolStripMenuItem
            // 
            this.historialClinicoToolStripMenuItem.Name = "historialClinicoToolStripMenuItem";
            this.historialClinicoToolStripMenuItem.Size = new System.Drawing.Size(229, 28);
            this.historialClinicoToolStripMenuItem.Text = "Historial Clinico";
            this.historialClinicoToolStripMenuItem.Click += new System.EventHandler(this.historialClinicoToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.socioToolStripMenuItem});
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(107, 27);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // socioToolStripMenuItem
            // 
            this.socioToolStripMenuItem.Name = "socioToolStripMenuItem";
            this.socioToolStripMenuItem.Size = new System.Drawing.Size(141, 28);
            this.socioToolStripMenuItem.Text = "Socio";
            this.socioToolStripMenuItem.Click += new System.EventHandler(this.socioToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bajaDeSocioToolStripMenuItem,
            this.bajaDeMascotaToolStripMenuItem});
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(94, 27);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            // 
            // bajaDeSocioToolStripMenuItem
            // 
            this.bajaDeSocioToolStripMenuItem.Name = "bajaDeSocioToolStripMenuItem";
            this.bajaDeSocioToolStripMenuItem.Size = new System.Drawing.Size(167, 28);
            this.bajaDeSocioToolStripMenuItem.Text = " Socio";
            this.bajaDeSocioToolStripMenuItem.Click += new System.EventHandler(this.bajaDeSocioToolStripMenuItem_Click);
            // 
            // bajaDeMascotaToolStripMenuItem
            // 
            this.bajaDeMascotaToolStripMenuItem.Name = "bajaDeMascotaToolStripMenuItem";
            this.bajaDeMascotaToolStripMenuItem.Size = new System.Drawing.Size(167, 28);
            this.bajaDeMascotaToolStripMenuItem.Text = "Mascota";
            this.bajaDeMascotaToolStripMenuItem.Click += new System.EventHandler(this.bajaDeMascotaToolStripMenuItem_Click);
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.socioToolStripMenuItem1,
            this.mascotaToolStripMenuItem});
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(106, 27);
            this.consultarToolStripMenuItem.Text = "Consultar";
            // 
            // socioToolStripMenuItem1
            // 
            this.socioToolStripMenuItem1.Name = "socioToolStripMenuItem1";
            this.socioToolStripMenuItem1.Size = new System.Drawing.Size(224, 28);
            this.socioToolStripMenuItem1.Text = "Socio";
            this.socioToolStripMenuItem1.Click += new System.EventHandler(this.socioToolStripMenuItem1_Click);
            // 
            // mascotaToolStripMenuItem
            // 
            this.mascotaToolStripMenuItem.Name = "mascotaToolStripMenuItem";
            this.mascotaToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.mascotaToolStripMenuItem.Text = "Mascota";
            this.mascotaToolStripMenuItem.Click += new System.EventHandler(this.mascotaToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(62, 27);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // Acciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1257, 573);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Acciones";
            this.Text = "Acciones";
            this.Load += new System.EventHandler(this.Acciones_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ingresarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresarSocioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresarMascotaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem socioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaDeSocioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaDeMascotaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem socioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mascotaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialClinicoToolStripMenuItem;
    }
}