using System;
using System.Collections.Generic;
using System.Linq;

namespace MeuApp
{
    /// <summary>
    /// Classe auxiliar com funções que efetuam cálculos matemáticos, tais como Mediana, Média aritimética, entre outros.
    /// </summary>
    public class FuncoesEstatisticas
    {
        /// <summary>
        /// Efetua o cálculo do quartil com base na lista informada
        /// </summary>
        /// <param name="values">Lista de valores</param>
        /// <returns>Array de valores com os elementos do quartil: [0] => 1° Quartil; [1] = 2° Quartil (mediana); [2] => 3° Quartil; [3]=> 4° Quartil</returns>
        public decimal[] CalcularQuartil(IList<decimal> values)
        {
            IList<decimal> sortedList = values.OrderBy(c => c).ToList();

            decimal[] quartil = new decimal[4];

            decimal mediana = CalcularMediana(sortedList);

            quartil[0] = CalcularMediana(sortedList.Where(v => v < mediana).ToList());
            // O quartil 2 sempre será o valor da mediana dos elementos
            quartil[1] = mediana;
            quartil[2] = CalcularMediana(sortedList.Where(v => v > mediana).ToList());
            quartil[3] = sortedList.Max();

            return quartil;
        }

        /// <summary>
        /// Efetua o cálculo do quartil com base na lista informada
        /// </summary>
        /// <param name="values">Lista de valores</param>
        /// <returns>Array de valores com os elementos do quartil: [0] => 1° Quartil; [1] = 2° Quartil (mediana); [2] => 3° Quartil; [3]=> 4° Quartil
        public int[] CalcularQuartil(IList<int> values)
        {
            IList<int> sortedList = values.OrderBy(c => c).ToList();

            int[] quartil = new int[4];

            int mediana = CalcularMediana(sortedList);

            quartil[0] = CalcularMediana(sortedList.Where(v => v < mediana).ToList());
            // O quartil 2 sempre será o valor da mediana dos elementos
            quartil[1] = mediana;
            quartil[2] = CalcularMediana(sortedList.Where(v => v > mediana).ToList());
            quartil[3] = sortedList.Max();

            return quartil;
        }

        /// <summary>
        /// Calcula a mediana de uma lista de valores
        /// <seealso cref="CalcularMediana(IList<int>)"/>
        /// </summary>
        /// <param name="values">Lista de valores</param>
        /// <returns>Valor da mediana</returns>
        public decimal CalcularMediana(IList<decimal> values)
        {
            IList<decimal> sortedList = values.OrderBy(c => c).ToList();

            int elements = sortedList.Count;
            if (elements % 2 != 0)
            {
                int position = (elements + 1) / 2;

                return sortedList.ElementAt(position - 1);
            }
            else
            {
                // Mediana para números pares
                int position1 = elements / 2;
                int position2 = elements / 2 + 1;

                if (position1 > 0 && position2 > 0)
                {
                    return (values.ElementAt(position1 - 1) + values.ElementAt(position2 - 1)) / 2;
                }

                return 0;
            }
        }

        /// <summary>
        /// Calcula a mediana de uma lista de valores
        /// <seealso cref="CalcularMediana(IList<decimal>)"/>
        /// </summary>
        /// <param name="values">Lista de valores</param>
        /// <returns>Valor da mediana</returns>
        public int CalcularMediana(IList<int> values)
        {
            IList<int> sortedList = values.OrderBy(c => c).ToList();

            int elements = sortedList.Count;
            if (elements % 2 != 0)
            {
                int position = (elements + 1) / 2;

                return sortedList.ElementAt(position - 1);
            }
            else
            {
                // Mediana para números pares
                int position1 = elements / 2;
                int position2 = elements / 2 + 1;

                if (position1 > 0 && position2 > 0)
                {
                    return (values.ElementAt(position1 - 1) + values.ElementAt(position2 - 1)) / 2;
                }

                return 0;
            }
        }

        /// <summary>
        /// Calcula o número de classes (k) de uma distribuição de frequências utilizando a regra da Raiz Quadrada:
        /// </summary>
        /// <param name="values">Valores da classe ou frequência</param>
        /// <returns>Número de classes (k) que podem ser geradas</returns>
        public decimal CalcularNumeroClasseFrequenciaEstatistica(IList<decimal> values)
        {
            IList<decimal> sortedList = values.OrderBy(v => v).ToList();

            decimal limiteInferiorClasse = sortedList.Min();
            decimal limiteSuperiorClasse = sortedList.Max();

            decimal amplitudeClasse = limiteSuperiorClasse - limiteInferiorClasse;
            decimal raiz = (decimal)Math.Sqrt((double)sortedList.Count);

            return amplitudeClasse / raiz;
        }

        /// <summary>
        /// Calcula o número de classes (k) de uma distribuição de frequências utilizando a regra da Raiz Quadrada:
        /// </summary>
        /// <param name="values">Valores da classe ou frequência</param>
        /// <returns>Número de classes (k) que podem ser geradas</returns>
        public int CalcularNumeroClasseFrequenciaEstatistica(IList<int> values)
        {
            IList<int> sortedList = values.OrderBy(v => v).ToList();

            int limiteSuperiorClasse = sortedList.Max();
            int limiteInferiorClasse = sortedList.Min();

            int amplitudeClasse = limiteSuperiorClasse - limiteInferiorClasse;
            decimal raiz = (decimal)Math.Sqrt((double)values.Count);

            return (int)Math.Ceiling(amplitudeClasse / raiz);
        }
    }
}
