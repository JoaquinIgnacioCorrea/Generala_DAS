using System;
using System.Drawing;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Threading.Tasks;
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
            if(idJugadorActual == 0)
            {
                idJugadorActual = MostrarLogin();
            }
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

        private int MostrarLogin()
        {
            this.Hide();

            using(frmLoginUsuario login = new frmLoginUsuario())
            {
                if(login.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                    return login.usuario_be.Id_jugador;
                }
                else
                {
                    Application.Exit();
                }
                return -1;
            }

        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            if(idJugadorActual > -1)
            {
                using (frmJuego frmPartida = new frmJuego(idJugadorActual))
                {
                    frmPartida.ShowDialog(this);
                }
            }
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            if (idJugadorActual > -1)
            {
                using (frmBitacora frm = new frmBitacora())
                {
                    frm.ShowDialog(this);
                }
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

        private async void btnHostear_Click(object sender, EventArgs e)
        {
            ServidorGenerala enlace = new ServidorGenerala();
            btnHostear.Text = "esperando al rival...";
            btnHostear.BackColor = Color.FromArgb(255, 225, 135);
           
            await enlace.hostear(5000);
            
            btnHostear.Text = "rival conectado!";
            btnHostear.BackColor = System.Drawing.Color.Green;
            if(idJugadorActual > -1)
            {
                using (frmJuego frm = new frmJuego(enlace, idJugadorActual))
                {
                    frm.ShowDialog(this);
                }
            }
        }

        private async void btnUnirse_Click(object sender, EventArgs e)
        {
            string ip;
            using (frmIP popup = new frmIP())
            {
                popup.ShowDialog();
                ip = popup.ip;
            }
            
            try
            {
                ServidorGenerala enlace = new ServidorGenerala();
                
                await enlace.conectar(ip, 5000); 
                
                btnUnirse.BackColor = Color.Green;
                btnUnirse.Text = "Exito!";
                using (frmJuego frm = new frmJuego(enlace, idJugadorActual)) { frm.ShowDialog(this); }
                    

            }
            catch (SocketException)
            {
                btnUnirse.BackColor = Color.Red;
                btnUnirse.Text = "Reintentar";
            }
        }
        

        private void frmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            BACKUP_BLL b = new BACKUP_BLL();
            b.RealizarBackup();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            BACKUP_BLL b = new BACKUP_BLL();
            b.RestaurarBackup();
        }
    }
}
