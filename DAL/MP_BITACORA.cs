using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE;
using Generala_DAS;

namespace DAL
{
    public class MP_BITACORA
    {
        private ACCESO acceso;

        public void Insertar(BITACORA_BE bitacora)
        {
            acceso = new ACCESO();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id_jugador", bitacora.Id_jugador));
            parametros.Add(acceso.CrearParametro("@fecha", bitacora.Fecha));
            parametros.Add(acceso.CrearParametro("@descripcion", bitacora.Descripcion));

            acceso.Abrir();
            acceso.Escribir("insertar_bitacora", parametros);
            acceso.Cerrar();
        }

        public List<BITACORA_BE> Listar()
        {
            acceso = new ACCESO();
            acceso.Abrir();
            DataTable tabla = acceso.Listar("listar_bitacora");
            acceso.Cerrar();

            List<BITACORA_BE> lista = new List<BITACORA_BE>();
            foreach (DataRow row in tabla.Rows)
            {
                BITACORA_BE item = new BITACORA_BE();
                item.Id_bitacora = int.Parse(row["id_bitacora"].ToString());
                item.Id_jugador = int.Parse(row["id_jugador"].ToString());
                item.Usuario = row["usuario"] != DBNull.Value ? row["usuario"].ToString() : ("Jugador #" + item.Id_jugador);
                item.Fecha = DateTime.Parse(row["fecha"].ToString());
                item.Descripcion = row["descripcion"].ToString();
                lista.Add(item);
            }
            return lista;
        }
    }
}
