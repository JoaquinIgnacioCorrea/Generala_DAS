using System;
using BE;

namespace BLL
{
    public class CASILLERO_BLL
    {
        public void Anotar(CASILLERO_BE casillero, int puntos)
        {
            if (casillero == null)
                throw new ArgumentNullException(nameof(casillero));

            casillero.Puntaje = puntos;
            casillero.Esta_anotado = true;
        }
    }
}
