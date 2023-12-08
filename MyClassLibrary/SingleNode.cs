using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class SingleNode<T>
    {
        public T? Value { get; set; }
        public SingleNode<T>? Next { get; set; }

        public SingleNode(T? value)
        {
            Value = value;

            Next = null;
        }
    }
}
