using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary.Interfaces
{
    public interface IList : ICollection
    {
        object? this[int index] { get; }

        public int Capacity { get; }

        void Add(object? item);

        void Insert(int index, object? item);

        void Remove(object? item);

        void RemoveAt(int index);   
        
        int IndexOf(object? item);  
        
        void Reverse();
           
        }
}
