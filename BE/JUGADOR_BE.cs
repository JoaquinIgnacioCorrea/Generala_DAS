using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class JUGADOR_BE
    {
        public JUGADOR_BE()
        {
            tablero = new TABLERO_BE();
        }

        private int id_jugador;
        public int Id_jugador
        {
            get { return id_jugador; }
            set { id_jugador = value; }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private TABLERO_BE tablero;
        public TABLERO_BE Tablero
        {
            get { return tablero; }
            set { tablero = value; }
        }
    }
}
