using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL
{
    public class ESTADISTICA_BLL
    {
        private readonly MP_ESTADISTICA mp_stat = new MP_ESTADISTICA();

        public ESTADISTICA_BE ObtenerEstadisticas(int idJugador)
        {
            if (idJugador == 0)
                throw new ArgumentException("El id es invalido");
            ESTADISTICA_BE stats = mp_stat.ObtenerEstadisticasJugador(idJugador);
            stats.PromVictorias = stats.Jugadas >0 ? (stats.Ganadas*100/stats.Jugadas) : 0;
            return stats;
        }

       
    }
}
