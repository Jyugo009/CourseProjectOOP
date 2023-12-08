using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary.Interfaces;

namespace MyClassLibrary
{
    public class MyList<T> : Interfaces.IList<T>
    {
        private T?[] _items;

        private int _size;
        public int Count => _size;
        public int Capacity => _items.Length;

        public T? this[int index]
        {
            get
            {
                if (index < 0 || index >= _size)
                    throw new ArgumentOutOfRangeException();
                return _items[index];
            }

            set
            {
                if (index < 0 || index >= _size)
                    throw new ArgumentOutOfRangeException();
                _items[index] = value;
            }
        }

        public MyList()
        {
            _items = new T?[4];
            _size = 0;
        }

        public MyList(int capacity)
        {
            _items = new T?[capacity];
            _size = 0;
        }

        void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int newCap = Math.Max(_items.Length * 2, min);

                var newArr = new T?[newCap];

                Array.Copy(_items, newArr, _size);

                _items = newArr;
            }
        }

        public void Add(T? item)
        {
            EnsureCapacity(_size + 1);
            _items[_size++] = item;
        }

        public void Insert(int index, T? item)
        {
            if (index < 0 || index > _size)
                throw new ArgumentOutOfRangeException();

            EnsureCapacity(_size + 1);

            for (int i = _size; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }

            _items[index] = item;
            ++_size;
        }

        public void Remove(T? item)
        {
            int indexToRemove = IndexOf(item);

            for (int i = 0; i < _size; i++)
            {
                if (_items[i].Equals(item))
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove != -1)
                RemoveAt(indexToRemove);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _size)
                throw new ArgumentOutOfRangeException();

            for (int i = index; i < (_size - 1); ++i)
            {
                _items[i] = _items[i + 1];
            }

            --_size;
        }

        public bool Contains(T? item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(T? item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_items[i] == null && item == null)
                {
                    return i;
                }

                if (_items[i] == null || item == null)
                {
                    continue;
                }

                if (_items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Clear()
        {
            for (int i = 0; i < _size; i++)
            {
                _items[i] = default;
            }

            _size = 0;
        }

        public T?[] ToArray()
        {
            var array = new T?[_size];

            for (int i = 0; i < _size; i++)
            {
                array[i] = _items[i];
            }

            return array;
        }

        public void Reverse()
        {
            for (int i = 0, j = _size - 1; i < j; i++, j--)
            {
                T? temp = _items[i];

                _items[i] = _items[j];

                _items[j] = temp;
            }
        }


    }

}

