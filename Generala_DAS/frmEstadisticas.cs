using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace Generala_DAS
{
    public partial class frmEstadisticas : Form
    {
        public frmEstadisticas(int idJugador)
        {
            InitializeComponent();
            ActualizarStats(idJugador);
        }
        public void ActualizarStats(int idJugador)
        {
            ESTADISTICA_BLL estadisticas_bll = new ESTADISTICA_BLL();
            ESTADISTICA_BE s = estadisticas_bll.ObtenerEstadisticas(idJugador);

            lblUser.Text = $"Estadisticas de: {s.NombreJugador}";
            lblWins.Text = $"Victorias: {s.Ganadas}";
            lblLosses.Text = $"Derrotas: {s.Perdidas}";
            lblTie.Text = $"Empates: {s.Empatadas}";
            lblProm.Text = $"Promedio Victorias: {s.PromVictorias}";
            lblTiempo.Text = $"Tiempo de juego: {s.TiempoJuego} horas";

        }
    }
}
