using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IQueue : ICollections
    {
        public void Dequeue(object? item)
        {
            Add(item);
        }

        public object? Peek();


    }
}
