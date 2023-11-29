using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary.Interfaces;

namespace MyClassLibrary
{
    public class BinarySearchTree : IBinarySearchTree
    {
        private TreeNode _root;
        public TreeNode Root => _root;

        public int Count { get; private set; }

        public void Add(object? value)
        {
            if (value is int intValue)
            {
                _root = Insert(_root, intValue);
            }

            TreeNode Insert(TreeNode node, int newValue)
            {
                if (node == null)
                {
                    return new TreeNode(newValue);
                }

                if (newValue < node.Value)
                {
                    node.Left = Insert(node.Left, newValue);
                }

                else if (newValue > node.Value)
                {
                    node.Right = Insert(node.Right, newValue);
                }

                return node;
            }

            Count++;
        }

        public bool Contains(object? value)
        {
            if (value is int intValue)
            {
                return Find(_root, intValue) != null;
            }

            return false;

            TreeNode Find(TreeNode? node, int targetValue)
            {
                if (node == null)
                {
                    return null;
                }

                if (node.Value == targetValue)
                {
                    return node;
                }

                if (targetValue < node.Value)
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

        public object[] ToArray()
        {
            if (_root == null)
                return Array.Empty<object>();

            object[] resultArray = new object[Count];

            int index = 0;

            InOrderTraverseAndFillArray(_root, ref index, resultArray);

            return resultArray;
        }

        private void InOrderTraverseAndFillArray(TreeNode node, ref int currentIndex, object[] arr)
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
