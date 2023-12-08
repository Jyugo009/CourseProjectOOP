using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public T Value { get; }
        public TreeNode<T>? Left { get; set;}
        public TreeNode<T>? Right { get; set; }

        public TreeNode(T value)
        {
            Value = value;

            Left = null;

            Right = null;
        }
    }
}
