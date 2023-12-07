using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary.Interfaces
{
    public interface IDoubleLinkedList : ICollection
    {
        public object? First { get; }

        public object? Last { get; }

        void Add(object? item);

        void RemoveLast();

        void RemoveFirst();

        void AddFirst(object? item);

        void Remove(object? item);


    }
}
