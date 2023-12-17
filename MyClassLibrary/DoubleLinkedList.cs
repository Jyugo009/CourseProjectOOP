using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MyClassLibrary.Interfaces;

namespace MyClassLibrary
{
    public class DoubleLinkedList<T> : IDoubleLinkedList<T>
    {
        private DoubleNode<T>? _head;
        private DoubleNode<T>? _tail;

        public int Count { get; private set; }

        public T? First => _head.Value;

        public T? Last => _tail.Value;

        public void Add(T? item)
        {
            var newNode = new DoubleNode<T>(item);

            if (_head == null)
            {
                _head = newNode;
            }

            else
            {
                newNode.Previous = _tail;

                _tail.Next = newNode;
            }

            _tail = newNode;

            Count++;
        }

        public void AddFirst(T? item)
        {
            var newNode = new DoubleNode<T>(item);

            if (_head == null)
            {
                _tail = newNode;
            }

            else
            {
                newNode.Next = _head;

                _head.Previous = newNode;
            }

            _head = newNode;

            Count++;
        }

        public void Remove(T? item)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }

                    else
                    {
                        _head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }

                    else
                    {
                        _tail = current.Previous;
                    }

                    Count--;
                    return;
                }

                current = current.Next;
            }
        }

        public void RemoveFirst()
        {
            if (_head != null)
            {
                _head = _head.Next;

                if (_head == null)
                {
                    _tail = null;
                }

                else
                {
                    _head.Previous = null;
                }

                Count--;
            }
        }

        public void RemoveLast()
        {
            if (_tail != null)
            {
                _tail = _tail.Previous;

                if (_tail == null)
                {
                    _head = null;
                }

                else
                {
                    _tail.Next = null;
                }

                Count--;
            }
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
                resultArray[index++] = currentNode.Value;

                currentNode = currentNode.Next;
            }

            return resultArray;

        }

        public void Clear()
        {
            while (_head != null)
            {
                var temp = _head;

                _head = _head.Next;

                temp.Previous = null;

                temp.Next = null;

            }

            _tail = null;

            Count = 0;

        }

        public IEnumerator<T> GetEnumerator()
        {
            DoubleNode<T>? current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
