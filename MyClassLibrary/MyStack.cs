using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace MyClassLibrary
{
    public class MyStack : IStack
    {
        private DoubleLinkedList _list = new DoubleLinkedList();
        public int Count => _list.Count;

        public void Push(object item)
        {
            _list.AddFirst(item);
        }

        public object? Pop()
        {
            if (Count == 0) throw new InvalidOperationException("Cannot pop from an empty stack.");

            var value = _list.First;

            _list.RemoveFirst();

            return value;
        }

        public object? Peek()
        {
            if (Count == 0) throw new InvalidOperationException("Cannot peek on an empty stack.");

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

        public void Add(object item)
        {
            Push(item);
        }
    }

}
    

