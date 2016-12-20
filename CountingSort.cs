using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANSortAlgorithms
{
    public static partial class SortAlgorithms
    {
        /// <summary>
        /// Имплементация алгоритма сортировки подсчетом. Сортировка по возрастанию.
        /// </summary>
        /// <returns>Отсортированный IList</returns>
        /// <param name="array">IList к сортировке</param>
        public static IList<int> CountingSort(IList<int> array)
        {
            //Отсортированный массив для заполнения
            int[] auxArray = new int[array.Count];
            //Вспомогательный массив
            int[] tempArray = new int[256];
            //считаем количество значений в arraySort и устанавливаем их число в соответствующую ячейку tempArray
            for (int j = 0; j < array.Count; j++)
            {
                tempArray[array[j]]++;
            }
            //на данный момент tempArray содержит количество элементов, равных i
            //суммируем все значения в tempArray и перезаписываем промежуточные суммы, для вычисления позиции в новом сортируемом массиве
            //проще нарисовать на бумаге массивы "в клеточку" все сразу станет понятно.
            for (int i = 1; i < tempArray.Length; i++)
            {
                tempArray[i] = tempArray[i] + tempArray[i - 1];
            }
            //на данный момент tempArray содержит количество элементов, не превышающих i
            //сортируем массив 
            //лучше нарисовать работу алгоритма на бумажке в клеточку: массив к сортировке, массив на выдачу и вспомогательный массив
            //и на рисунке разобрать все итерации это сэкономит кучу времени.
            for (var j = array.Count - 1; j >= 0; j--)
            {

                auxArray[tempArray[array[j]] - 1] = array[j];  //-1, т.к. нумерация начинается не с нуля
                tempArray[array[j]]--; //Для дубликатов
            }
            return auxArray;
        }
        /// <summary>
        /// Имплементация алгоритма сортировки подсчетом. Сортировка по убыванию.
        /// </summary>
        /// <returns>Отсортированный IList</returns>
        /// <param name="array">IList к сортировке</param>
        public static IList<int> CountingSortByDescending(IList<int> array)
        {
            int[] auxArray = new int[array.Count];
            int[] tempArray = new int[256];
            for (int j = 0; j < array.Count; j++)
            {
                tempArray[array[j]]++;
            }
            for (int i = 1; i < tempArray.Length; i++)
            {
                tempArray[i] = tempArray[i] + tempArray[i - 1];
            }
            for (var j = array.Count - 1; j >= 0; j--)
            {
                //Первый элемент ставим на последнее место: array.Count - tempArray[array[j]]
                auxArray[array.Count - tempArray[array[j]]] = array[j];
                tempArray[array[j]]--; 
            }
            return auxArray;
        }
    }
}
