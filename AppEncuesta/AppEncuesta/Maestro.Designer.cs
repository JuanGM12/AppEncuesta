namespace AppEncuesta
{
    partial class Maestro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Maestro));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.votarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.votarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarEncuestaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finalizarEncuestaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearCuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirProgramaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.votarToolStripMenuItem,
            this.crearCuentasToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // votarToolStripMenuItem
            // 
            this.votarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.votarToolStripMenuItem1,
            this.agregarEncuestaToolStripMenuItem,
            this.finalizarEncuestaToolStripMenuItem});
            this.votarToolStripMenuItem.Name = "votarToolStripMenuItem";
            this.votarToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.votarToolStripMenuItem.Text = "Encuestas";
            this.votarToolStripMenuItem.Click += new System.EventHandler(this.votarToolStripMenuItem_Click);
            // 
            // votarToolStripMenuItem1
            // 
            this.votarToolStripMenuItem1.Enabled = false;
            this.votarToolStripMenuItem1.Image = global::AppEncuesta.Properties.Resources.votar;
            this.votarToolStripMenuItem1.Name = "votarToolStripMenuItem1";
            this.votarToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.votarToolStripMenuItem1.Text = "Votar";
            this.votarToolStripMenuItem1.Click += new System.EventHandler(this.votarToolStripMenuItem1_Click);
            // 
            // agregarEncuestaToolStripMenuItem
            // 
            this.agregarEncuestaToolStripMenuItem.Image = global::AppEncuesta.Properties.Resources.agregar_archivo;
            this.agregarEncuestaToolStripMenuItem.Name = "agregarEncuestaToolStripMenuItem";
            this.agregarEncuestaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agregarEncuestaToolStripMenuItem.Text = "Agregar producto";
            this.agregarEncuestaToolStripMenuItem.Click += new System.EventHandler(this.agregarEncuestaToolStripMenuItem_Click);
            // 
            // finalizarEncuestaToolStripMenuItem
            // 
            this.finalizarEncuestaToolStripMenuItem.Image = global::AppEncuesta.Properties.Resources.finalizar;
            this.finalizarEncuestaToolStripMenuItem.Name = "finalizarEncuestaToolStripMenuItem";
            this.finalizarEncuestaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.finalizarEncuestaToolStripMenuItem.Text = "Finalizar encuesta";
            this.finalizarEncuestaToolStripMenuItem.Click += new System.EventHandler(this.finalizarEncuestaToolStripMenuItem_Click);
            // 
            // crearCuentasToolStripMenuItem
            // 
            this.crearCuentasToolStripMenuItem.Name = "crearCuentasToolStripMenuItem";
            this.crearCuentasToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.crearCuentasToolStripMenuItem.Text = "Crear cuentas";
            this.crearCuentasToolStripMenuItem.Click += new System.EventHandler(this.crearCuentasToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesiónToolStripMenuItem,
            this.salirProgramaToolStripMenuItem});
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.salirToolStripMenuItem.Text = "Salir ";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // salirProgramaToolStripMenuItem
            // 
            this.salirProgramaToolStripMenuItem.Name = "salirProgramaToolStripMenuItem";
            this.salirProgramaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.salirProgramaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.salirProgramaToolStripMenuItem.Text = "&Salir";
            this.salirProgramaToolStripMenuItem.Click += new System.EventHandler(this.salirProgramaToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // Maestro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Maestro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplicacion de encuestas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Maestro_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem votarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem votarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem agregarEncuestaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finalizarEncuestaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirProgramaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearCuentasToolStripMenuItem;
    }
}

