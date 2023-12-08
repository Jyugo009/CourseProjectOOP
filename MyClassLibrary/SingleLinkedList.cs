using MyClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class SingleLinkedList<T> : ISingleLinkedList<T>
    {
        private SingleNode<T>? _head;

        private SingleNode<T>? _tail;

        public int Count { get; private set; }

        public T? First => _head.Value;

        public T? Last => _tail.Value;

        public void Add(T? item)
        {
            var newNode = new SingleNode<T>(item);

            if (_head == null)
            {
                _head = newNode;
            }

            else
            {
                _tail.Next = newNode;
            }

            _tail = newNode;

            Count++;
        }

        public void AddFirst(T? item)
        {
            var newNode = new SingleNode<T>(item)
            {
                Next = _head
            };

            _head = newNode;

            if (Count == 0)
            {
                _tail = newNode;
            }

            Count++;
        }

        public void Insert(int index, T? item)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException();

            var newNode = new SingleNode<T>(item);

            if (index == 0)
            {
                AddFirst(item);
            }

            else
            {
                var current = _head;
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }

                newNode.Next = current.Next;

                current.Next = newNode;

                if (newNode.Next == null)
                {
                    _tail = newNode;
                }

                Count++;
            }
        }

        public void Clear()
        {
            _head = null;

            _tail = null;

            Count = 0;
        }

        public bool Contains(T? item)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T?[] ToArray()
        {
            var resultArray = new T?[Count];

            int index = 0;

            var currentNode = _head;

            while (currentNode != null)
            {
                resultArray[index++] = (T?)currentNode.Value;

                currentNode = currentNode.Next;

            }

            return resultArray;

        }

    }
}
