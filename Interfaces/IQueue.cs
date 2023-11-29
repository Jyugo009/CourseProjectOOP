using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary.Interfaces
{
    public interface IQueue : ICollection
    {
        public void Enqueue(object? item);

        public object? Dequeue();
        
        public object? Peek();


    }
}
