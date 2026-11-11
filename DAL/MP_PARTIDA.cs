using Generala_DAS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class MP_PARTIDA
    {
        ACCESO acceso;

        public void Insertar(BE.PARTIDA_GENERALA_BE partida_p)
        {
            acceso = new ACCESO();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@jugador_actual", partida_p.JugadorActual.Id_jugador));
            if(partida_p.Ganador != null)
            {
                parametros.Add(acceso.CrearParametro("@ganador",partida_p.Ganador.Id_jugador));
            }
            else
            {
                parametros.Add(acceso.CrearParametro("@ganador", -1));
            }
            parametros.Add(acceso.CrearParametro("@fecha_partida", partida_p.Fecha));
            parametros.Add(acceso.CrearParametro("@tiempo_partida", TimeSpan.Zero));
            acceso.Abrir();
            acceso.Escribir("insertar_partida", parametros);
            acceso.Cerrar();
        }

        public void Editar(BE.PARTIDA_GENERALA_BE partida_p)
        {

        }

    }
}
