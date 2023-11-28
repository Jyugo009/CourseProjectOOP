using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IList : ICollections
    {
        object? this[int index] { get; }

        public int Capacity { get; }

        void Insert(int index, object? item);

        void Remove(object? item);

        void RemoveAt(int index);   
        
        int IndexOf(object? item);  
        
        void Reverse();
           
        }
}
