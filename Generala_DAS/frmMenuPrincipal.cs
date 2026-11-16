using System;
using System.Windows.Forms;
using BE;
using BLL;

namespace Generala_DAS
{
    public partial class frmMenuPrincipal : Form
    {
        private readonly BITACORA_BLL bitacora_bll = new BITACORA_BLL();
        private readonly USUARIO_BLL usuario_bll = new USUARIO_BLL();
        private int idJugadorActual;

        public frmMenuPrincipal(int idJugador = 0)
        {
            InitializeComponent();
            idJugadorActual = idJugador > 0
                ? idJugador
                : (USUARIO_BLL.UsuarioActual != null ? USUARIO_BLL.UsuarioActual.Id_jugador : 0);
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            if(idJugadorActual == 0) MostrarLogin();
            if (idJugadorActual > 0)
            {
                try
                {
                    bitacora_bll.RegistrarEvento(idJugadorActual, "Inicio de sesión");
                }
                catch
                {
                    
                }
            }
        }

        private void MostrarLogin()
        {
            this.Hide();

            using(frmLogin login = new frmLogin())
            {
                if(login.ShowDialog() == DialogResult.OK)
                {

                    this.Show();
                }
                else
                {
                    Application.Exit();
                }
            }

        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            using (frmJuego frmPartida = new frmJuego())
            {
                frmPartida.ShowDialog(this);
            }
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            using (frmBitacora frm = new frmBitacora())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnVisorXml_Click(object sender, EventArgs e)
        {
            using (frmVisorXML frm = new frmVisorXML())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            RegistrarCierreSesion();
            this.Close();
        }

        private void frmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistrarCierreSesion();
        }

        private void RegistrarCierreSesion()
        {
            if (idJugadorActual > 0)
            {
                try
                {
                    bitacora_bll.RegistrarEvento(idJugadorActual, "Cierre de sesión");
                }
                catch
                {
                }
                idJugadorActual = 0;
            }
            else if (USUARIO_BLL.UsuarioActual != null)
            {
                try
                {
                    usuario_bll.CerrarSesion();
                }
                catch
                {
                }
            }
        }
    }
}
