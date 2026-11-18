using BE;
using BLL;
using System;

using System.Windows.Forms;

namespace Generala_DAS
{
    public partial class frmLoginUsuario : Form
    {
        public frmLoginUsuario()
        {
            InitializeComponent();
        }
        USUARIO_BLL usuario_bll;
        public USUARIO_BE usuario_be { get; private set; }

        private void btn_registrarse_Click(object sender, EventArgs e)
        {
            usuario_be = null;
            usuario_bll = new USUARIO_BLL();
            if (ValidarCamposLlenos())
            {
                string nombre = tb_nombre_usuario.Text;
                string pass = tb_contraseña.Text;
                usuario_be = usuario_bll.RegistrarUsuario(nombre, pass);
                if (usuario_be != null)
                {
                    LimpiarCampos();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else tb_nombre_usuario.Text = "";
            }
            else
            {
                Mensaje("Los campos no pueden estar vacios");
                return;
            }
            Mensaje(usuario_be != null ? "Se registro el usuario" : "El nombre de usuario ya esta en uso");
        }

        private void btn_iniciar_sesion_Click(object sender, EventArgs e)
        {
            usuario_be = null;
            usuario_bll = new USUARIO_BLL();
            if (ValidarCamposLlenos())
            {
                string nombre = tb_nombre_usuario.Text;
                string pass = tb_contraseña.Text;
                usuario_be = usuario_bll.IniciarSesion(nombre, pass);
                if (usuario_be != null)
                {
                    LimpiarCampos();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                Mensaje("Los campos no pueden estar vacios");
                return;
            }
            Mensaje(usuario_be != null ? "Se logeo correctamente" : "Usuario y contraseña incorrectos");
        }

        private void LimpiarCampos()
        {
            tb_nombre_usuario.Text = "";
            lbl_contraseña.Text = "";
        }

        private bool ValidarCamposLlenos()
        {
            return tb_nombre_usuario.Text != "" && lbl_contraseña.Text != "";
        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj);
        }
    }
}
