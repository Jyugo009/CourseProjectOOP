using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class QueueNode<T>
    {
        public T? Value { get; set; }
        public QueueNode<T>? Next { get; set; }

        public QueueNode(T? value)
        {
            Value = value;

            Next = null;
        }
    }
}
