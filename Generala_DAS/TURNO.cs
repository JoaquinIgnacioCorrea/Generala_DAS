using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Generala_DAS
{
    public class TURNO
    {
		TURNO(JUGADOR jugadoractual) 
		{
			jugadorActual = jugadoractual;
			lanzamientoActual = 1;
			sePuedeLanzar = true;
			finalizado = false;
		
		}
		private JUGADOR jugadorActual;

		public JUGADOR JugadorActual
		{
			get { return jugadorActual; }
			set { jugadorActual = value; }
		}
		private int lanzamientoActual;

		public int LanzamientoActual
		{
			get { return lanzamientoActual; }
		}
		private bool sePuedeLanzar;

		public bool SePuedeLanzar
		{
			get { return sePuedeLanzar; }
		}
		private bool finalizado;

		public bool Finalizado
		{
			get { return finalizado; }
		}

		public void RegistrarLanzamiento() 
		{
			if (sePuedeLanzar) 
			{
				lanzamientoActual++;
				if (lanzamientoActual == 3) { sePuedeLanzar = false;  }
			}
		}
		public void Finalizar()
		{
			finalizado = true;
			sePuedeLanzar = false;
		}



	}
}