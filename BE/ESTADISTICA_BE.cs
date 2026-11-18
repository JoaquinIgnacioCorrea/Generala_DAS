using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ESTADISTICA_BE
    {
		private int idJugador;

		public int IdJugador
		{
			get { return idJugador; }
			set { idJugador = value; }
		}
		private string nombreJugador;

		public string NombreJugador
		{
			get { return nombreJugador; }
			set { nombreJugador = value; }
		}
		private int jugadas;

		public int Jugadas
		{
			get { return jugadas; }
			set { jugadas = value; }
		}
		private int ganadas;

		public int Ganadas
		{
			get { return ganadas; }
			set { ganadas = value; }
		}
		private int perdidas;

		public int Perdidas
		{
			get { return perdidas; }
			set { perdidas = value; }
		}
		private int empatadas;

		public int Empatadas
		{
			get { return empatadas; }
			set { empatadas = value; }
		}
		private float promVictorias;

		public float PromVictorias
		{
			get { return promVictorias; }
			set { promVictorias = value; }
		}
		private TimeSpan tiempoJuego;

		public TimeSpan TiempoJuego
		{
			get { return tiempoJuego; }
			set { tiempoJuego = value; }
		}


	}
}
