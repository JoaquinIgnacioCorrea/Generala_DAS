using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE;
using Generala_DAS;

namespace DAL
{
    public class MP_USUARIO
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

        public void Insertar(USUARIO_BE usuario_p)
        {
            acceso = new ACCESO();
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                acceso.CrearParametro("@nombre",usuario_p.Usuario),
                acceso.CrearParametro("@contraseña",usuario_p.Pass)
            };
            acceso.Abrir();
            int id = acceso.EscribirEscalar("alta_usuario", parametros);
            acceso.Cerrar();
            usuario_p.ID = id;
        }

        public void Borrar(USUARIO_BE usuario_p)
        {
            acceso = new ACCESO();
            SqlParameter parametro = new SqlParameter("@id_usuario", usuario_p.ID);
            acceso.Abrir();
            acceso.Escribir("baja_usuario", parametro);
            acceso.Cerrar();
        }

        public void Editar(int id, string nombre, string password)
        {
            acceso = new ACCESO();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@id_usuario",id),
                acceso.CrearParametro("@nombre",nombre),
                acceso.CrearParametro("@contraseña",password)
            };
            acceso.Abrir();
            acceso.Escribir("modificar_usuario", parametros);
            acceso.Cerrar();
        }
        public void Editar(USUARIO_BE usuario_p)
        {
            acceso = new ACCESO();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                acceso.CrearParametro("@id_usuario",usuario_p.ID),
                acceso.CrearParametro("@nombre",usuario_p.Usuario),
                acceso.CrearParametro("@contraseña",usuario_p.Pass)
            };
            acceso.Abrir();
            acceso.Escribir("modificar_usuario", parametros);
            acceso.Cerrar();
        }

        public bool VerificarNombreUsuario(string nombre)
        {
            acceso = new ACCESO();
            SqlParameter parametro = new SqlParameter("@nombre", nombre);
            acceso.Abrir();
            DataTable tabla = acceso.Listar("verificar_nombre_usuario", parametro);
            acceso.Cerrar();
            return tabla.Rows.Count > 0 ? false : true;
        }
    }
}
