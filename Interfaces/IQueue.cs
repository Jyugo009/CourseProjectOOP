using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary.Interfaces
{
    public interface IQueue<T> : ICollection<T>
    {
        void Enqueue(T? item);

        T? Dequeue();
        
        T? Peek();


    }
}
