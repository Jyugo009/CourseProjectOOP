using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class MyStack
    {
        private StackNode _top;

        public int Count { get; private set; }

        public void Push(object item)
        {
            var newNode = new StackNode(item);

            newNode.Next = _top;

            _top = newNode;

            Count++;
        }

        public object Pop()
        {
            if (_top == null) throw new InvalidOperationException("Cannot pop from an empty stack.");

            object value = _top.Value;

            _top = _top.Next;

            Count--;

            return value;
        }

        public object Peek()
        {
            if (_top == null) throw new InvalidOperationException("Cannot peek on an empty stack.");

            return _top.Value;
        }

        public void Clear()
        {
            _top = null;

            Count = 0;
        }
        public bool Contains(object item)
        {
            StackNode current = _top;

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

            StackNode currentNode = _top;

            while (currentNode != null)
            {
                resultArray[index++] = currentNode.Value;
                currentNode = currentNode.Next;
            }

            return resultArray;
        }
    }
}
