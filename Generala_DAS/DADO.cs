using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generala_DAS
{
    public class DADO
    {
		private int valor;

		public int Valor
		{
			get { return valor; }
			
		}
		private bool bloqueado;

		public bool Bloqueado
		{
			get { return bloqueado; }
			set { bloqueado = value; }
		}

        private static readonly Random rnd = new Random();

		public void Lanzar()
		{
			if (!bloqueado)
			{
				valor = rnd.Next(1, 7);
			}
		}
		public void Bloquear() { bloqueado = true; }
        public void Desbloquear() { bloqueado = false; }

    }
}
