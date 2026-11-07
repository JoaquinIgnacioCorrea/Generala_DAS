using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class CUBILETE_BE
    {
        public CUBILETE_BE()
        {
            dados = new List<DADO_BE>();
            for (int i = 0; i < 5; i++)
            {
                dados.Add(new DADO_BE());
            }
        }

        private List<DADO_BE> dados;
        public List<DADO_BE> Dados
        {
            get { return dados; }
            set { dados = value; }
        }

        public IReadOnlyList<int> Valores
        {
            get
            {
                List<int> valores = new List<int>();
                if (dados != null)
                {
                    foreach (DADO_BE d in dados)
                    {
                        valores.Add(d.Valor);
                    }
                }
                return valores;
            }
        }
    }
}
