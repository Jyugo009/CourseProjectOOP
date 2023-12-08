using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class StackNode<T>
    {
        public T? Value { get; set; }
        public StackNode<T>? Next { get; set; }

        public StackNode(T? value)
        {
            Value = value;

            Next = null;
        }
    }
}
