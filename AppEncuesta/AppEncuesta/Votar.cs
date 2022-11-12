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
    public partial class Votar : Form
    {

        private const string FileName = @"Productos.bin";
        private List<Productos> Lista = new List<Productos>();        
        Maestro maestro;
        long cedula;

        public Votar(Maestro maestro, long cedula)
        {
            InitializeComponent();
            this.maestro = maestro;
            this.cedula = cedula;
        }

        private void Votar_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;                      
                                
            try
            {
                Stream openFileStream = File.OpenRead(FileName);
                BinaryFormatter deserializer = new BinaryFormatter();
                Lista = (List<Productos>)deserializer.Deserialize(openFileStream);                    
                openFileStream.Close();

                for (int i = 0; i < Lista.Count; i++)
                {
                    flowLayoutPanel1.Controls.Add(FormatoImagenes(Lista[i].getImaProducto()));
                    
                }              

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

           

        }        
            
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void click(object sender, EventArgs e)
        {
            ConfirmarVoto ObjConfirmar = new ConfirmarVoto(flowLayoutPanel1.Controls.GetChildIndex((Control)sender), this, maestro, cedula);
            ObjConfirmar.Show();
        }

        public PictureBox FormatoImagenes(Image Imagen)
        {
            PictureBox produ = new PictureBox();

            produ.Size = new Size(198, 154);

            produ.SizeMode = PictureBoxSizeMode.StretchImage;

            produ.Image = Imagen;

            produ.Click += new EventHandler(click);

            return produ;

        }
    }
}
