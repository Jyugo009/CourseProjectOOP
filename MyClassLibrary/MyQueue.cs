using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary.Interfaces;

namespace MyClassLibrary
{
    public class MyQueue<T> : IQueue<T>
    {
        private DoubleLinkedList<T>? _list = new DoubleLinkedList<T>();

        public int Count => _list.Count;

        public void Enqueue(T? item)
        {
            _list.Add(item);
        }

        public T? Dequeue()
        {
            if (Count == 0) throw new InvalidOperationException("Cannot dequeue from an empty queue.");

            var value = _list.First;
            _list.RemoveFirst();
            return value;
        }

        public T? Peek()
        {
            if (Count == 0) throw new InvalidOperationException("Cannot peek from an empty queue.");

            return _list.First;
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T? item)
        {
            return _list.Contains(item);
        }

        public T?[] ToArray()
        {
            return _list.ToArray();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _list)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
