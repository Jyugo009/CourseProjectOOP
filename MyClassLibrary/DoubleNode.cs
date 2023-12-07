using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    #nullable enable
    public class DoubleNode<T>
    {
        public T? Value { get; }
        public DoubleNode<T>? Next { get; set; }
        public DoubleNode<T>? Previous { get; set; }

        public DoubleNode(T? value)
        {
            Value = value;

            Next = null;

            Previous = null;
        }
    }
}
