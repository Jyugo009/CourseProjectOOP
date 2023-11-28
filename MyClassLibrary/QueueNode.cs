using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class QueueNode
    {
        public object Value { get; set; }
        public QueueNode Next { get; set; }

        public QueueNode(object value)
        {
            Value = value;

            Next = null;
        }
    }
}
