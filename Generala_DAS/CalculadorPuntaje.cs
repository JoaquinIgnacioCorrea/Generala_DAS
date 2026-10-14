using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Generala_DAS
{
    public static class CalculadorPuntaje
    {
        public static int CalcularPuntaje(CATEGORIAS categoria, IReadOnlyList<int> valoresDados, bool servida, TABLERO Tablero) 
        {
            switch (categoria)
            {
                case CATEGORIAS.unos:
                    return CalcularNumero(valoresDados, 1);
                case CATEGORIAS.doses:
                    return CalcularNumero(valoresDados, 2);
                case CATEGORIAS.treses:
                    return CalcularNumero(valoresDados, 3);
                case CATEGORIAS.cuatros:
                    return CalcularNumero(valoresDados, 4);
                case CATEGORIAS.cincos:
                    return CalcularNumero(valoresDados, 5);
                case CATEGORIAS.seises:
                    return CalcularNumero(valoresDados, 6);

                case CATEGORIAS.escalera:
                    return Escalera(valoresDados) ? (servida ? 25 : 20) : 0;
                case CATEGORIAS.full:
                    return Full(valoresDados) ? (servida ? 35 : 30) : 0;
                case CATEGORIAS.poker:
                    return Poker(valoresDados) ? (servida ? 45 : 40) : 0;
                case CATEGORIAS.generala:
                    return Generala(valoresDados) ? (servida ? 60 : 50) : 0;
                
                case CATEGORIAS.generala_doble:
                    return Doble(valoresDados, Tablero) ? (servida ? 120 : 100) : 0;
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
                if (i >= 1 && i <= 6)
                {
                    frecuencias[i]++;
                }
            }
            return frecuencias;
        }
        private static bool Generala(IReadOnlyList<int> valoresDados)
        {
            int[] frecuencias = ObtenerFrecuencias(valoresDados);
            return frecuencias.Any(f => f == 5);
        }
        private static bool Poker(IReadOnlyList<int> valoresDados)
        {
            int[] frecuencias = ObtenerFrecuencias(valoresDados);
            return frecuencias.Any(f => f >= 4);
        }
        private static bool Full(IReadOnlyList<int> valoresDados)
        {
            int[] frecuencias = ObtenerFrecuencias(valoresDados);
            return frecuencias.Any(f => f == 3) && frecuencias.Any(f => f == 2);
        }
        private static bool Escalera(IReadOnlyList<int> valoresDados)
        {
            int[] ordenados = valoresDados.OrderBy(x => x).ToArray();
            bool caso1 = ordenados.SequenceEqual(new[] { 1, 2, 3, 4, 5 });
            bool caso2 = ordenados.SequenceEqual(new[] { 2, 3, 4, 5, 6 });
            bool caso3 = ordenados.SequenceEqual(new[] { 1, 3, 4, 5, 6 }); // común en generala con el 1 como comodín
            return caso1 || caso2 || caso3;
        }
        private static bool Doble(IReadOnlyList<int> valoresDados, TABLERO Tablero)
        {
            return (Tablero.DobleHabilitada) && Generala(valoresDados);
            
        }

    }
}