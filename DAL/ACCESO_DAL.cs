using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Generala_DAS
{
    internal class ACCESO
    {
        private SqlConnection conexion;

        public void Abrir()
        {
            conexion = new SqlConnection();
            conexion.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Generala; Integrated Security=true";
            conexion.Open();
        }

        public void Cerrar()
        {
            conexion.Close();
            conexion = null;
            GC.Collect();
        }

        private SqlCommand CrearComando(string comando_p, List<SqlParameter>parametros = null)
        {
            SqlCommand comando = new SqlCommand(comando_p, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            if(parametros != null)
            {
                comando.Parameters.AddRange(parametros.ToArray());
            }
            return comando;
        }

        public SqlParameter CrearParametro(string nombre, string valor)
        {
            SqlParameter parametro = new SqlParameter(nombre, valor);
            parametro.DbType = DbType.String;
            return parametro;
        }

        public SqlParameter CrearParametro(string nombre, DateTime valor)
        {
            SqlParameter parametro = new SqlParameter(nombre, valor);
            parametro.DbType = DbType.DateTime;
            return parametro;
        }

        public SqlParameter CrearParametro(string nombre, TimeSpan valor)
        {
            SqlParameter parametro = new SqlParameter(nombre, valor);
            parametro.DbType = DbType.Time;
            return parametro;
        }

        public SqlParameter CrearParametro(string nombre, int valor)
        {
            SqlParameter parametro = new SqlParameter(nombre, valor);
            parametro.DbType = DbType.Int32;
            return parametro;
        }

        public int Escribir(string comando_p,List<SqlParameter> parametro = null)
        {
            SqlCommand comando = CrearComando(comando_p, parametro);
            int fila = comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            comando.Dispose();
            return fila;
        }

        public DataTable Listar(string comando_p, List<SqlParameter> parametro = null)
        {
            DataTable tabla = new DataTable();
            using (SqlDataAdapter data = new SqlDataAdapter())
            {
                data.SelectCommand = CrearComando(comando_p, parametro);
                data.Fill(tabla);
                data.Dispose();
            }
            return tabla;
        }
    }
}