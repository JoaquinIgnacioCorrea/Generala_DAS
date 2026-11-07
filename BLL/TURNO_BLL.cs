using System;
using BE;

namespace BLL
{
    public class TURNO_BLL
    {
        public void RegistrarLanzamiento(TURNO_BE turno)
        {
            if (turno == null)
                throw new ArgumentNullException(nameof(turno));

            if (turno.SePuedeLanzar)
            {
                turno.LanzamientoActual++;
                if (turno.LanzamientoActual > 1)
                {
                    turno.Servida = false;
                }
                if (turno.LanzamientoActual >= 3)
                {
                    turno.SePuedeLanzar = false;
                }
            }
        }

        public void Finalizar(TURNO_BE turno)
        {
            if (turno == null)
                throw new ArgumentNullException(nameof(turno));

            turno.Finalizado = true;
            turno.SePuedeLanzar = false;
        }
    }
}
