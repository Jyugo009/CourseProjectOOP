using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary.Interfaces
{
    public interface ISingleLinkedList<T> : ICollection<T>
    {
        T? First { get; }

        T? Last { get; }

        void Add(T? item);

        void AddFirst(T? item);

        void Insert(int index, T? item);
    }
}
