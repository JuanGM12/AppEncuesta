using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppEncuesta
{
    public partial class CrearCuenta : Form
    {
        public CrearCuenta()
        {
            InitializeComponent();
        }

        SqlCommand comando;

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDocumento.Text == "")
                {
                    lbAdver.Text = "El documento no puede estar vacío!";
                }

                else if (txtNombre.Text == "")
                {
                    lbAdver.Text = "El nombre no puede estar vacío!";
                }
                else
                {
                    SqlConnection conexion = new SqlConnection("SERVER=localhost;DATABASE=Encuesta;Integrated Security = true;");

                    conexion.Open();

                    comando = new SqlCommand("SELECT Cedula FROM USUARIOS WHERE Cedula = '" + txtDocumento.Text + "'", conexion);
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        MessageBox.Show("¡El usuario ya existe!");
                        conexion.Close();
                    }
                    else
                    {
                        conexion.Close();
                        conexion.Open();
                        comando = new SqlCommand("INSERT INTO USUARIOS VALUES (" + txtDocumento.Text + ",'" + txtNombre.Text + "',0, 2)", conexion);
                        comando.ExecuteNonQuery();

                        MessageBox.Show("¡Registro exitoso!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();

                        conexion.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar >= 32 && e.KeyChar < 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se admiten numeros!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
                return;
            }
        }
    }
}
