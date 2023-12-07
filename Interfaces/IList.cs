using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary.Interfaces
{
    public interface IList<T> : ICollection<T>
    {
        T? this[int index] { get; }

        int Capacity { get; }

        void Add(T? item);

        void Insert(int index, T? item);

        void Remove(T? item);

        void RemoveAt(int index);   
        
        int IndexOf(T? item);  
        
        void Reverse();
           
    }
}
