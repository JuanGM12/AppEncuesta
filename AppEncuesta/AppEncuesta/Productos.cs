using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppEncuesta
{

    [Serializable()]
    internal class Productos
    {       
        private int Numero;
        private string Marca;
        private string Nombre;
        private int NumVotos;
        private Image ImaProducto;

        public Productos(int numero, string nombre, string marca, PictureBox pbImagen)
        {

            this.Numero = numero;
            this.Nombre = nombre;
            this.Marca = marca;            
            this.ImaProducto = pbImagen.Image;
            NumVotos = 0;

            
        }

        public void Voto()
        {                      
            NumVotos += 1;
        }

        public string getNombre()
        {
            return Nombre;
        }

        public Image getImaProducto()
        {
            return ImaProducto;
        }

        public int getNumero()
        {
            return Numero;
        }

        public string getMarca()
        {
            return Marca;
        }

        public int getNumVotos()
        {
            return NumVotos;
        }

        public void ReiniciarVotos()
        {
            NumVotos = 0;
        }
    }
}
