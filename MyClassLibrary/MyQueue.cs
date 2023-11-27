using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class MyQueue
    {
        private QueueNode _head;

        private QueueNode _tail;

        public int Count { get; private set; }

        public void Enqueue(object item)
        {
            var newNode = new QueueNode(item);

            if (_tail != null)
            {
                _tail.Next = newNode;
            }

            _tail = newNode;

            if (_head == null)
            {
                _head = newNode;
            }

            Count++;
        }

        public object Dequeue()
        {
            if (_head == null) throw new InvalidOperationException("Cannot dequeue from an empty queue.");

            object value = _head.Value;

            _head = _head.Next;

            if (_head == null)
            {
                _tail = null;
            }

            Count--;

            return value;
        }

        public object Peek()
        {
            if (_head == null) throw new InvalidOperationException("Cannot peek from an empty queue.");

            return _head.Value;
        }

        public void Clear()
        {
            _head = null;

            _tail = null;

            Count = 0;
        }

        public bool Contains(object item)
        {
            QueueNode current = _head;

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
            object[] resultArray = new object[Count];

            int index = 0;

            QueueNode currentNode = _head;

            while (currentNode != null)
            {
                resultArray[index++] = currentNode.Value;

                currentNode = currentNode.Next;
            }

            return resultArray;
        }

    }
}
