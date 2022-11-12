using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEncuesta
{
    [Serializable()]
    internal class Encuestas
    {

        //Esta clase se crea con el fin de poder agregar mas encuestas 
        //aparte de productos en el futuro por ejemplo: encuestas de peliculas,
        //videojuegos, comida , etc.

        private int IdEncuesta;
        private string Nombre;
        private bool Estado;

        public Encuestas(int Id, string Nombre)
        {
            this.IdEncuesta = Id;
            this.Nombre = Nombre;
            Estado = false;  
        }

        public bool getEstado()
        {
            return Estado;
        }

        public void setEstado(bool estado)
        {
            this.Estado = estado;
        }
    }
}
