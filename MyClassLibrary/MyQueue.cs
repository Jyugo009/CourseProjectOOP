using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class MyQueue
    {
        private DoubleLinkedList _list = new DoubleLinkedList();

        public int Count => _list.Count;

        public void Enqueue(object item)
        {
            _list.Add(item);
        }

        public object Dequeue()
        {
            if (Count == 0) throw new InvalidOperationException("Cannot dequeue from an empty queue.");

            var value = _list.First;
            _list.RemoveFirst();
            return value;
        }

        public object Peek()
        {
            if (Count == 0) throw new InvalidOperationException("Cannot peek from an empty queue.");

            return _list.First;
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(object item)
        {
            return _list.Contains(item);
        }

        public object[] ToArray()
        {
            return _list.ToArray();
        }

    }
}
