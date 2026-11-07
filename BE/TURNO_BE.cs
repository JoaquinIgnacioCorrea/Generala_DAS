using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class TURNO_BE
    {
        public TURNO_BE(JUGADOR_BE jugadoractual)
        {
            jugadorActual = jugadoractual;
            lanzamientoActual = 0;
            sePuedeLanzar = true;
            finalizado = false;
            servida = true;
        }

        private JUGADOR_BE jugadorActual;
        public JUGADOR_BE JugadorActual
        {
            get { return jugadorActual; }
            set { jugadorActual = value; }
        }

        private int lanzamientoActual;
        public int LanzamientoActual
        {
            get { return lanzamientoActual; }
            set { lanzamientoActual = value; }
        }

        private bool sePuedeLanzar;
        public bool SePuedeLanzar
        {
            get { return sePuedeLanzar; }
            set { sePuedeLanzar = value; }
        }

        private bool finalizado;
        public bool Finalizado
        {
            get { return finalizado; }
            set { finalizado = value; }
        }

        private bool servida;
        public bool Servida
        {
            get { return servida; }
            set { servida = value; }
        }
    }
}
