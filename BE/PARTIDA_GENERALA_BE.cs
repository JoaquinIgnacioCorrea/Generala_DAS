using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class PARTIDA_GENERALA_BE
    {
        public PARTIDA_GENERALA_BE()
        {
            jugadores = new List<JUGADOR_BE>();
            cubilete = new CUBILETE_BE();
            rondaActual = 0;
            indiceJugadorActual = 0;
            partidaFinalizada = false;
            fecha = DateTime.Now;
        }

        private int id_partida;

        public int Id_partida
        {
            get { return id_partida; }
            set { id_partida = value; }
        }

        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private TimeSpan duracionPartida;

        public TimeSpan DuracionPartida
        {
            get { return duracionPartida; }
            set { duracionPartida = value; }
        }


        private List<JUGADOR_BE> jugadores;
        public List<JUGADOR_BE> Jugadores
        {
            get { return jugadores; }
            set { jugadores = value; }
        }

        private CUBILETE_BE cubilete;
        public CUBILETE_BE Cubilete
        {
            get { return cubilete; }
            set { cubilete = value; }
        }

        private int indiceJugadorActual;
        public int IndiceJugadorActual
        {
            get { return indiceJugadorActual; }
            set { indiceJugadorActual = value; }
        }

        private JUGADOR_BE jugadorActual;
        public JUGADOR_BE JugadorActual
        {
            get { return jugadorActual; }
            set { jugadorActual = value; }
        }

        private TURNO_BE turnoActual;
        public TURNO_BE TurnoActual
        {
            get { return turnoActual; }
            set { turnoActual = value; }
        }

        private int rondaActual;
        public int RondaActual
        {
            get { return rondaActual; }
            set { rondaActual = value; }
        }

        private bool partidaFinalizada;
        public bool PartidaFinalizada
        {
            get { return partidaFinalizada; }
            set { partidaFinalizada = value; }
        }

        private JUGADOR_BE ganador;
        public JUGADOR_BE Ganador
        {
            get { return ganador; }
            set { ganador = value; }
        }
    }
}
