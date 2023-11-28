using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ISingleLinkedList : ICollections
    {
        public object? First { get; }

        public object? Last { get; }

        void AddFirst(object? item);

        void Insert(int index, object? item);
    }
}
