using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppEncuesta
{
    public partial class Ganador : Form
    {

        private List<GroupBox> Ganadores;
        public Ganador(List<GroupBox> Ganadores)
        {
            InitializeComponent();
            this.Ganadores = Ganadores;
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ganador_Load(object sender, EventArgs e)
        {
            if(Ganadores.Count > 1)
            {
                lbTitulo.Text = "Empate";
            }

            for (int i = 0; i < Ganadores.Count; i++)
            {
                flowLayoutPanel1.Controls.Add(Ganadores[i]);
            }
        }
    }
}
