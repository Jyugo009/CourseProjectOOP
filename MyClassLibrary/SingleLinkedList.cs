using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class SingleLinkedList : ISingleLinkedList
    {
        private SingleNode _head;

        private SingleNode _tail;

        public int Count { get; private set; }

        public object First => _head?.Value;

        public object Last => _tail?.Value;

        public void Add(object item)
        {
            var newNode = new SingleNode(item);

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

        public void AddFirst(object item)
        {
            var newNode = new SingleNode(item)
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

        public void Insert(int index, object item)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException();

            var newNode = new SingleNode(item);

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

        public bool Contains(object item)
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

        public object[] ToArray()
        {
            var resultArray = new object[Count];

            int index = 0;

            var currentNode = _head;

            while (currentNode != null)
            {
                resultArray[index++] = (int)currentNode.Value;

                currentNode = currentNode.Next;

            }

            return resultArray;

        }

    }
}
