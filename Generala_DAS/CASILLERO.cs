using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generala_DAS
{
    public class CASILLERO
    {
        public CASILLERO(CATEGORIAS cat)
        {
			categoria = cat;
			puntaje = 0;
			esta_anotado = false;
        }

		private CATEGORIAS categoria;

		public CATEGORIAS Categoria
		{
			get { return categoria; }
		}

		private int puntaje;

		public int Puntaje
		{
			get { return puntaje; }
		}

		private bool esta_anotado;

		public bool Esta_anotado
		{
			get { return esta_anotado; }
		}

		public void Anotar(int puntos)
		{
			puntaje = puntos;
			esta_anotado = true;
		}
    }
}