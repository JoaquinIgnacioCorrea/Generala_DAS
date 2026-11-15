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

        public JUGADOR_BE(int idJugador, string nombreJugador) : this()
        {
            id_jugador = idJugador;
            nombre = nombreJugador;
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
