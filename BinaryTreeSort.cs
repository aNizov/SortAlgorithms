using System;
using System.Collections.Generic;

namespace ANSortAlgorithms
{
	public static partial class SortAlgorithms
    {
        /// <summary>
        /// Имплементация алгоритма сортировки с помощью бинарного дерева. Сортировка по возрастанию.
        /// </summary>
        /// <returns>Отсортированный IEnumerable</returns>
        /// <param name="array">IEnumerable к сортировке</param>
        public static IList<T> BinaryTreeSort<T>(IList<T> array) where T : IComparable
        {
            BinaryTree tree = new BinaryTree();
            foreach (var elem in array)
            {
                tree.TreeInsert(new Node() { Key = elem });
            }
            return tree.InorderTreeRootWalk(array);
        }
        /// <summary>
        /// Имплементация алгоритма сортировки с помощью бинарного дерева. Сортировка по убыванию.
        /// </summary>
        /// <returns>Отсортированный IEnumerable</returns>
        /// <param name="array">IEnumerable к сортировке</param>
        public static IList<T> BinaryTreeSortByDescending<T>(IList<T> array) where T : IComparable
        {
            BinaryTree tree = new BinaryTree();
            foreach (var elem in array)
            {
                tree.TreeInsert(new Node() { Key = elem });
            }
            return tree.ReverseTreeRootWalk(array);
        }
    }

    internal class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Parent { get; set; }
        public IComparable Key { get; set; }
    }
    internal class BinaryTree
    {
        internal Node TreeRoot { get; set; }

        internal IList<T> InorderTreeRootWalk<T>(IList<T> array) where T : IComparable
        {
            int index = 0;
            Node node = TreeRoot;
            Node lastNode = null;
            //Нерекурсивный обход дерева
            while (node != null)
            {
                if (lastNode == node.Parent)
                {
                    if (node.Left != null)
                    {
                        lastNode = node;
                        node = node.Left;
                        continue;
                    }
                    else
                        lastNode = null;
                }
                if (lastNode == node.Left)
                {
                    array[index] = (T)node.Key;
                    index++;
                    //this.Array.Add(node.Key);

                    if (node.Right != null)
                    {
                        lastNode = node;
                        node = node.Right;
                        continue;
                    }
                    else
                        lastNode = null;
                }
                if (lastNode == node.Right)
                {
                    lastNode = node;
                    node = node.Parent;
                }
            }
            //Рекурсивный обход дерева
            //if (node != null)
            //{
            //    InorderTreeWalk(node.Left);
            //    this.Array.Add(node.Key);
            //    InorderTreeWalk(node.Right);
            //}
            return array;
        }
        internal IList<T> ReverseTreeRootWalk<T>(IList<T> array) where T : IComparable
        {
            int index = 0;
            Node node = TreeRoot;
            Node lastNode = null;
            //Нерекурсивный обход дерева
            while (node != null)
            {
                if (lastNode == node.Parent)
                {
                    if (node.Right != null)
                    {
                        lastNode = node;
                        node = node.Right;
                        continue;
                    }
                    else
                        lastNode = null;
                }
                if (lastNode == node.Right)
                {
                    array[index] = (T)node.Key;
                    index++;
                    //this.Array.Add(node.Key);

                    if (node.Left != null)
                    {
                        lastNode = node;
                        node = node.Left;
                        continue;
                    }
                    else
                        lastNode = null;
                }
                if (lastNode == node.Left)
                {
                    lastNode = node;
                    node = node.Parent;
                }
            }
            //Рекурсивный обход дерева
            //if (node != null)
            //{
            //    ReverseTreeWalk(node.Right);
            //    this.Array.Add(node.Key);
            //    ReverseTreeWalk(node.Left);
            //}
            return array;
        }
        internal void TreeInsert(Node node)
        {
            Node y = null;
            Node x = TreeRoot;
            //Спускаемся по дереву до тех пор, пока не найдем свободное место для дочернего узла "x"(x==null) родителя "y"
            while (x != null)
            {
                y = x;
                x = (node.Key.CompareTo(x.Key) < 0) ? x.Left : x.Right;
            }
            node.Parent = y;
            //Если дерево было пустым, то node -> корень
            if (y == null)
            {
                this.TreeRoot = node;
            }
            //А если нет, то в зависимости от значения ключа, вставляем элемент, в качестве левого или правого потомка 
            else
            {
                if (node.Key.CompareTo(y.Key) < 0)
                    y.Left = node;
                else
                    y.Right = node;
            }
        }
    }
}
