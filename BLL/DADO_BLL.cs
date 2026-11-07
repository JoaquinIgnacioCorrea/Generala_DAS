using System;
using BE;

namespace BLL
{
    public class DADO_BLL
    {
        private static readonly Random rnd = new Random();

        public void Lanzar(DADO_BE d)
        {
            if (d == null)
                throw new ArgumentNullException(nameof(d));

            if (!d.Bloqueado)
            {
                d.Valor = rnd.Next(1, 7);
            }
        }

        public void AlternarBloqueo(DADO_BE d)
        {
            if (d == null)
                throw new ArgumentNullException(nameof(d));

            d.Bloqueado = !d.Bloqueado;
        }

        public void Bloquear(DADO_BE d)
        {
            if (d == null)
                throw new ArgumentNullException(nameof(d));

            d.Bloqueado = true;
        }

        public void Desbloquear(DADO_BE d)
        {
            if (d == null)
                throw new ArgumentNullException(nameof(d));

            d.Bloqueado = false;
        }
    }
}
