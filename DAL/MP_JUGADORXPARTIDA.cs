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
    internal class MP_JUGADORXPARTIDA
    {
        private ACCESO acceso;

        public void Insertar(int id_partida, int id_jugador)
        {
            acceso = new ACCESO();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id_partida", id_partida));
            parametros.Add(acceso.CrearParametro("@id_jugador", id_jugador));
            parametros.Add(acceso.CrearParametro("@puntaje_total", 0));
            parametros.Add(acceso.CrearParametro("@resultado", "En Curso"));

            acceso.Abrir();
            acceso.Escribir("insertar_jugadorxpartida", parametros);
            acceso.Cerrar();
        }

        public void ActualizarPuntajeYResultado(int id_partida, int id_jugador, int puntajeTotal, string resultado)
        {
            acceso = new ACCESO();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id_partida", id_partida));
            parametros.Add(acceso.CrearParametro("@id_jugador", id_jugador));
            parametros.Add(acceso.CrearParametro("@puntaje_total", puntajeTotal));
            parametros.Add(acceso.CrearParametro("@resultado", resultado));

            acceso.Abrir();
            acceso.Escribir("actualizar_jugadorxpartida", parametros);
            acceso.Cerrar();
        }

        public void BorrarPorPartida(int id_partida)
        {
            acceso = new ACCESO();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id_partida", id_partida));

            acceso.Abrir();
            acceso.Escribir("borrar_jugadorxpartida", parametros);
            acceso.Cerrar();
        }

        public DataTable ObtenerDetalleJugadorEnPartida(int id_partida, int id_jugador)
        {
            acceso = new ACCESO();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id_partida", id_partida));
            parametros.Add(acceso.CrearParametro("@id_jugador", id_jugador));

            acceso.Abrir();
            DataTable tabla = acceso.Listar("obtener_detalle_jugador_partida", parametros);
            acceso.Cerrar();

            return tabla;
        }

        public DataTable ListarDetallesPorPartida(int id_partida)
        {
            acceso = new ACCESO();
            acceso.Abrir();
            DataTable tabla = acceso.Listar("listar_detalles_por_partida", acceso.CrearParametro("@id_partida", id_partida));
            acceso.Cerrar();

            return tabla;
        }
    }
}
