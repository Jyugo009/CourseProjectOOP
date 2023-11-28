using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class SingleNode
    {
        public object Value { get; set; }
        public SingleNode Next { get; set; }

        public SingleNode(object value)
        {
            Value = value;

            Next = null;
        }
    }
}
