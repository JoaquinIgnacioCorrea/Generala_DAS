using System;

namespace BE
{
    public class CASILLERO_BE
    {
        public CASILLERO_BE(CATEGORIAS cat)
        {
            categoria = cat;
            puntaje = 0;
            esta_anotado = false;
        }

        private CATEGORIAS categoria;
        public CATEGORIAS Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        private int puntaje;
        public int Puntaje
        {
            get { return puntaje; }
            set { puntaje = value; }
        }

        private bool esta_anotado;
        public bool Esta_anotado
        {
            get { return esta_anotado; }
            set { esta_anotado = value; }
        }
    }
}
