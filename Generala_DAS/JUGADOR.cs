using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generala_DAS
{
    public class JUGADOR
    {
        public JUGADOR(int id, string nom)
        {
            tablero = new TABLERO();
			id_jugador = id;
			nombre = nom;
        }

        private int id_jugador;

		public int Id_jugador
		{
			get { return id_jugador; }
		}

		private string nombre;

		public string Nombre
		{
			get { return nombre; }
		}

		private TABLERO tablero;

		public TABLERO Tablero
		{
			get { return tablero; }
		}

	}
}