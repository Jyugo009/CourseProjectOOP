using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary.Interfaces;

namespace MyClassLibrary
{
    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        private TreeNode<T>? _root;
        public TreeNode<T>? Root => _root;

        public int Count { get; private set; }

        public void Add(T? value)
        {
            if (value is T intValue)
            {
                _root = Insert(_root, intValue);
            }

            TreeNode<T> Insert(TreeNode<T>? node, T? newValue)
            {
                if (node == null)
                {
                    return new TreeNode<T>(newValue);
                }

                int compareResult = node.Value.CompareTo(newValue);

                if (compareResult > 0)
                {
                    node.Left = Insert(node.Left, newValue);
                }

                else if (compareResult < 0)
                {
                    node.Right = Insert(node.Right, newValue);
                }

                return node;
            }

            Count++;
        }

        public bool Contains(T? value)
        {
            if (value is T intValue)
            {
                return Find(_root, intValue) != null;
            }

            return false;

            TreeNode<T> Find(TreeNode<T>? node, T? targetValue)
            {
                if (node == null)
                {
                    return null;
                }

                int compareResult = node.Value.CompareTo(targetValue);

                if (compareResult == 0)
                {
                    return node;
                }

                if (compareResult > 0)
                {
                    return Find(node.Left, targetValue);
                }

                return Find(node.Right, targetValue);
            }
        }

        public void Clear()
        {
            _root = null;

            Count = 0;
        }

        public T?[] ToArray()
        {
            if (_root == null)
                return Array.Empty<T>();

            T?[] resultArray = new T?[Count];

            int index = 0;

            InOrderTraverseAndFillArray(_root, ref index, resultArray);

            return resultArray;
        }

        private void InOrderTraverseAndFillArray(TreeNode<T>? node, ref int currentIndex, T?[] arr)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraverseAndFillArray(node.Left, ref currentIndex, arr);

            arr[currentIndex++] = node.Value;

            InOrderTraverseAndFillArray(node.Right, ref currentIndex, arr);
        }

    }
}
