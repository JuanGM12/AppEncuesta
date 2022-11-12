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
    public partial class Maestro : Form
    {
        SqlConnection conexion = new SqlConnection("SERVER=localhost;DATABASE=Encuesta;Integrated Security = true;");

        private long cedula;
        private const string FileName = @"Productos.bin";
        private const string FileName2 = @"Encuesta.bin";
        private Encuestas Encuesta;
        
        public Maestro(long cedula)
        {
            InitializeComponent();
            this.cedula = cedula;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void votarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (!File.Exists(FileName))
            {
                MessageBox.Show("No se han agregado productos a la encuesta","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                Votar objVotar = new Votar(this, cedula);
                objVotar.MdiParent = this;
                objVotar.Show();
            }
            
           
        }

        private void agregarEncuestaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Stream openFileStream = File.OpenRead(FileName2);
            BinaryFormatter deserializer = new BinaryFormatter();
            Encuesta = (Encuestas)deserializer.Deserialize(openFileStream);
            openFileStream.Close();



            if (Encuesta.getEstado() == false)
            {
                AgregarProducto objAgregar = new AgregarProducto();
                objAgregar.MdiParent = this;
                objAgregar.Show();
            }
            else
            {
                MessageBox.Show("Debes finalizar la encuesta para agregar mas productos","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Maestro_Load(object sender, EventArgs e)
        {
            try
            {
                

                conexion.Open();

                SqlCommand comando = new SqlCommand("SELECT Voto, IDRol FROM USUARIOS WHERE Cedula = '" + cedula + "'", conexion);
                SqlDataReader reader = comando.ExecuteReader();

                reader.Read();

                if (reader[0].ToString() == "True")
                {
                    votarToolStripMenuItem1.Enabled = false;
                }

                if (reader[1].ToString() == "2")
                {
                    agregarEncuestaToolStripMenuItem.Visible = false;
                    finalizarEncuestaToolStripMenuItem.Visible = false;
                    crearCuentasToolStripMenuItem.Visible = false;
                    votarToolStripMenuItem1.Enabled = true;

                }

                conexion.Close();

                if (File.Exists(FileName))
                {
                    if (File.Exists(FileName2))
                    {
                        Stream openFileStream = File.OpenRead(FileName2);
                        BinaryFormatter deserializer = new BinaryFormatter();
                        Encuesta = (Encuestas)deserializer.Deserialize(openFileStream);
                        openFileStream.Close();

                        if (Encuesta.getEstado())
                        {
                            finalizarEncuestaToolStripMenuItem.Text = "Finalizar encuesta";
                            finalizarEncuestaToolStripMenuItem.Image = Properties.Resources.finalizar;

                        }
                        else
                        {
                            votarToolStripMenuItem1.Enabled = false;
                            finalizarEncuestaToolStripMenuItem.Text = "Iniciar encuesta";
                            finalizarEncuestaToolStripMenuItem.Image = Properties.Resources.iniciar;
                        }
                    }
                    else
                    {
                        finalizarEncuestaToolStripMenuItem.Text = "Iniciar encuesta";
                        finalizarEncuestaToolStripMenuItem.Image = Properties.Resources.iniciar;

                        Encuesta = new Encuestas(1, "Productos");
                        Stream SaveFileStream = File.Create(FileName2);
                        BinaryFormatter serializer = new BinaryFormatter();
                        serializer.Serialize(SaveFileStream, Encuesta);
                        SaveFileStream.Close();


                    }
                }
                else
                {
                    finalizarEncuestaToolStripMenuItem.Text = "Iniciar encuesta";
                    finalizarEncuestaToolStripMenuItem.Image = Properties.Resources.iniciar;

                    if (!File.Exists(FileName2))
                    {
                        Encuesta = new Encuestas(1, "Productos");
                        Stream SaveFileStream = File.Create(FileName2);
                        BinaryFormatter serializer = new BinaryFormatter();
                        serializer.Serialize(SaveFileStream, Encuesta);
                        SaveFileStream.Close();
                    }
                    
                }


            }
            catch (Exception eq)
            {

                MessageBox.Show(eq.Message);
            }
        }

        private void votarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void finalizarEncuestaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(FileName))
                {
                    if (finalizarEncuestaToolStripMenuItem.Text == "Finalizar encuesta")
                    {
                        if (MessageBox.Show("¿Seguro que desea finalizar la encuesta?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            Stream openFileStream = File.OpenRead(FileName2);
                            BinaryFormatter deserializer = new BinaryFormatter();
                            Encuesta = (Encuestas)deserializer.Deserialize(openFileStream);
                            Encuesta.setEstado(false);
                            openFileStream.Close();

                            Stream SaveFileStream = File.OpenWrite(FileName2);
                            BinaryFormatter serializer = new BinaryFormatter();
                            serializer.Serialize(SaveFileStream, Encuesta);
                            SaveFileStream.Close();

                            votarToolStripMenuItem1.Enabled = false;
                            finalizarEncuestaToolStripMenuItem.Text = "Iniciar encuesta";
                            finalizarEncuestaToolStripMenuItem.Image = Properties.Resources.iniciar;

                            ResultadoEncuesta objResultados = new ResultadoEncuesta();
                            objResultados.MdiParent = this;
                            objResultados.Show();
                            

                        }

                    }
                    else
                    {

                        Stream openFileStream = File.OpenRead(FileName2);
                        BinaryFormatter deserializer = new BinaryFormatter();
                        Encuesta = (Encuestas)deserializer.Deserialize(openFileStream);
                        Encuesta.setEstado(true);
                        openFileStream.Close();

                        Stream SaveFileStream = File.OpenWrite(FileName2);
                        BinaryFormatter serializer = new BinaryFormatter();
                        serializer.Serialize(SaveFileStream, Encuesta);
                        SaveFileStream.Close();
                                                
                        finalizarEncuestaToolStripMenuItem.Text = "Finalizar encuesta";
                        finalizarEncuestaToolStripMenuItem.Image = Properties.Resources.finalizar;

                        conexion.Open();

                        SqlCommand comando = new SqlCommand("SELECT Voto FROM USUARIOS WHERE Cedula = '" + cedula + "'", conexion);
                        SqlDataReader reader = comando.ExecuteReader();

                        reader.Read();

                        if (reader[0].ToString() == "False")
                        {
                            votarToolStripMenuItem1.Enabled = true;
                        }

                        conexion.Close();

                        MessageBox.Show("Encuesta iniciada con exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró el archivo de productos - Por favor ingrese productos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void salirProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void crearCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearCuenta crearCuentas = new CrearCuenta();
            crearCuentas.MdiParent = this;
            crearCuentas.Show();
        }
    }
}
