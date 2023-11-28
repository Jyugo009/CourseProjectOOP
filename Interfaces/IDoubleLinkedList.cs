using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDoubleLinkedList : ICollections
    {
        public object? First { get; }

        public object? Last { get; }

        void RemoveLast();

        void RemoveFirst();

        void AddFirst(object? item);

        void Remove(object? item);


    }
}
