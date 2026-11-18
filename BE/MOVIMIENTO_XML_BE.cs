using System;

namespace BE
{
    public class MOVIMIENTO_XML_BE
    {
        public MOVIMIENTO_XML_BE()
        {
        }

        private int idPartida;
        public int IdPartida
        {
            get { return idPartida; }
            set { idPartida = value; }
        }

        private DateTime fechaHora;
        public DateTime FechaHora
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }

        private string jugador;
        public string Jugador
        {
            get { return jugador; }
            set { jugador = value; }
        }

        private int id_jugador;

        public int Id_jugador
        {
            get { return id_jugador; }
            set { id_jugador = value; }
        }

        private int ronda;
        public int Ronda
        {
            get { return ronda; }
            set { ronda = value; }
        }

        private string valoresDados;
        public string ValoresDados
        {
            get { return valoresDados; }
            set { valoresDados = value; }
        }

        private string categoriaAnotada;
        public string CategoriaAnotada
        {
            get { return categoriaAnotada; }
            set { categoriaAnotada = value; }
        }

        private int puntajeObtenido;
        public int PuntajeObtenido
        {
            get { return puntajeObtenido; }
            set { puntajeObtenido = value; }
        }
    }
}
