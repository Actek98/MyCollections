using System;
using System.Collections.Generic;
using System.Text;

namespace MyCollections.Lib
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyListArray<T> : IList<T>, IEnumerator<T>
    {
        #region private fields
        T[] _arr;
        int _count = 0;
        #endregion

        #region .ctor
        public MyListArray(int startCapacity = 10)
        {
            _arr = new T[startCapacity];
            _count = 0;
        }
        #endregion

        #region indexer
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException();
                return _arr[index];
            }

            set
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException();
                _arr[index] = value;
            }
        }
        #endregion

        public int Count => _count;

        public bool IsReadOnly => false;

        #region Enumerable

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Enumerator

        int _currentIndex = -1;

        public T Current => _arr[_currentIndex];
        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            return ++_currentIndex < _count;
        }
        public void Reset()
        {
            _currentIndex = -1;
        }
        public void Dispose()
        {
            Reset();
        }

        #endregion

        #region ChangeList
        public void Clear()
        {
            _count = 0;
        }

        public void Add(T item)
        {
            if (_count == _arr.Length)
            {
                Array.Resize(ref _arr, _count + 10);
            }
            _arr[_count++] = item;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException();
            if (_count == _arr.Length)
            {
                Array.Resize(ref _arr, _count + 10);
            }
            _count++;
            for (int i = _count - 1; i > index; i--)
            {
                _arr[i] = _arr[i - 1];
            }
            _arr[index] = item;
        }

        public bool Remove(T item)
        {
            int number = IndexOf(item);
            if (number == -1) return false;
            RemoveAt(number);
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException();
            _count--;
            for (int i = index; i < _count; i++)
            {
                _arr[i] = _arr[i + 1];
            }
        }
        #endregion

        #region SearchInList
        public bool Contains(T item)
        {
            foreach (T val in _arr)
                if (val.Equals(item))
                    return true;
            return false;
        }

        public int IndexOf(T item)
        {
            using (IEnumerator<T> e = GetEnumerator())
            {
                while (e.MoveNext())
                {
                    if (e.Current.Equals(item)) return _currentIndex;
                }
            }
            return -1;
        }
        #endregion

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException();
            if ((arrayIndex + _count) > array.Length)
                throw new ArgumentException();
            foreach (T val in _arr)
            {
                array[arrayIndex++] = val;
            }
        }
    }
}

