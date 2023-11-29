using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary.Interfaces
{
    public interface IStack : ICollection
    {
        public void Push(object? item);

        public object? Pop();

        public object? Peek();
    }
}
