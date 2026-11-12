using Generala_DAS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;

namespace DAL
{
    internal class MP_PARTIDA
    {
        ACCESO acceso;

        public void Insertar(PARTIDA_GENERALA_BE partida_p)
        {
            acceso = new ACCESO();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@jugador_actual", partida_p.JugadorActual.Id_jugador));
            parametros.Add(acceso.CrearParametro("@ganador", -1));
            parametros.Add(acceso.CrearParametro("@fecha_partida", partida_p.Fecha));
            parametros.Add(acceso.CrearParametro("@tiempo_partida", TimeSpan.Zero));
            acceso.Abrir();
            acceso.Escribir("insertar_partida", parametros);
            acceso.Cerrar();
        }

        public void Editar(PARTIDA_GENERALA_BE partida_p)
        {
            acceso = new ACCESO();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@jugador_actual",partida_p.JugadorActual.Id_jugador));
            parametros.Add(acceso.CrearParametro("@ganador",partida_p.Ganador.Id_jugador));
            parametros.Add(acceso.CrearParametro("@tiempo_partida",partida_p.DuracionPartida));
            acceso.Abrir();
            acceso.Escribir("editar_partida", parametros);
            acceso.Cerrar();
        }

        public void Borrar(PARTIDA_GENERALA_BE partida_p)
        {
            acceso = new ACCESO();
            SqlParameter parametro = new SqlParameter("@id_partida",partida_p.Id_partida);
            acceso.Abrir();
            acceso.Escribir("borrar_partida",parametro);
            acceso.Cerrar();
        }

        public List<PARTIDA_GENERALA_BE> Listar_Partidas_Usuario(int id_usuario)
        {
            acceso = new ACCESO();
            acceso.Abrir();
            DataTable tabla = acceso.Listar("listar_partidas_usuario",acceso.CrearParametro("@id_usuario", id_usuario));
            acceso.Cerrar();

            List<PARTIDA_GENERALA_BE> partidas = new List<PARTIDA_GENERALA_BE>();
            foreach (DataRow data in tabla.Rows)
            {
                PARTIDA_GENERALA_BE partida = new PARTIDA_GENERALA_BE();
                partida.Id_partida = int.Parse(data["id_partida"].ToString());
                partida.Fecha = DateTime.Parse(data["fecha_partida"].ToString());
                if (data["tiempo_partida"] != DBNull.Value)
                {
                    partida.DuracionPartida = TimeSpan.Parse(data["tiempo_partida"].ToString());
                }
                if (data["ganador"] != DBNull.Value)
                {
                    int id_jugador = int.Parse(data["ganador"].ToString());
                    partida.Ganador = MP_JUGADOR.Listar_Usuario(id_jugador);
                }
                partidas.Add(partida);
            }
            return partidas;
        }

        public PARTIDA_GENERALA_BE Obtener_Partida_Por_Id(int id_partida)
        {
            acceso = new ACCESO();
            acceso.Abrir();
            DataTable tabla = acceso.Listar("obtener_partida_por_id", acceso.CrearParametro("@id_partida", id_partida));
            acceso.Cerrar();

            PARTIDA_GENERALA_BE partida = null;
            if (tabla.Rows.Count > 0)
            {
                DataRow data = tabla.Rows[0];
                partida = new PARTIDA_GENERALA_BE();
                partida.Id_partida = int.Parse(data["id_partida"].ToString());
                partida.Fecha = DateTime.Parse(data["fecha_partida"].ToString());

                if (data["tiempo_partida"] != DBNull.Value)
                {
                    partida.DuracionPartida = TimeSpan.Parse(data["tiempo_partida"].ToString());
                }

                if (data["ganador"] != DBNull.Value)
                {
                    int id_jugador = int.Parse(data["ganador"].ToString());
                    partida.Ganador = MP_JUGADOR.Listar_Usuario(id_jugador);
                }
            }
            return partida;
        }

        public PARTIDA_GENERALA_BE Obtener_Partida_En_Juego(int id_usuario)
        {
            acceso = new ACCESO();
            acceso.Abrir();

            // Creamos la lista de parámetros con el ID del usuario actual
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id_usuario", id_usuario));

            DataTable tabla = acceso.Listar("obtener_partida_en_juego_por_usuario", parametros);
            acceso.Cerrar();

            PARTIDA_GENERALA_BE partida = null;
            if (tabla.Rows.Count > 0)
            {
                DataRow data = tabla.Rows[0];
                partida = new PARTIDA_GENERALA_BE();
                partida.Id_partida = int.Parse(data["id_partida"].ToString());
                partida.Fecha = DateTime.Parse(data["fecha_partida"].ToString());

                if (data["tiempo_partida"] != DBNull.Value)
                {
                    partida.DuracionPartida = TimeSpan.Parse(data["tiempo_partida"].ToString());
                }

                if (data["ganador"] != DBNull.Value)
                {
                    int id_jugador = int.Parse(data["ganador"].ToString());
                    partida.Ganador = MP_JUGADOR.Listar_Usuario(id_jugador);
                }
            }
            return partida;
        }

    }
}
