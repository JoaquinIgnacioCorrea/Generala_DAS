using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generala_DAS
{
    public class TABLERO
    {
        public TABLERO()
        {
            casilleros = new Dictionary<CATEGORIAS, CASILLERO>();

			foreach(CATEGORIAS cat in Enum.GetValues(typeof(CATEGORIAS)))
			{
				casilleros.Add(cat, new CASILLERO(cat));
			}
			puntaje_total = 0;
			esta_completa = false;
        }

        private int puntaje_total;

		public int Puntaje_total
		{
			get { return puntaje_total; }
		}

		private bool esta_completa;

		public bool Esta_completa
		{
			get { return esta_completa; }
		}

		private Dictionary<CATEGORIAS, CASILLERO> casilleros;

		public Dictionary<CATEGORIAS, CASILLERO> Casilleros
		{
			get { return casilleros; }
			set { casilleros = value; }
		}
		public bool DobleHabilitada
		{
			get 
			{ 
				return casilleros.ContainsKey(CATEGORIAS.generala) 
					&& casilleros[CATEGORIAS.generala].Esta_anotado 
					&& casilleros[CATEGORIAS.generala].Puntaje > 0; 
			}
		}

		public bool CasilleroDisponible(CATEGORIAS categoria)
		{
			return casilleros.ContainsKey(categoria) && casilleros[categoria].Esta_anotado == false;
		}

		public void RegistrarPuntaje(CATEGORIAS categoria, int puntaje)
		{
			if (!esta_completa && casilleros.ContainsKey(categoria) && CasilleroDisponible(categoria))
			{
				casilleros[categoria].Anotar(puntaje);
			}
			CalcularPuntajeTotal();
			TableroCompleto();
        }

		private void CalcularPuntajeTotal()
		{
            puntaje_total = 0;
            foreach (CASILLERO casillero in casilleros.Values)
            {
                puntaje_total += casillero.Puntaje;
            }
        }

		private void TableroCompleto()
		{
			esta_completa = casilleros.Values.All(v => v.Esta_anotado == true);
		}

		//private void DobleHabilitada() {}
    }
}