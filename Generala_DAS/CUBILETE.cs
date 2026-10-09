using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Generala_DAS
{
    public class CUBILETE

    {
        CUBILETE() 
        {
            for (int i = 0; i <5; i++) { DADO dado = new DADO(); dados.Add(dado);  }
        }

        private List<DADO> dados = new List<DADO>();

        public IReadOnlyList<DADO> Dados => dados;

        public IReadOnlyList<int> Valores
        {
            get
            {
                List<int> valores = new List<int>();
                foreach (DADO d in dados)
                {
                    valores.Add(d.Valor);
                }
                return valores;
            }
        }

        public void Lanzar()
        {
            foreach (DADO dado in dados) 
            {
                dado.Lanzar();
                
            }
        }
        public void AlternarBloqueo(DADO dado) 
        {
            if (dado.Bloqueado) 
            {
                dado.Desbloquear();
            } 
            else dado.Bloquear(); 
        }
        public void Reiniciar()
        {
            foreach(DADO dado in dados) { dado.Desbloquear();}
        }

    }
}