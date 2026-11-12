using System;
using System.Linq;
using BE;

namespace BLL
{
    public class PARTIDA_GENERALA_BLL
    {
        private readonly CUBILETE_BLL cubilete_bll = new CUBILETE_BLL();
        private readonly TURNO_BLL turno_bll = new TURNO_BLL();
        private readonly TABLERO_BLL tablero_bll = new TABLERO_BLL();

        public void AgregarJugador(PARTIDA_GENERALA_BE partida, string nombre)
        {
            if (partida == null)
                throw new ArgumentNullException(nameof(partida));

            if (partida.PartidaFinalizada || partida.RondaActual > 0)
                throw new InvalidOperationException("No se pueden agregar jugadores con la partida en curso.");

            partida.Jugadores.Add(new JUGADOR_BE(partida.Jugadores.Count + 1, nombre));
        }

        public void Iniciar(PARTIDA_GENERALA_BE partida)
        {
            if (partida == null)
                throw new ArgumentNullException(nameof(partida));

            if (partida.Jugadores == null || partida.Jugadores.Count == 0)
                throw new InvalidOperationException("Debe haber al menos un jugador para iniciar la partida.");

            partida.RondaActual = 1;
            partida.IndiceJugadorActual = 0;
            partida.JugadorActual = partida.Jugadores[0];
            partida.PartidaFinalizada = false;
            partida.Ganador = null;

            cubilete_bll.Reiniciar(partida.Cubilete);
            partida.TurnoActual = new TURNO_BE(partida.JugadorActual);
        }

        public void TirarDados(PARTIDA_GENERALA_BE partida)
        {
            if (partida == null)
                throw new ArgumentNullException(nameof(partida));

            if (partida.PartidaFinalizada)
                throw new InvalidOperationException("La partida ya ha finalizado.");

            if (partida.TurnoActual == null)
                throw new InvalidOperationException("La partida no ha sido iniciada.");

            if (!partida.TurnoActual.SePuedeLanzar)
                throw new InvalidOperationException("No quedan tiros disponibles en este turno.");

            cubilete_bll.Lanzar(partida.Cubilete);
            turno_bll.RegistrarLanzamiento(partida.TurnoActual);

            if (partida.TurnoActual.Servida && CalculadorPuntaje.CalcularPuntaje(CATEGORIAS.generala, partida.Cubilete.Valores, true, partida.JugadorActual.Tablero) > 0)
            {
                tablero_bll.RegistrarPuntaje(partida.JugadorActual.Tablero, CATEGORIAS.generala, 60);
                FinalizarPartida(partida, partida.JugadorActual);
            }
        }

        public void AlternarBloqueo(PARTIDA_GENERALA_BE partida, int indiceDado)
        {
            if (partida == null)
                throw new ArgumentNullException(nameof(partida));

            if (partida.TurnoActual == null || partida.TurnoActual.LanzamientoActual == 0)
                throw new InvalidOperationException("Debes tirar los dados al menos una vez antes de apartar.");

            cubilete_bll.AlternarBloqueo(partida.Cubilete, indiceDado);
        }

        public void AnotarJugada(PARTIDA_GENERALA_BE partida, CATEGORIAS categoria)
        {
            if (partida == null)
                throw new ArgumentNullException(nameof(partida));

            if (partida.PartidaFinalizada)
                throw new InvalidOperationException("La partida ya ha finalizado.");

            if (partida.TurnoActual == null || partida.TurnoActual.LanzamientoActual == 0)
                throw new InvalidOperationException("Debes tirar los dados al menos una vez antes de anotar.");

            if (!tablero_bll.CasilleroDisponible(partida.JugadorActual.Tablero, categoria))
                throw new InvalidOperationException("Esa categoría ya fue anotada.");

            int puntos = CalculadorPuntaje.CalcularPuntaje(categoria, partida.Cubilete.Valores, partida.TurnoActual.Servida, partida.JugadorActual.Tablero);

            tablero_bll.RegistrarPuntaje(partida.JugadorActual.Tablero, categoria, puntos);

            turno_bll.Finalizar(partida.TurnoActual);
            AvanzarTurno(partida);
        }

        public void AvanzarTurno(PARTIDA_GENERALA_BE partida)
        {
            if (partida == null)
                throw new ArgumentNullException(nameof(partida));

            if (partida.Jugadores.All(j => j.Tablero.Esta_completa))
            {
                FinalizarPartida(partida);
                return;
            }

            partida.IndiceJugadorActual++;
            if (partida.IndiceJugadorActual >= partida.Jugadores.Count)
            {
                partida.IndiceJugadorActual = 0;
                partida.RondaActual++;
            }

            partida.JugadorActual = partida.Jugadores[partida.IndiceJugadorActual];

            cubilete_bll.Reiniciar(partida.Cubilete);
            partida.TurnoActual = new TURNO_BE(partida.JugadorActual);
        }

        public void FinalizarPartida(PARTIDA_GENERALA_BE partida, JUGADOR_BE ganadorDirecto = null)
        {
            if (partida == null)
                throw new ArgumentNullException(nameof(partida));

            partida.PartidaFinalizada = true;

            partida.DuracionPartida = DateTime.Now - partida.Fecha;

            if (ganadorDirecto != null)
            {
                partida.Ganador = ganadorDirecto;
            }
            else
            {
                partida.Ganador = partida.Jugadores.OrderByDescending(j => j.Tablero.Puntaje_total).FirstOrDefault();
            }
        }
    }
}
