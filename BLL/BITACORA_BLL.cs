using System;
using System.Collections.Generic;
using BE;
using DAL;

namespace BLL
{
    public class BITACORA_BLL
    {
        private readonly MP_BITACORA mp_bitacora = new MP_BITACORA();

        public void RegistrarEvento(int idJugador, string evento)
        {
            if (idJugador <= 0)
                return;

            BITACORA_BE registro = new BITACORA_BE
            {
                Id_jugador = idJugador,
                Fecha = DateTime.Now,
                Descripcion = evento
            };

            mp_bitacora.Insertar(registro);
        }

        public List<BITACORA_BE> ListarEventos()
        {
            return mp_bitacora.Listar();
        }
    }
}
