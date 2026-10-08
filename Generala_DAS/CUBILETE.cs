using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Generala_DAS
{
    public class CUBILETE
    {
        public List<DADO> dados = new List<DADO>();

        public void AgregarDados(List<DADO> _dados)
        {
            dados.Clear();
            foreach (DADO dado in _dados) { dados.Add(dado); }
        }
        public void Lanzar()
        {
            foreach (DADO dado in dados) { dado.Lanzar(); }
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