using System;
using System.Collections;
using System.Collections.Generic;

namespace MyCollections.Lib
{
    public class MyDLList<T> : IList<T>, IEnumerator<T> //Double Linked List
    {
        #region Fields
        int _count;
        ListItem _head = null;
        ListItem _tail = null;
        #endregion

        #region InnerClass
        class ListItem
        {
            public T _value;
            public ListItem _next;
            public ListItem _prev;

            public ListItem(T value, ListItem next, ListItem prev)
            {
                _next = next;
                _prev = prev;
                _value = value;
            }
        }
        #endregion

        #region ctors
        public MyDLList()
        {

        }

        public MyDLList(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Add(item);
            }
        }
        #endregion

        #region Indexer

        private ListItem GetItem(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }
            ListItem tmp = _head;
            while (index-- > 0)
            {
                tmp = tmp._next;
            }
            return tmp;
        }

        public T this[int index]
        {
            get => GetItem(index)._value;
            set => GetItem(index)._value = value; }
        #endregion

        #region properties
        public int Count => _count;

        public bool IsReadOnly => false;
        #endregion

        /// <summary>
        /// Add to Tail
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            if (_head == null && _tail == null)
            {
                _head = _tail = new ListItem(value, null, null);
            }
            else
            {
                _tail = _tail._next = new ListItem(value, null, _tail); // 3 = 2 = 1
            }
            _count++;
        }

        /// <summary>
        /// Add to Head
        /// </summary>
        /// <param name="value"></param>
        public void AddHead(T value)
        {
            if (_head == null && _tail == null)
            {
                _head = _tail = new ListItem(value, null, null);
            }
            else
            {
                _head = _head._prev = new ListItem(value, _head, null);
            }
            _count++;
        }

        public void Clear()
        {
            _head = _tail = null;
            _count = 0;
        }

        public bool Contains(T value)
        {
            using (IEnumerator<T> en = GetEnumerator())
            {
                while (MoveNext())
                {
                    if (value.Equals(en.Current))
                        return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            using (IEnumerator<T> en = GetEnumerator())
            {
                while (MoveNext())
                {
                    array[arrayIndex++] = en.Current;
                }
            }
        }

        public int IndexOf(T value)
        {
            int index = 0;
            using (IEnumerator<T> en = GetEnumerator())
            {
                while (MoveNext())
                {
                    if (en.Current.Equals(value))
                    {
                        return index;
                    }
                    index++;
                }
            }
            return -1;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index >= _count) throw new ArgumentOutOfRangeException();

            if (index == 0)
            {
                AddHead(value);
                return;
            }

            ListItem item = GetItem(index);
            item._prev = item._prev._next = new ListItem(value, item, item._prev);
            ++_count;
        }

        private ListItem GetElement(T value)
        {
            ListItem tmp = _head;
            while (tmp != null)
            {
                if (tmp._value.Equals(value))
                    return tmp;
                tmp = tmp._next;
            }
            return null;
        }

        private void CutElement(ListItem item)
        {
            if (item == _head)
                _head = item._next;
            else
                item._prev._next = item._next;

            if (item == _tail)
                _tail = item._prev;
            else
                item._next._prev = item;

            --_count;
        }

        public bool Remove(T value)
        {
            ListItem item = GetElement(value);
            if (item == null) return false;
            CutElement(item);
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count) throw new ArgumentOutOfRangeException();
            ListItem item = GetItem(index);
            CutElement(item);
        }

        #region IEnumerable
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
        private ListItem _currentItem = null;

        public T Current { get => _currentItem._value; }
        object IEnumerator.Current { get =>Current; } 

        public bool MoveNext()
        {
            if (_currentItem == null)
            {
                _currentItem = _head;
            }
            else
            {
                _currentItem = _currentItem._next;
            }
            return _currentItem != null;
        }

        public void Reset()
        {
            _currentItem = null;
        }

        public void Dispose()
        {
            Reset();
        }
        #endregion
    }
}
