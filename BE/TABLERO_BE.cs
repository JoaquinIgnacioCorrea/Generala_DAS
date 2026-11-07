using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class TABLERO_BE
    {
        public TABLERO_BE()
        {
            casilleros = new Dictionary<CATEGORIAS, CASILLERO_BE>();

            foreach (CATEGORIAS cat in Enum.GetValues(typeof(CATEGORIAS)))
            {
                casilleros.Add(cat, new CASILLERO_BE(cat));
            }
            puntaje_total = 0;
            esta_completa = false;
        }

        private int puntaje_total;
        public int Puntaje_total
        {
            get { return puntaje_total; }
            set { puntaje_total = value; }
        }

        private bool esta_completa;
        public bool Esta_completa
        {
            get { return esta_completa; }
            set { esta_completa = value; }
        }

        private Dictionary<CATEGORIAS, CASILLERO_BE> casilleros;
        public Dictionary<CATEGORIAS, CASILLERO_BE> Casilleros
        {
            get { return casilleros; }
            set { casilleros = value; }
        }
    }
}
