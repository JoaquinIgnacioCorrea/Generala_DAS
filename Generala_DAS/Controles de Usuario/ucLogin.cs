using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace Generala_DAS.Controles_de_Usuario
{
    public partial class ucLogin : UserControl
    {
        public ucLogin()
        {
            InitializeComponent();
        }

        USUARIO_BLL usuario_bll;
        USUARIO_BE usuario_be;

        private void btn_registrarse_Click(object sender, EventArgs e)
        {
            usuario_be = null;
            usuario_bll = new USUARIO_BLL();
            if (ValidarCamposLlenos())
            {
                string nombre = tb_nombre_usuario.Text;
                string contraseña = tb_contraseña.Text;
                usuario_be = usuario_bll.RegistrarUsuario(nombre, contraseña);
                if (usuario_be != null) LimpiarCampos();
                else tb_nombre_usuario.Text = "";
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
                string contraseña = tb_contraseña.Text;
                usuario_be = usuario_bll.IniciarSesion(nombre, contraseña);
                if (usuario_be != null) LimpiarCampos();
            }
            Mensaje(usuario_be != null ? "Se logeo correctamente" : "Usuario y contraseña incorrectos");
        }

        private void LimpiarCampos()
        {
            tb_nombre_usuario.Text = "";
            tb_contraseña.Text = "";
        }

        private bool ValidarCamposLlenos()
        {
            return tb_nombre_usuario.Text != "" && tb_contraseña.Text != "";
        }

        private void Mensaje(string msj)
        {
            MessageBox.Show(msj);
        }
    }
}
