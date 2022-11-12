using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppEncuesta
{
    public partial class ResultadoEncuesta : Form
    {
        private const string FileName = @"Productos.bin";
        private List<Productos> Lista = new List<Productos>();
        private List<GroupBox> GroupList = new List<GroupBox>();
        private int Numero, votos, Posicion = 0, Gana = 0;
        private string Nombre, Marca;
        private double Porcentaje, TotalVotos;
        private Image Imagen;
        private GroupBox aux;
        

        public ResultadoEncuesta()
        {
            InitializeComponent();
        }

        private void ResultadoEncuesta_Load(object sender, EventArgs e)
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
                    TotalVotos += Lista[i].getNumVotos();
                }

                if (TotalVotos > 0)
                {
                    Porcentaje = (Lista[0].getNumVotos() / TotalVotos) * 100;
                }
                else
                {
                    Porcentaje = 0;
                }

                aux = GroupProductos(Lista[0].getImaProducto(), Lista[0].getNumero(), Lista[0].getNombre(),
                    Lista[0].getMarca(), Lista[0].getNumVotos(), Porcentaje);

                for (int i = 0; i < Lista.Count; i++)
                {
                    Imagen = Lista[i].getImaProducto();
                    Numero = Lista[i].getNumero();
                    Nombre = Lista[i].getNombre();
                    Marca = Lista[i].getMarca();
                    votos = Lista[i].getNumVotos();

                    //sin el if Cuando TotalVotos es 0 sale un error "Porcentaje = NaN"
                    if(TotalVotos > 0)
                    {
                        Porcentaje = (votos / TotalVotos) * 100;
                    }
                    else
                    {
                        Porcentaje = 0;
                    }
                    
                    flowLayoutPanel1.Controls.Add(GroupProductos(Imagen, Numero, Nombre, Marca, votos, Porcentaje));                                      
                    
                    if (Lista[i].getNumVotos() > Gana)
                    {
                        aux = GroupProductos(Imagen, Numero, Nombre, Marca, votos, Porcentaje);
                        Posicion = i;
                        Gana = Lista[i].getNumVotos();
                    }

                }

                GroupList.Add(aux);

                for (int i = 0; i < Lista.Count; i++)
                {

                    if(Lista[i].getNumVotos() == Gana && Posicion != i)
                    {

                        Imagen = Lista[i].getImaProducto();
                        Numero = Lista[i].getNumero();
                        Nombre = Lista[i].getNombre();
                        Marca = Lista[i].getMarca();
                        votos = Lista[i].getNumVotos();

                        if (TotalVotos > 0)
                        {
                            Porcentaje = (votos / TotalVotos) * 100;
                        }
                        else
                        {
                            Porcentaje = 0;
                        }

                        GroupList.Add(GroupProductos(Imagen, Numero, Nombre, Marca, votos, Porcentaje));

                    }

                }

                Ganador objGana = new Ganador(GroupList);
                objGana.Show();

                for (int i = 0; i < Lista.Count; i++)
                {
                    Lista[i].ReiniciarVotos();
                }

                Stream SaveFileStream = File.OpenWrite(FileName);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(SaveFileStream, Lista);
                SaveFileStream.Close();

                SqlConnection conexion = new SqlConnection("SERVER=localhost;DATABASE=Encuesta;Integrated Security = true;");
                conexion.Open();
                SqlCommand comando = new SqlCommand("UPDATE USUARIOS SET Voto = 'False'", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();

            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public GroupBox GroupProductos(Image Imagen, int Numero, string Nombre, string Marca, 
            int Votos, double Porcentaje)
        {

            GroupBox GroupProductos = new GroupBox();

            GroupProductos.Controls.Add(ImaProdu(Imagen));
            GroupProductos.Controls.Add(lbNumero(Numero));
            GroupProductos.Controls.Add(lbNombre(Nombre));
            GroupProductos.Controls.Add(lbMarca(Marca));
            GroupProductos.Controls.Add(lbVotos(Votos));
            GroupProductos.Controls.Add(lbPorcentaje(Porcentaje));
            GroupProductos.Size = new System.Drawing.Size(206, 280);
            GroupProductos.TabStop = false;
            GroupProductos.Text = "";

            return GroupProductos;
        }


        public PictureBox ImaProdu(Image Imagen)
        {

            PictureBox ImaProdu = new PictureBox();
            
            ImaProdu.Location = new System.Drawing.Point(36, 19);            
            ImaProdu.Size = new System.Drawing.Size(114, 101);
            ImaProdu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;            
            ImaProdu.TabStop = false;
            ImaProdu.Image = Imagen;

            return ImaProdu;
        }

        public Label lbNumero(int Numero)
        {
            Label lbNumero = new Label();

            lbNumero.AutoSize = true;
            lbNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbNumero.Location = new System.Drawing.Point(6, 137);            
            lbNumero.Size = new System.Drawing.Size(44, 16);           
            lbNumero.Text = "Numero: " + Numero;

            return lbNumero;
        }

        public Label lbNombre(string Nombre)
        {
            Label lbNombre = new Label();

            lbNombre.AutoSize = true;
            lbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbNombre.Location = new System.Drawing.Point(6, 167);            
            lbNombre.Size = new System.Drawing.Size(44, 16);            
            lbNombre.Text = "Nombre: " + Nombre;

            return lbNombre;
        }

        public Label lbMarca(string Marca)
        {

            Label lbMarca = new Label();

            lbMarca.AutoSize = true;
            lbMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbMarca.Location = new System.Drawing.Point(6, 193);            
            lbMarca.Size = new System.Drawing.Size(44, 16);           
            lbMarca.Text = "Marca: " + Marca;

            return lbMarca;
        }

        public Label lbVotos(int Votos)
        {
            Label lbVotos = new Label();

            lbVotos.AutoSize = true;
            lbVotos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbVotos.Location = new System.Drawing.Point(6, 219);            
            lbVotos.Size = new System.Drawing.Size(44, 16);            
            lbVotos.Text = "Votos: " + Votos;

            return lbVotos;
        }

        public Label lbPorcentaje(double Porcentaje)
        {

            Label lbProcentaje = new Label();

            lbProcentaje.AutoSize = true;
            lbProcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbProcentaje.Location = new System.Drawing.Point(6, 246);            
            lbProcentaje.Size = new System.Drawing.Size(177, 16);            
            lbProcentaje.Text = "Porcentaje de votacion: " + Decimal.Round((decimal)Porcentaje, 2) + "%";

            return lbProcentaje;
        }
    }
}
