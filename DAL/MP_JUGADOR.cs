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
    internal class MP_JUGADOR
    {
        private ACCESO acceso;

        // INSERTAR JUGADOR
        public void Insertar(JUGADOR_BE jugador)
        {
            acceso = new ACCESO();
            List<SqlParameter> parametros = new List<SqlParameter>();

            // Asumiendo campos estándar de un jugador (nombre, usuario, etc.)
            parametros.Add(acceso.CrearParametro("@nombre", jugador.Nombre));

            acceso.Abrir();
            acceso.Escribir("insertar_jugador", parametros);
            acceso.Cerrar();
        }

        // EDITAR JUGADOR
        public void Editar(JUGADOR_BE jugador)
        {
            acceso = new ACCESO();
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(acceso.CrearParametro("@id_jugador", jugador.Id_jugador));
            parametros.Add(acceso.CrearParametro("@nombre", jugador.Nombre));

            acceso.Abrir();
            acceso.Escribir("editar_jugador", parametros);
            acceso.Cerrar();
        }

        // BORRAR JUGADOR
        public void Borrar(JUGADOR_BE jugador)
        {
            acceso = new ACCESO();
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(acceso.CrearParametro("@id_jugador", jugador.Id_jugador));

            acceso.Abrir();
            acceso.Escribir("borrar_jugador", parametros);
            acceso.Cerrar();
        }

        // OBTENER JUGADOR POR ID (Fundamental para reconstruir objetos relacionados)
        public JUGADOR_BE Listar_Usuario(int id_jugador)
        {
            acceso = new ACCESO();
            acceso.Abrir();

            DataTable tabla = acceso.Listar("obtener_jugador_por_id", acceso.CrearParametro("@id_jugador", id_jugador));
            acceso.Cerrar();

            JUGADOR_BE jugador = null;
            if (tabla.Rows.Count > 0)
            {
                DataRow data = tabla.Rows[0];
                jugador = new JUGADOR_BE();
                jugador.Id_jugador = int.Parse(data["id_jugador"].ToString());
                jugador.Nombre = data["nombre"].ToString();
                // Mapear el resto de propiedades de tu BE si las hubiera
            }
            return jugador;
        }

        // LISTAR TODOS LOS JUGADORES (Útil para selección general en la interfaz)
        public List<JUGADOR_BE> ListarTodos()
        {
            acceso = new ACCESO();
            acceso.Abrir();

            DataTable tabla = acceso.Listar("listar_todos_jugadores");
            acceso.Cerrar();

            List<JUGADOR_BE> listaJugadores = new List<JUGADOR_BE>(); // Ajustar nombre de clase BE si difiere
            foreach (DataRow data in tabla.Rows)
            {
                JUGADOR_BE jugador = new JUGADOR_BE();
                jugador.Id_jugador = int.Parse(data["id_jugador"].ToString());
                jugador.Nombre = data["nombre"].ToString();

                listaJugadores.Add(jugador);
            }
            return listaJugadores;
        }
    }
}
