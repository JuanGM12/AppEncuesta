using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppEncuesta
{
    public partial class ConfirmarProducto : Form
    {

        AgregarProducto agregarProducto;
        private const string FileName = @"Productos.bin";
        private List<Productos> Lista = new List<Productos>();
        public ConfirmarProducto(AgregarProducto objAgregar)
        {
            InitializeComponent();
            this.agregarProducto = objAgregar;
        }

        private void btSalir_Click(object sender, EventArgs e)
        {

            this.Close();
            agregarProducto.Close();

        }

        private void ConfirmarProducto_Load(object sender, EventArgs e)
        {
            try
            {
                Stream openFileStream = File.OpenRead(FileName);
                BinaryFormatter deserializer = new BinaryFormatter();
                Lista = (List<Productos>)deserializer.Deserialize(openFileStream);
                openFileStream.Close();

                pictureBox1.Image = Lista[Lista.Count - 1].getImaProducto();
                lbNumero.Text = "Numero: " + Lista[Lista.Count - 1].getNumero();
                lbNombre.Text = "Nombre: " + Lista[Lista.Count - 1].getNombre();
                lbMarca.Text = "Marca: " + Lista[Lista.Count - 1].getMarca();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            this.Close();

            agregarProducto.Borrar();
        }
    }
}
