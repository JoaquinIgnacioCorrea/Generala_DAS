using Generala_DAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class MP_ESTADISTICA
    {

        ACCESO acceso;

        public ESTADISTICA_BE ObtenerEstadisticasJugador(int idJugador)
        {
            acceso = new ACCESO();
            SqlParameter parametro = new SqlParameter("@id_jugador", idJugador);

            acceso.Abrir();
            DataRow resultado = acceso.Listar("obtener_estadisticas_por_jugador", parametro).Rows[0];
            acceso.Cerrar();

            ESTADISTICA_BE stat = new ESTADISTICA_BE() 
            {
                Ganadas = int.Parse(resultado["ganadas"].ToString()),
                Perdidas = int.Parse(resultado["perdidas"].ToString()),
                Empatadas = int.Parse(resultado["empatadas"].ToString()),
                IdJugador = idJugador,
                NombreJugador = resultado["jugador"].ToString(),
                Jugadas = int.Parse(resultado["partidas_jugadas"].ToString()),
                PromVictorias = float.Parse(resultado["porcentaje_victorias"].ToString()),
                TiempoJuego = TimeSpan.Parse(resultado["tiempo_total_segundos"].ToString())
            };
            return stat;
        }

        public List<ESTADISTICA_BE>ObtenerEstadisticasJugadores()
        {
            acceso = new ACCESO();

            acceso.Abrir();
            DataTable resultados = acceso.Listar("obtener_estadisticas_jugadores");
            acceso.Cerrar();

            List<ESTADISTICA_BE> estadisticas = new List<ESTADISTICA_BE>();

            foreach (DataRow fila in resultados.Rows)
            {
                ESTADISTICA_BE stat = new ESTADISTICA_BE()
                {
                    Ganadas = int.Parse(fila["ganadas"].ToString()),
                    Perdidas = int.Parse(fila["perdidas"].ToString()),
                    Empatadas = int.Parse(fila["empatadas"].ToString()),
                    IdJugador = int.Parse(fila["id_jugador"].ToString()),
                    NombreJugador = fila["jugador"].ToString(),
                    Jugadas = int.Parse(fila["partidas_jugadas"].ToString()),
                    PromVictorias = float.Parse(fila["porcentaje_victorias"].ToString()),
                    TiempoJuego = TimeSpan.Parse(fila["tiempo_total_segundos"].ToString())
                };

                estadisticas.Add(stat);
            }
            return estadisticas;
        }


    }
}
