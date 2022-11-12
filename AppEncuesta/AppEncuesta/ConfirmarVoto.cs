using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.SqlClient;

namespace AppEncuesta
{
    public partial class ConfirmarVoto : Form
    {
        private const string FileName = @"Productos.bin";
        private List<Productos> Lista = new List<Productos>();
        int posicion = 0;
        Votar ObjVotar;
        Maestro Maestro;
        long cedula;
        SqlConnection conexion = new SqlConnection("SERVER=localhost;DATABASE=Encuesta;Integrated Security = true;");
        SqlCommand comando;

        public ConfirmarVoto(int posicion, Votar ObjVotar, Maestro Maestro, long cedula)
        {
            InitializeComponent();
            this.posicion = posicion;
            this.ObjVotar = ObjVotar;
            this.Maestro = Maestro;
            this.cedula = cedula;
        }

        private void btNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmarVoto_Load(object sender, EventArgs e)
        {
            try
            {
                Stream openFileStream = File.OpenRead(FileName);
                BinaryFormatter deserializer = new BinaryFormatter();
                Lista = (List<Productos>)deserializer.Deserialize(openFileStream);
                openFileStream.Close();

                pictureBox1.Image = Lista[posicion].getImaProducto();
                lbNumero.Text = "Numero: " + Lista[posicion].getNumero();
                lbNombre.Text = "Nombre: " + Lista[posicion].getNombre();
                lbMarca.Text = "Marca: " + Lista[posicion].getMarca();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void btSi_Click(object sender, EventArgs e)
        {
            try
            {

                Stream openFileStream = File.OpenRead(FileName);
                BinaryFormatter deserializer = new BinaryFormatter();
                Lista = (List<Productos>)deserializer.Deserialize(openFileStream);
                openFileStream.Close();

                Lista[posicion].Voto();
                Stream SaveFileStream = File.OpenWrite(FileName);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(SaveFileStream, Lista);
                SaveFileStream.Close();

                conexion.Open();

                comando = new SqlCommand("UPDATE USUARIOS SET Voto = 'True' WHERE Cedula= " + cedula, conexion);

                comando.ExecuteNonQuery();

                conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
            MessageBox.Show("Votación realizada con éxito","Éxito",MessageBoxButtons.OK,MessageBoxIcon.Information);
            ObjVotar.Close();
            Maestro.Hide();


            conexion.Open();

            comando = new SqlCommand("SELECT IDRol FROM USUARIOS WHERE Cedula = '" + cedula + "'", conexion);
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                if (reader[0].ToString() == "1")
                {
                    Maestro ObjMaestro = new Maestro(cedula);
                    this.Close();
                    ObjMaestro.Show();
                }
                else
                {
                    Login ObjLogin = new Login();
                    ObjLogin.Show();
                }
            }
        }
    }
}