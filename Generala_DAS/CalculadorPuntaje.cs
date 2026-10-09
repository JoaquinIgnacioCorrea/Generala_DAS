using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Generala_DAS
{
    public static class CalculadorPuntaje
    {
        public static int CalcularPuntaje(Categoria categoria, IReadOnlyList<int> valoresDados, bool servida) 
        {
            switch (categoria)
            {
                case Categoria.unos:
                    return CalcularNumero(valoresDados, 1);
                case Categoria.doses:
                    return CalcularNumero(valoresDados, 2);
                case Categoria.treses:
                    return CalcularNumero(valoresDados, 3);
                case Categoria.cuatros:
                    return CalcularNumero(valoresDados, 4);
                case Categoria.cincos:
                    return CalcularNumero(valoresDados, 5);
                case Categoria.seises:
                    return CalcularNumero(valoresDados, 6);

                case Categoria.full:
                    return Full(valoresDados) ? (servida ? 25 : 20) : 0;
                case Categoria.poker:
                    return Poker(valoresDados) ? (servida ? 35 : 30) : 0;
                case Categoria.escalera:
                    return Generala(valoresDados) ? (servida ? 45 : 40) : 0;
                case Categoria.generala:
                    return Generala(valoresDados) ? (servida ? 60 : 55) : 0;
                
                case Categoria.generala_doble:
                    return Doble(valoresDados) ? 1 : 0;
                default: return 0;
            }
            
        }






        private static int CalcularNumero(IReadOnlyList<int> valoresDados, int ValorACalcular)
        {
            int puntos = 0;
            foreach (int i in valoresDados) 
            {
                if (i == ValorACalcular) { puntos += ValorACalcular;}
            }
            return puntos;
        }
        private static int[] ObtenerFrecuencias(IReadOnlyList<int> valoresDados)
        {
            int[] frecuencias = new int[7];
            foreach (int i in valoresDados)
            {
                frecuencias[i]++;
            }
            return frecuencias;
        }
        private static bool Generala(IReadOnlyList<int> valoresDados)
        {
            int[] frecuencias= ObtenerFrecuencias(valoresDados);
            bool generala = false;
            foreach(int i in frecuencias)
            {
                if (frecuencias[i] == 5) 
                {
                    generala = true;
                    break;
                }
            }

            return generala;
        }
        private static bool Poker(IReadOnlyList<int> valoresDados)
        {
            int[] frecuencias= ObtenerFrecuencias(valoresDados);
            bool poker = false;
            foreach (int i in frecuencias)
            {
                if (frecuencias[i] > 4)
                {
                    poker = true;
                    break;
                }
            }
            return poker;
        }
        private static bool Full(IReadOnlyList<int> valoresDados)
        {
            int[] frecuencias= ObtenerFrecuencias(valoresDados);
            bool full = false;
            foreach (int i in frecuencias)
            {
                if (frecuencias[i] == 3)
                {
                    foreach (int j in frecuencias)
                    {
                        if (frecuencias[j] == 2)
                        {
                            full = true;
                            break;
                        }
                    }
                }
            }
            return full;
        }
        private static bool Escalera(IReadOnlyList<int> valoresDados)
        {
            int[] ordenados = new int[5];
            ordenados = valoresDados.OrderBy(x => x).ToArray();
            bool caso1 = ordenados.SequenceEqual(new[] { 1, 2, 3, 4, 5});
            bool caso2 = ordenados.SequenceEqual(new[] { 2, 3, 4, 5, 6 });
            return caso1 || caso2;
        }
        private static bool Doble(IReadOnlyList<int> valoresDados)
        {
            //Ver como lo arreglo cuando tenga la clase jugador
            return true;
        }

    }
}