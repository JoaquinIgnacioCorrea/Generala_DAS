using System;
using System.Linq;
using BE;

namespace BLL
{
    public class TABLERO_BLL
    {
        private readonly CASILLERO_BLL casillero_bll = new CASILLERO_BLL();

        public bool DobleHabilitada(TABLERO_BE tablero)
        {
            if (tablero == null)
                throw new ArgumentNullException(nameof(tablero));

            return tablero.Casilleros.ContainsKey(CATEGORIAS.generala)
                && tablero.Casilleros[CATEGORIAS.generala].Esta_anotado
                && tablero.Casilleros[CATEGORIAS.generala].Puntaje > 0;
        }

        public bool CasilleroDisponible(TABLERO_BE tablero, CATEGORIAS categoria)
        {
            if (tablero == null)
                throw new ArgumentNullException(nameof(tablero));

            return tablero.Casilleros.ContainsKey(categoria) && !tablero.Casilleros[categoria].Esta_anotado;
        }

        public void RegistrarPuntaje(TABLERO_BE tablero, CATEGORIAS categoria, int puntaje)
        {
            if (tablero == null)
                throw new ArgumentNullException(nameof(tablero));

            if (!tablero.Esta_completa && CasilleroDisponible(tablero, categoria))
            {
                casillero_bll.Anotar(tablero.Casilleros[categoria], puntaje);
            }
            CalcularPuntajeTotal(tablero);
            ActualizarTableroCompleto(tablero);
        }

        public void CalcularPuntajeTotal(TABLERO_BE tablero)
        {
            if (tablero == null)
                throw new ArgumentNullException(nameof(tablero));

            int total = 0;
            foreach (CASILLERO_BE casillero in tablero.Casilleros.Values)
            {
                total += casillero.Puntaje;
            }
            tablero.Puntaje_total = total;
        }

        public void ActualizarTableroCompleto(TABLERO_BE tablero)
        {
            if (tablero == null)
                throw new ArgumentNullException(nameof(tablero));

            tablero.Esta_completa = tablero.Casilleros.Values.All(v => v.Esta_anotado);
        }

        public int ObtenerPuntaje(TABLERO_BE tablero, CATEGORIAS categoria)
        {
            if (tablero == null)
                throw new ArgumentNullException(nameof(tablero));

            if (tablero.Casilleros.ContainsKey(categoria))
            {
                return tablero.Casilleros[categoria].Puntaje;
            }
            return 0;
        }
    }
}
