using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SnowdramaUtils
{       
    //behaves like a List, but uses an _values
    public class ArrayList<T> : IEnumerable<T>
    {
        public int Length { get { return _values.Length; } }
        T[] _values = new T[0];
        int[] freeIndexes = new int[0];

        public T this[int id]
        {
            get => _values[id];
            set => _values[id] = value;
        }

        public int Add(T item)
        {
            int index = GetFreeOrNewSpriteIndex();
            _values[index] = item;
            return index;
        }

        public T Get(int index)
        {
            if (HasIndex(index))
            {
                return _values[index];
            }
            return default;
        }

        public void Remove(int index)
        {
            if (index >= 0 && index < _values.Length)
            {
                AddIndexToFreeIndexes(index);
                _values[index] = default;
            }
        }

        public int Remove(T item)
        {
            for(var i = 0; i < _values.Length; ++i)
            {
                if(_values[i].Equals(item))
                {
                    AddIndexToFreeIndexes(i);
                    _values[i] = default;

                    return i;
                }
            }

            return -1;
        }

        public bool HasIndex(int index)
        {
            if (index >= 0 && index < _values.Length && _values[index] != null)
            {
                return true;
            }
            return false;
        }

        public int GetFreeOrNewSpriteIndex()
        {
            if (freeIndexes.Length > 0)
            {
                int index = GetFreeSpriteIndex();
                return index;
            }
            else
            {
                //make a new list with an additional value
                T[] newList = new T[_values.Length + 1];
                //Copy the old list into the new list
                Array.Copy(_values, newList, _values.Length);
                //the set the new list to the list
                _values = newList;
                //return the last index
                return _values.Length - 1;
            }
        }
        public int GetFreeSpriteIndex()
        {
            //get the last one
            int[] newList = new int[freeIndexes.Length - 1];
            int indexToReturn = freeIndexes[0];
            //decrease the size of the _values
            Array.Copy(freeIndexes, 1, newList, 0, freeIndexes.Length - 1);
            freeIndexes = newList;
            return indexToReturn;
        }
        private void AddIndexToFreeIndexes(int index)
        {
            //we only remove something that's not already in free so if it's already a freed index we don't add it twice.
            bool alreadyInFree = false;
            for (int i = 0; i < freeIndexes.Length; i++)
            {
                if (freeIndexes[i] == index)
                {
                    alreadyInFree = true;
                }
            }
            if (!alreadyInFree)
            {
                int[] newList = new int[freeIndexes.Length + 1];
                //no extras so lets expand the _values and make a new one
                Array.Copy(freeIndexes, newList, freeIndexes.Length);
                freeIndexes = newList;
                freeIndexes[freeIndexes.Length - 1] = index;
            }
        }

        public bool Contains(T val)
        {
            for(int i = 0; i < _values.Length; i++)
            {
                if(_values[i] != null && _values[i].Equals(val))
                {
                    return true;
                }
            }
            return false;
        }

        public int GetIndex(T val)
        {
            for (int i = 0; i < _values.Length; i++)
            {
                if (_values[i].Equals(val))
                {
                    return i;
                }
            }
            return -1;
        }

        public T[] GetArray()
        {
            return _values;
        }
        public int[] GetFreeIndexArray()
        {
            return freeIndexes;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_values).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_values).GetEnumerator();
        }
    }
}