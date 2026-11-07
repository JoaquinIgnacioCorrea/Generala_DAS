using System;

namespace BE
{
    public class DADO_BE
    {
        public DADO_BE()
        {
            valor = 1;
            bloqueado = false;
        }

        public DADO_BE(int valorInicial)
        {
            valor = valorInicial;
            bloqueado = false;
        }

        private int valor;
        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        private bool bloqueado;
        public bool Bloqueado
        {
            get { return bloqueado; }
            set { bloqueado = value; }
        }
    }
}
