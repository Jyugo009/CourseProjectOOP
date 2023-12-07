using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary.Interfaces
{
    public interface ISingleLinkedList : ICollection
    {
        public object? First { get; }

        public object? Last { get; }

        void Add(object? item);

        void AddFirst(object? item);

        void Insert(int index, object? item);
    }
}
