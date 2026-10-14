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
		public TURNO(JUGADOR jugadoractual) 
		{
			jugadorActual = jugadoractual;
			lanzamientoActual = 0;
			sePuedeLanzar = true;
			finalizado = false;
			servida = true;
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
		private bool servida;

		public bool Servida
		{
			get { return servida; }
			set { servida = value; }
		}




		public void RegistrarLanzamiento() 
		{
			if (sePuedeLanzar) 
			{
				lanzamientoActual++;
				if (lanzamientoActual>1) { servida = false; }
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