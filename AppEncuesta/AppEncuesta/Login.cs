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
    public partial class Login : Form
    {

        SqlConnection conexion = new SqlConnection("SERVER=localhost;DATABASE=Encuesta;Integrated Security = true;");
        private Encuestas Encuesta;
        private const string FileName2 = @"Encuesta.bin";

        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            try
            {               

                conexion.Open();

                SqlCommand comando = new SqlCommand("SELECT Cedula, Nombre, Voto, IDRol FROM USUARIOS WHERE Cedula = '" + txtCedula.Text + "'", conexion);
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    if (long.Parse(txtCedula.Text) == long.Parse(reader[0].ToString()))
                    {

                        if (txtNombre.Text == reader[1].ToString())
                        {

                            if (reader[3].ToString() == "2")
                            {
                                if (reader[2].ToString() == "False")
                                {

                                    if (File.Exists(FileName2))
                                    {
                                        Stream openFileStream = File.OpenRead(FileName2);
                                        BinaryFormatter deserializer = new BinaryFormatter();
                                        Encuesta = (Encuestas)deserializer.Deserialize(openFileStream);
                                        openFileStream.Close();

                                        if (Encuesta.getEstado())
                                        {
                                            Maestro maestro = new Maestro(long.Parse(txtCedula.Text));
                                            maestro.Show();
                                            this.Hide();

                                        }
                                        else
                                        {
                                            MessageBox.Show("Lo Sentimos - No hay encuestas activas","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Lo Sentimos - No hay encuestas activas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                   

                                }
                                else
                                {
                                    MessageBox.Show("¡Ya votó!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                            }
                            else
                            {                                
                                Maestro maestro = new Maestro(long.Parse(txtCedula.Text));
                                maestro.Show();
                                this.Hide();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Nombre incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Cédula incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El usuario no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Error de conexión! "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                conexion.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar >= 32 && e.KeyChar < 47) ||  (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se admiten numeros!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
                return;
            }
        }
    }
}
