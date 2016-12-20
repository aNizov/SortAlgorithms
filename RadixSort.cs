using System.Collections.Generic;


namespace ANSortAlgorithms
{
    public static partial class SortAlgorithms
    {
        /// <summary>
        /// Имплементация алгоритма поразрадной сортировки. Сортировка по возрастанию.
        /// </summary>
        /// <returns>Отсортированный IList</returns>
        /// <param name="array">IList к сортировке</param>
        public static IList<int> RadixSort(IList<int> array)
        {
            //Смещение
            byte shift = sizeof(int);
            while (shift > 0)
            {
                for (int index = 0; index < array.Count; index++)
                {
                    array = InternalCountingSort(array, shift);
                }
                shift--;
            }
            return array;
        }
        /// <summary>
        /// Имплементация алгоритма поразрадной сортировки. Сортировка по убыванию.
        /// </summary>
        /// <returns>Отсортированный IList</returns>
        /// <param name="array">IList к сортировке</param>
        public static IList<int> RadixSortByDescending(IList<int> array)
        {
            //Смещение
            byte shift = sizeof(int);
            while (shift > 0)
            {

                for (int index = 0; index < array.Count; index++)
                {
                    array = InternalCountingSortByDescending(array as int[], shift);
                }
                shift--;
            }
            return array;
        }
        //Вспомогательный алгоритм сортировки подсчетом, 
        //Т.к. при поразрадной сортировке в качестве одного разряда принимается 1 байт,
        //а дипазон возможных значений в одном байте составляет от 0 до 255 - всего 256,
        //то наиболее оптимальным алгоритмом для применения в промежуточной сортировке в рамках одного разряда
        //при ограниченном наборе возможных значений [0..255] являетсфя алгоритм сортировки подсчетом.
        private static int[] InternalCountingSort(IList<int> arrayToSort, byte shift)
        {
            //Отсортированный массив для заполнения
            int[] auxArray = new int[arrayToSort.Count];
            //Вспомогательный массив
            int[] tempArray = new int[256];
            //считаем количество значений в arraySort и устанавливаем их число в соответствующую ячейку tempArray
            for (int j = 0; j < arrayToSort.Count; j++)
            {
                tempArray[arrayToSort[j].GetDigit(shift)]++;
            }
            //на данный момент tempArray содержит количество элементов, равных i
            //суммируем все значения в tempArray и перезаписываем прмежуточные суммы, для вычисления позиции в промежуточном массиве
            //проще нарисовать на бумаге массивы "в клеточку" все сразу станет понятно.
            for (int i = 1; i < tempArray.Length; i++)
            {
                tempArray[i] = tempArray[i] + tempArray[i - 1];
            }
            //на данный момент tempArray содержит количество элементов, не превышающих i
            //сортируем массив 
            //лучше нарисовать работу алгоритма на бумажке в клеточку: массив к сортировке, массив на выдачу и вспомогательный массив
            //и на рисунке разобрать все итерации это сэкономит кучу времени.
            for (var j = arrayToSort.Count - 1; j >= 0; j--)
            {

                auxArray[tempArray[arrayToSort[j].GetDigit(shift)] - 1] = arrayToSort[j];  //-1, т.к. нумерация начинается не с нуля
                tempArray[arrayToSort[j].GetDigit(shift)]--; //Для дубликатов
            }
            return auxArray;
        }
        //Вспомогательный алгоритм сортировки подсчетом, сортировка по убыванию
        private static int[] InternalCountingSortByDescending(IList<int> arrayToSort, byte shift)
        {
            int[] auxArray = new int[arrayToSort.Count];
            int[] tempArray = new int[256];
            for (int j = 0; j < arrayToSort.Count; j++)
            {
                tempArray[arrayToSort[j].GetDigit(shift)]++;
            }
            for (int i = 1; i < tempArray.Length; i++)
            {
                tempArray[i] = tempArray[i] + tempArray[i - 1];
            }
            for (var j = arrayToSort.Count - 1; j >= 0; j--)
            {
                //Первый элемент ставим на последнее место: arrayToSort.Count - tempArray[arrayToSort[j].GetDigit(shift)
                auxArray[arrayToSort.Count - tempArray[arrayToSort[j].GetDigit(shift)]] = arrayToSort[j];
                tempArray[arrayToSort[j].GetDigit(shift)]--;
            }
            return auxArray;
        }
        //Метод расширения. Получает значение i-ого байта, нумерация от нуля
        private static int GetDigit(this int n, int shift)
        {
            int result = (n >> (8 * shift) & 255);
            //Сдвигаем число влево на 8 бит и накладываем маску 255, т.е. ....00011111111, тем самым обнуляя все остальные байты
            return result;
        }

    }
}
