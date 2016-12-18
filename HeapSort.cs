using System;
using System.Collections.Generic;

namespace ANSortAlgorithms
{
	public static partial class SortAlgorithms
    {
		/// <summary>
		/// Имплементация алгоритма пирамидальной сортировки. Сортировка по возрастанию.
		/// </summary>
		/// <returns>Отсортированный IList</returns>
		/// <param name="array">IList к сортировке</param>
		public static IList<T> HeapSort<T>(IList<T> array) where T : IComparable
		{
			Build_Max_Heap(array);
			int heapSize = array.Count - 1;
			for (int i = array.Count - 1; i >= 1; i--)
			{

				array.SwapElements(0, i);
				heapSize = heapSize - 1;
				Max_Heapify(array, heapSize, 0);

			}
			return array;
		}
		/// <summary>
		/// Имплементация алгоритма пирамидальной сортировки. Сортировка по убыванию
		/// </summary>
		/// <returns>Отсортированный IList</returns>
		/// <param name="array">IList к сортировке</param>
		public static IList<T> HeapSortByDescending<T>(IList<T> array) where T : IComparable
		{
			Build_Min_Heap(array);
			int heapSize = array.Count - 1;
			for (int i = array.Count - 1; i >= 1; i--)
			{
				array.SwapElements(0, i);
				heapSize = heapSize - 1;
				Min_Heapify(array, heapSize, 0);

			}
			return array;
		}
		static void Build_Max_Heap<T>(IList<T> array) where T : IComparable
		{
			for (int a = array.Count / 2 + 1; a >= 0; a--)
			{
				Max_Heapify(array, array.Count - 1, a);
			}
		}
		static void Build_Min_Heap<T>(IList<T> array) where T : IComparable
		{
			for (int a = array.Count / 2 + 1; a >= 0; a--)
			{
				Min_Heapify(array, array.Count - 1, a);
			}
		}
		/// <summary>
		/// Puts the item array[index] down the pyramid as long as 
		/// the subtree with index root not be non-increasing pyramid
		/// </summary>
		/// <param name="array">Array</param>
		/// <param name="index">Index</param>
		/// <returns>Modified Array</returns>
		static void Max_Heapify<T>(IList<T> array, int heapSize, int index) where T : IComparable
		{
			int l = Left(index);
			int r = Right(index);

			int largest;
			if (l <= heapSize && array[l].CompareTo(array[index]) > 0)
			{
				largest = l;
			}
			else
			{
				largest = index;
			}
			if (r <= heapSize && array[r].CompareTo(array[largest]) > 0)
			{
				largest = r;
			}
			if (largest != index)
			{
				array.SwapElements(index, largest);
				Max_Heapify(array, heapSize, largest);
			}
		}
		static void Min_Heapify<T>(IList<T> array, int heapSize, int index) where T : IComparable
		{
			int l = Left(index);
			int r = Right(index);

			int largest;
			if (l <= heapSize && array[l].CompareTo(array[index]) < 0)
			{
				largest = l;
			}
			else
			{
				largest = index;
			}
			if (r <= heapSize && array[r].CompareTo(array[largest]) < 0)
			{
				largest = r;
			}
			if (largest != index)
			{
				array.SwapElements(index, largest);
				Min_Heapify(array, heapSize, largest);
			}
		}
		/// <summary>
		/// Returns left child node index of current parent node
		/// </summary>
		/// <param name="index">Node index</param>
		/// <returns>Left child node</returns>
		static int Left(int index)
		{
			return index * 2;
		}

		/// <summary>
		/// Returns right child node index of current parent node
		/// </summary>
		/// <param name="index">Node index</param>
		/// <returns>Left child node</returns>
		static int Right(int index)
		{
			return index * 2 + 1;
		}
	}
}
