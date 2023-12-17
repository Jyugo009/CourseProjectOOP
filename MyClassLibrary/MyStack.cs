using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary.Interfaces;

namespace MyClassLibrary
{
    public class MyStack<T> : IStack<T>
    {
        private readonly DoubleLinkedList<T>? _list = new DoubleLinkedList<T>();
        public int Count => _list.Count;

        public void Push(T? item)
        {
            _list.AddFirst(item);
        }

        public T? Pop()
        {
            if (Count == 0) throw new InvalidOperationException("Cannot pop from an empty stack.");

            var value = _list.First;

            _list.RemoveFirst();

            return value;
        }

        public T? Peek()
        {
            if (Count == 0) throw new InvalidOperationException("Cannot peek on an empty stack.");

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
    

