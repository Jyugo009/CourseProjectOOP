using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IStack : ICollections
    {
        public void Push(object? item);

        public object? Pop();

        public object? Peek();
    }
}
