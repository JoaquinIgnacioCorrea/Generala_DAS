using System;
using BE;
using DAL;

namespace BLL
{
    public class USUARIO_BLL
    {
        private readonly USUARIO_DAL usuario_dal = new USUARIO_DAL();
        private readonly BITACORA_BLL bitacora_bll = new BITACORA_BLL();

        public static USUARIO_BE UsuarioActual { get; set; }

        public USUARIO_BE IniciarSesion(string nombreUsuario, string password)
        {
            USUARIO_BE usuario = usuario_dal.ObtenerUsuario(nombreUsuario, password);
            if (usuario != null)
            {
                UsuarioActual = usuario;
                bitacora_bll.RegistrarEvento(usuario.Id_jugador, "Inicio de sesión");
            }
            return usuario;
        }

        public void CerrarSesion(int? idJugador = null)
        {
            int id = idJugador ?? (UsuarioActual != null ? UsuarioActual.Id_jugador : 0);
            if (id > 0)
            {
                bitacora_bll.RegistrarEvento(id, "Cierre de sesión");
            }
            UsuarioActual = null;
        }
    }
}
