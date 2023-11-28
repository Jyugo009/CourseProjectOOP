using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class MyList
    {
        private object[] _items;

        private int _size;
        public int Count => _size;
        public int Capacity => _items.Length;

        public MyList()
        {
            _items = new object[4];
            _size = 0;
        }

        public MyList(int capacity)
        {
            _items = new object[capacity];
            _size = 0;
        }

        void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int newCap = Math.Max(_items.Length * 2, min);

                var newArr = new object[newCap];

                Array.Copy(_items, newArr, _size);

                _items = newArr;
            }
        }

        public void Add(object item)
        {
            EnsureCapacity(_size + 1);
            _items[_size++] = item;
        }

        public void Insert(int index, object item)
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

        public void Remove(object item)
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

        public bool Contains(object item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(object item)
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
                _items[i] = null;
            }

            _size = 0;
        }

        public object[] ToArray()
        {
            var array = new object[_size];

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
                object temp = _items[i];

                _items[i] = _items[j];

                _items[j] = temp;
            }
        }


    }

}

