using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using DAL;

namespace BLL
{
    public class PARTIDA_GENERALA_BLL
    {
        private readonly CUBILETE_BLL cubilete_bll = new CUBILETE_BLL();
        private readonly TURNO_BLL turno_bll = new TURNO_BLL();
        private readonly TABLERO_BLL tablero_bll = new TABLERO_BLL();
        private readonly XML_MOVIMIENTOS xml_movimientos = new XML_MOVIMIENTOS();
        private readonly MP_JUGADA mp_jugada = new MP_JUGADA();
        private readonly MP_PARTIDA mp_partida = new MP_PARTIDA();
        private readonly MP_JUGADORXPARTIDA mp_jxp = new MP_JUGADORXPARTIDA();

        public void AgregarJugador(PARTIDA_GENERALA_BE partida, int id_jugador_p)
        {
            if (partida == null)
                throw new ArgumentNullException(nameof(partida));

            if (partida.PartidaFinalizada || partida.RondaActual > 0)
                throw new InvalidOperationException("No se pueden agregar jugadores con la partida en curso.");

            if (id_jugador_p <= 0)
                id_jugador_p = new MP_JUGADOR().ObtenerOCrearInvitado();

            JUGADOR_BE jugador = new MP_JUGADOR().Listar_Jugador(id_jugador_p);
            if (jugador == null)
                throw new InvalidOperationException("El jugador no existe.");

            partida.Jugadores.Add(jugador);
        }

        public void Iniciar(PARTIDA_GENERALA_BE partida)
        {
            if (partida == null)
                throw new ArgumentNullException(nameof(partida));

            if (partida.Jugadores == null || partida.Jugadores.Count == 0)
                throw new InvalidOperationException("Debe haber al menos un jugador para iniciar la partida.");

            if (partida.Id_partida <= 0)
            {
                mp_partida.Insertar(partida);
                foreach (JUGADOR_BE jugador in partida.Jugadores)
                {
                    mp_jxp.Insertar(partida.Id_partida, jugador.Id_jugador);
                }
            }


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

            
            RegistrarMovimientoEnXml(
                partida,
                $"Tirada #{partida.TurnoActual.LanzamientoActual}",
                0);

            if (partida.TurnoActual.Servida && CalculadorPuntaje.CalcularPuntaje(CATEGORIAS.generala, partida.Cubilete.Valores, true, partida.JugadorActual.Tablero) > 0)
            {
                tablero_bll.RegistrarPuntaje(partida.JugadorActual.Tablero, CATEGORIAS.generala, 60);

                
                RegistrarMovimientoEnXml(partida, CATEGORIAS.generala.ToString(), 60);

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

        public List<MOVIMIENTO_XML_BE> AnotarJugada(PARTIDA_GENERALA_BE partida, CATEGORIAS categoria)
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

            
            MOVIMIENTO_XML_BE mov = RegistrarMovimientoEnXml(partida, categoria.ToString(), puntos);

            turno_bll.Finalizar(partida.TurnoActual);
            List<MOVIMIENTO_XML_BE> movimientos = null;
            if (partida.TurnoActual.Finalizado)
            {
                mp_jugada.Insertar(mov);
                movimientos = mp_jugada.ListarJugadaXPartida(partida.Id_partida);
            }
            AvanzarTurno(partida);
            return movimientos;
        }

        private MOVIMIENTO_XML_BE RegistrarMovimientoEnXml(PARTIDA_GENERALA_BE partida, string categoriaAnotada, int puntajeObtenido)
        {
            if (partida.Id_partida <= 0)
                throw new InvalidOperationException("La partida no tiene ID valido");
            int idPartida = partida.Id_partida;
            MOVIMIENTO_XML_BE mov = new MOVIMIENTO_XML_BE
            {

                IdPartida = idPartida,
                FechaHora = DateTime.Now,
                Jugador = partida.JugadorActual != null ? partida.JugadorActual.Nombre : string.Empty,
                Id_jugador = partida.JugadorActual.Id_jugador,
                Ronda = partida.RondaActual,
                ValoresDados = partida.Cubilete != null && partida.Cubilete.Valores != null
                    ? string.Join("-", partida.Cubilete.Valores)
                    : string.Empty,
                CategoriaAnotada = categoriaAnotada,
                PuntajeObtenido = puntajeObtenido
            };

            string rutaArchivo = xml_movimientos.ObtenerRutaArchivo(idPartida);
            xml_movimientos.GuardarMovimiento(mov, rutaArchivo);
            return mov;
        }

        public List<MOVIMIENTO_XML_BE> LeerMovimientosXml(string rutaArchivo)
        {
            return xml_movimientos.LeerMovimientos(rutaArchivo);
        }

        public string ObtenerCarpetaPartidasXml()
        {
            return xml_movimientos.ObtenerCarpetaPartidas();
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
