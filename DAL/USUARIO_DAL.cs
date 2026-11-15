using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE;
using Generala_DAS;

namespace DAL
{
    public class USUARIO_DAL
    {
        private ACCESO acceso;

        public USUARIO_BE ObtenerUsuario(string usuario, string pass)
        {
            acceso = new ACCESO();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@nombre", usuario),
                acceso.CrearParametro("@contraseña", pass)
            };

            acceso.Abrir();
            DataTable tabla = acceso.Listar("login_usuario", parametros);
            acceso.Cerrar();

            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                USUARIO_BE u = new USUARIO_BE
                {
                    ID = int.Parse(row["id_usuario"].ToString()),
                    Usuario = row["nombre"].ToString(),
                    Pass = pass,
                    Id_jugador = row.Table.Columns.Contains("id_jugador") && row["id_jugador"] != DBNull.Value
                        ? int.Parse(row["id_jugador"].ToString())
                        : int.Parse(row["id_usuario"].ToString())
                };
                return u;
            }
            return null;
        }
    }
}
