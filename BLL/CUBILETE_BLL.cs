using System;
using BE;

namespace BLL
{
    public class CUBILETE_BLL
    {
        private readonly DADO_BLL dado_bll = new DADO_BLL();

        public void Lanzar(CUBILETE_BE c)
        {
            if (c == null)
                throw new ArgumentNullException(nameof(c));

            foreach (DADO_BE dado in c.Dados)
            {
                dado_bll.Lanzar(dado);
            }
        }

        public void AlternarBloqueo(DADO_BE dado)
        {
            if (dado == null)
                throw new ArgumentNullException(nameof(dado));

            dado_bll.AlternarBloqueo(dado);
        }

        public void AlternarBloqueo(CUBILETE_BE c, int indiceDado)
        {
            if (c == null)
                throw new ArgumentNullException(nameof(c));

            if (indiceDado < 0 || indiceDado >= c.Dados.Count)
                throw new ArgumentOutOfRangeException(nameof(indiceDado));

            dado_bll.AlternarBloqueo(c.Dados[indiceDado]);
        }

        public void Reiniciar(CUBILETE_BE c)
        {
            if (c == null)
                throw new ArgumentNullException(nameof(c));

            foreach (DADO_BE dado in c.Dados)
            {
                dado_bll.Desbloquear(dado);
            }
        }
    }
}
