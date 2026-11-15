using System;

namespace BE
{
    public class BITACORA_BE
    {
        private int id_bitacora;
        public int Id_bitacora
        {
            get { return id_bitacora; }
            set { id_bitacora = value; }
        }

        private int id_jugador;
        public int Id_jugador
        {
            get { return id_jugador; }
            set { id_jugador = value; }
        }

        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private DateTime fecha;
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}
