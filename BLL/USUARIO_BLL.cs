using System;
using BE;
using DAL;

namespace BLL
{
    public class USUARIO_BLL
    {
        private readonly MP_USUARIO usuario_dal = new MP_USUARIO();
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

        public USUARIO_BE RegistrarUsuario(string nombreUsuario, string password)
        {
            USUARIO_BE usuario = null;
            if (usuario_dal.VerificarNombreUsuario(nombreUsuario))
            {
                usuario = new USUARIO_BE()
                {
                    Usuario = nombreUsuario,
                    Pass = password,
                    Id_jugador = int.Parse(new MP_JUGADOR().Insertar(nombreUsuario).ToString())
                };
                usuario_dal.Insertar(usuario);
                UsuarioActual = usuario;
                bitacora_bll.RegistrarEvento(usuario.Id_jugador, "Usuario registrado");
            }
            return usuario;
        }

        public USUARIO_BE ModificarUsuario(string nuevoNombreUsuario = null, string nuevaPassword = null)
        {
            USUARIO_BE usuario = null;


            bool cambioNombre = !string.IsNullOrEmpty(nuevoNombreUsuario) && nuevoNombreUsuario != UsuarioActual.Usuario;
            bool cambioPass = !string.IsNullOrEmpty(nuevaPassword) && nuevaPassword != UsuarioActual.Pass;

            if ((cambioNombre && usuario_dal.VerificarNombreUsuario(nuevoNombreUsuario)) || cambioPass )
            {
                usuario = new USUARIO_BE
                {
                    ID = UsuarioActual.ID,
                    Usuario = !string.IsNullOrEmpty(nuevoNombreUsuario) ? nuevoNombreUsuario : UsuarioActual.Usuario,
                    Pass = !string.IsNullOrEmpty(nuevaPassword) ? nuevaPassword : UsuarioActual.Pass,
                    Id_jugador = UsuarioActual.Id_jugador
                };
                usuario_dal.Editar(usuario);
                UsuarioActual = usuario;
                bitacora_bll.RegistrarEvento(usuario.Id_jugador, "Usuario modifico sus datos");
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
