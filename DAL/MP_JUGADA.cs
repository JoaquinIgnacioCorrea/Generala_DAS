using BE;
using Generala_DAS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class MP_JUGADA
    {
        ACCESO acceso;

        public int Insertar(int id_partida, int id_jugador, int puntaje, CATEGORIAS categoria)
        {
            acceso = new ACCESO();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@id_jugador",id_jugador),
                acceso.CrearParametro("@id_partida",id_partida),
                acceso.CrearParametro("@puntaje",puntaje),
                acceso.CrearParametro("@categoria",categoria.ToString()),
                acceso.CrearParametro("@hora",DateTime.Now)
            };
            acceso.Abrir();
            int id_jugada = acceso.EscribirEscalar("insertar_jugada",parametros);
            acceso.Cerrar();
            return id_jugada;
        }

        public DataTable ListarJugadaXPartida(int id_partida)
        {
            acceso = new ACCESO();
            SqlParameter parametro = new SqlParameter("@id_partida", id_partida);
            acceso.Abrir();
            DataTable resultado = acceso.Listar("listar_jugadas_por_partida", parametro);
            acceso.Cerrar();
            return resultado;
        }

        public DataTable ListarJugadaXPartidaXJugador(int id_partida, int id_jugador)
        {
            acceso = new ACCESO();
            List<SqlParameter> parametros = new List<SqlParameter> 
            { 
                acceso.CrearParametro("@id_partida",id_partida),
                acceso.CrearParametro("@id_jugador",id_jugador)
            };
            acceso.Abrir();
            DataTable resultado = acceso.Listar("listar_jugadas_por_partida", parametros);
            acceso.Cerrar();
            return resultado;
        }
    }
}
