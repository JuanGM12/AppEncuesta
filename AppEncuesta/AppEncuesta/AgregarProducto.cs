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
    public partial class AgregarProducto : Form
    {

        private const string FileName = @"Productos.bin";
        private List<Productos> Lista = new List<Productos>();


        public AgregarProducto()
        {
            InitializeComponent();
        }

        private void BtCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {

            if (txNombre.Text == "")
            {
                lbNombre.Text = "Ingrese el nombre";

                if (txMarca.Text == "")
                {
                    lbMarca.Text = "Ingrese la marca";

                    if (pbProducto.Image == null)
                    {
                        lbImagen.Text = "Elija una imagen";
                    }
                }
                else
                {
                    if (pbProducto.Image == null)
                    {
                        lbImagen.Text = "Elija una imagen";
                    }
                }

            }
            else
            {
                if (txMarca.Text == "")
                {
                    lbMarca.Text = "Ingrese la marca";

                    if (pbProducto.Image == null)
                    {
                        lbImagen.Text = "Elija una imagen";
                    }
                }
                else
                {
                    if (pbProducto.Image == null)
                    {
                        lbImagen.Text = "Elija una imagen";
                    }
                    else
                    {

                        try
                        {
                            if (File.Exists(FileName))
                            {
                                Stream openFileStream = File.OpenRead(FileName);
                                BinaryFormatter deserializer = new BinaryFormatter();
                                Lista = (List<Productos>)deserializer.Deserialize(openFileStream);
                                Lista.Add(new Productos(Lista.Count, txNombre.Text, txMarca.Text, pbProducto));
                                openFileStream.Close();

                                Stream SaveFileStream = File.OpenWrite(FileName);
                                BinaryFormatter serializer = new BinaryFormatter();
                                serializer.Serialize(SaveFileStream, Lista);
                                SaveFileStream.Close();

                            }
                            else
                            {
                                Lista.Add(new Productos(Lista.Count, txNombre.Text, txMarca.Text, pbProducto));
                                Stream SaveFileStream = File.Create(FileName);
                                BinaryFormatter serializer = new BinaryFormatter();
                                serializer.Serialize(SaveFileStream, Lista);
                                SaveFileStream.Close();
                            }

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);

                        }

                        ConfirmarProducto objConf = new ConfirmarProducto(this);
                        objConf.Show();

                    }
                }
            }


        }

        private void btImportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Abrir.ShowDialog() == DialogResult.OK)
                {
                    pbProducto.Image = Image.FromFile(Abrir.FileName);
                    lbImagen.Text = "";

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }

        }

        private void txNombre_TextChanged(object sender, EventArgs e)
        {
            lbNombre.Text = "";
        }

        private void txMarca_TextChanged(object sender, EventArgs e)
        {
            lbMarca.Text = "";
        }

        public void Borrar()
        {
            txNombre.Text = "";
            txMarca.Text = "";
            pbProducto.Image = null;
        }

        private void AgregarProducto_Load(object sender, EventArgs e)
        {


            if (File.Exists(FileName))
            {
                DialogResult resultado = MessageBox.Show("¿Desea mantener los productos actuales?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (resultado == DialogResult.Yes)
                {


                }
                else
                {

                    MessageBox.Show("¡Productos borrados con éxito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    File.Delete(FileName);

                }
            }


        }
    }
}

