using System;
using System.Collections.Generic;
using System.Linq;

namespace Generala_DAS
{
    public class PARTIDA_GENERALA
    {
        public PARTIDA_GENERALA()
        {
            cubilete = new CUBILETE();
        }

        private List<JUGADOR> jugadores = new List<JUGADOR>();
        public IReadOnlyList<JUGADOR> Jugadores => jugadores;

        private CUBILETE cubilete;

        public CUBILETE Cubilete
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

        private JUGADOR jugadorActual;

        public JUGADOR JugadorActual
        {
            get { return jugadorActual; }
            set { jugadorActual = value; }
        }

        private TURNO turnoActual;

        public TURNO TurnoActual
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

        private JUGADOR ganador;

        public JUGADOR Ganador
        {
            get { return ganador; }
            set { ganador = value; }
        }

        public void AgregarJugador(string nombre)
        {
            if (partidaFinalizada || rondaActual > 0)
                throw new InvalidOperationException("No se pueden agregar jugadores con la partida en curso.");

            jugadores.Add(new JUGADOR(jugadores.Count + 1, nombre));
        }

        public void Iniciar()
        {
            if (jugadores.Count == 0)
                throw new InvalidOperationException("Debe haber al menos un jugador para iniciar la partida.");

            rondaActual = 1;
            indiceJugadorActual = 0;
            jugadorActual = jugadores[0];
            partidaFinalizada = false;
            ganador = null;

            cubilete.Reiniciar();
            turnoActual = new TURNO(jugadorActual);
        }

        public void TirarDados()
        {
            if (partidaFinalizada)
                throw new InvalidOperationException("La partida ya ha finalizado.");

            if (turnoActual == null)
                throw new InvalidOperationException("La partida no ha sido iniciada.");

            if (!turnoActual.SePuedeLanzar)
                throw new InvalidOperationException("No quedan tiros disponibles en este turno.");

            cubilete.Lanzar();
            turnoActual.RegistrarLanzamiento();

            if (turnoActual.Servida && CalculadorPuntaje.CalcularPuntaje(CATEGORIAS.generala, cubilete.Valores, true, jugadorActual.Tablero) > 0)
            {
                jugadorActual.Tablero.RegistrarPuntaje(CATEGORIAS.generala, 60);
                FinalizarPartida(jugadorActual);
            }
        }

        public void AlternarBloqueo(int indiceDado)
        {
            if (turnoActual == null || turnoActual.LanzamientoActual == 0)
                throw new InvalidOperationException("Debes tirar los dados al menos una vez antes de apartar.");

            cubilete.AlternarBloqueo(indiceDado);
        }

        public void AnotarJugada(CATEGORIAS categoria)
        {
            if (partidaFinalizada)
                throw new InvalidOperationException("La partida ya ha finalizado.");

            if (turnoActual == null || turnoActual.LanzamientoActual == 0)
                throw new InvalidOperationException("Debes tirar los dados al menos una vez antes de anotar.");

            if (!jugadorActual.Tablero.CasilleroDisponible(categoria))
                throw new InvalidOperationException("Esa categoría ya fue anotada.");

            int puntos = CalculadorPuntaje.CalcularPuntaje(categoria, cubilete.Valores, turnoActual.Servida, jugadorActual.Tablero);

            jugadorActual.Tablero.RegistrarPuntaje(categoria, puntos);

            turnoActual.Finalizar();
            AvanzarTurno();
        }

        private void AvanzarTurno()
        {
            
            if (jugadores.All(j => j.Tablero.Esta_completa))
            {
                FinalizarPartida();
                return;
            }

            
            indiceJugadorActual++;
            if (indiceJugadorActual >= jugadores.Count)
            {
                indiceJugadorActual = 0;
                rondaActual++;
            }

            jugadorActual = jugadores[indiceJugadorActual];

            
            cubilete.Reiniciar();
            turnoActual = new TURNO(jugadorActual);
        }

        private void FinalizarPartida(JUGADOR ganadorDirecto = null)
        {
            partidaFinalizada = true;

            if (ganadorDirecto != null)
            {
                ganador = ganadorDirecto;
            }
            else
            {
                ganador = jugadores.OrderByDescending(j => j.Tablero.Puntaje_total).FirstOrDefault();
            }
        }
    }
}

