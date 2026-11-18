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
    public class MP_JUGADA
    {
        ACCESO acceso;

        public int Insertar(MOVIMIENTO_XML_BE movimiento)
        {
            acceso = new ACCESO();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@id_jugador", movimiento.Id_jugador),
                acceso.CrearParametro("@id_partida", movimiento.IdPartida),
                acceso.CrearParametro("@ronda", movimiento.Ronda),
                acceso.CrearParametro("@valores_dados", movimiento.ValoresDados),
                acceso.CrearParametro("@hora", movimiento.FechaHora),
                acceso.CrearParametro("@puntaje", movimiento.PuntajeObtenido),
                acceso.CrearParametro("@categoria", movimiento.CategoriaAnotada)
            };
            acceso.Abrir();
            int id_jugada = acceso.EscribirEscalar("insertar_jugada",parametros);
            acceso.Cerrar();
            return id_jugada;
        }

        public List<MOVIMIENTO_XML_BE> ListarJugadaXPartida(int id_partida)
        {
            acceso = new ACCESO();
            SqlParameter parametro = new SqlParameter("@id_partida", id_partida);
            acceso.Abrir();
            DataTable resultado = acceso.Listar("listar_jugadas_por_partida", parametro);
            acceso.Cerrar();
            List<MOVIMIENTO_XML_BE> movimientos = new List<MOVIMIENTO_XML_BE>();
            foreach (DataRow data in resultado.Rows)
            {
                MOVIMIENTO_XML_BE mov = new MOVIMIENTO_XML_BE();
                mov.IdPartida = int.Parse(data["id_partida"].ToString());
                mov.FechaHora = DateTime.Parse(data["hora"].ToString());
                mov.Jugador = new MP_JUGADOR().Listar_Jugador(int.Parse(data["id_jugador"].ToString())).Nombre.ToString();
                mov.Id_jugador = int.Parse(data["id_jugador"].ToString());
                mov.Ronda = int.Parse(data["ronda"].ToString());
                mov.ValoresDados = data["valores_dados"].ToString();
                mov.CategoriaAnotada = data["categoria"].ToString();
                mov.PuntajeObtenido = int.Parse(data["puntaje"].ToString());
                movimientos.Add(mov);
            }
            return movimientos;
        }

        public List<MOVIMIENTO_XML_BE> ListarJugadaXPartidaXJugador(int id_partida, int id_jugador)
        {
            acceso = new ACCESO();
            List<SqlParameter> parametros = new List<SqlParameter> 
            { 
                acceso.CrearParametro("@id_partida",id_partida),
                acceso.CrearParametro("@id_jugador",id_jugador)
            };
            acceso.Abrir();
            DataTable resultado = acceso.Listar("listar_jugadas_por_jugador_partida", parametros);
            acceso.Cerrar();
            List<MOVIMIENTO_XML_BE> movimientos = new List<MOVIMIENTO_XML_BE>();
            foreach (DataRow data in resultado.Rows)
            {
                MOVIMIENTO_XML_BE mov = new MOVIMIENTO_XML_BE();
                mov.IdPartida = int.Parse(data["id_partida"].ToString());
                mov.FechaHora = DateTime.Parse(data["hora"].ToString());
                mov.Jugador = new MP_JUGADOR().Listar_Jugador(int.Parse(data["id_jugador"].ToString())).Nombre.ToString();
                mov.Id_jugador = int.Parse(data["id_jugador"].ToString());
                mov.Ronda = int.Parse(data["ronda"].ToString());
                mov.ValoresDados = data["valores_dados"].ToString();
                mov.CategoriaAnotada = data["categoria"].ToString();
                mov.PuntajeObtenido = int.Parse(data["puntaje"].ToString());
                movimientos.Add(mov);
            }
            return movimientos;
        }
    }
}
