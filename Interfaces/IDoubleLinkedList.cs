using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary.Interfaces
{
    public interface IDoubleLinkedList<T> : ICollection<T>
    {
        T? First { get; }

        T? Last { get; }

        void Add(T? item);

        void RemoveLast();

        void RemoveFirst();

        void AddFirst(T? item);

        void Remove(T? item);


    }
}
