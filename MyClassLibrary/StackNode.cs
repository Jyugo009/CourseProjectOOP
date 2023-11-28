using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class StackNode
    {
        public object Value { get; set; }
        public StackNode Next { get; set; }

        public StackNode(object value)
        {
            Value = value;

            Next = null;
        }
    }
}
