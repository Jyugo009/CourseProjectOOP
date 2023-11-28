﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class BinarySearchTree
    {
        private TreeNode _root;
        public TreeNode Root => _root;

        public int Count { get; private set; }

        public void Add(int value)
        {
            _root = Insert(_root, value);

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

        public bool Contains(int value)
        {
            return Find(_root, value) != null;

            TreeNode Find(TreeNode node, int targetValue)
            {
                if (node == null || node.Value == targetValue)
                {
                    return node;
                }

                if (targetValue < node.Value)
                {
                    return Find(node.Left, targetValue);
                }

                else
                {
                    return Find(node.Right, targetValue);
                }
            }
        }

        public void Clear()
        {
            _root = null;

            Count = 0;
        }

        public int[] ToArray()
        {
            if (_root == null)
                return new int[0]; // or throw exception if tree must not be empty

            int[] resultArray = new int[Count];
            int index = 0;

            InOrderTraverseAndFillArray(_root, ref index, resultArray);

            return resultArray;
        }

        private void InOrderTraverseAndFillArray(TreeNode node, ref int currentIndex, int[] arr)
        {
            if (node == null)
                return;

            InOrderTraverseAndFillArray(node.Left, ref currentIndex, arr);

            arr[currentIndex++] = node.Value;

            InOrderTraverseAndFillArray(node.Right, ref currentIndex, arr);
        }

    }
}
