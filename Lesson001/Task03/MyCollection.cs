using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Task03
{
    public class MyCollection : IEnumerable, IEnumerator
    {
        Citizen[] elements;
        public int Count { get; private set; }
        public MyCollection()
        {
            elements = new Citizen[4];
            Count = 0;
        }
        public Citizen this[int index]
        {
            get
            {
                return elements[index];
            }
        }
        public int Add(Citizen newElement)
        {
            if (Contains(newElement, out int elementIndex))
            {
                return -1;
            }
            else
            {
                int index;

                if (Count == elements.Length)
                {
                    GrowArray();
                }

                if (newElement is Pensioner)
                {
                    index = AddToBegining(newElement);
                }
                else
                {
                    index = AddToEnd(newElement);
                }
                Count++;
                return index;
            }


        }
        public bool Contains(Citizen newElement, out int index)
        {
            for (int i = 0; i < Count; i++)
            {
                if (elements[i].PassportID == newElement.PassportID)
                {
                    index = i;
                    return true;
                }   
            }
            index = -1;
            return false;
        }
        public bool Remove(Citizen element)
        {
            if (Contains(element, out int index))
            {
                RemoveElement(index);
                return true;
            }
            return false;
        }
        public void RemoveFirst()
        {
            RemoveElement(0);
        }
        public Citizen ReturnLast(out int index)
        {
            index = Count - 1;
            return elements[Count - 1];
        }

        public void Clear()
        {
            elements = new Citizen[0];
            Count = 0;
        }

        #region Private methods
        void RemoveElement(int index)
        {
            Array.ConstrainedCopy(elements, index + 1, elements, index, Count - index - 1);
            Count--;
        }
        int AddToEnd(Citizen newElement)
        {
            int insertIndex = Count;
            elements[insertIndex] = newElement;
            return insertIndex;
        }
        int AddToBegining(Citizen newElement)
        {
            int insertIndex = GetInsertIndex();
            Array.ConstrainedCopy(elements, insertIndex, elements, insertIndex + 1, Count - insertIndex);
            elements[insertIndex] = newElement;
            return insertIndex;
        }
        /// <summary>
        /// Returns the index to insert a new element if it's type is Pensioner
        /// </summary>
        /// <returns>The index to insert a new element</returns>
        private int GetInsertIndex()
        {
            int insertIndex = 0;
            for (int i = 0; i < Count; i++)
            {
                if (elements[i] is Pensioner)
                {
                    insertIndex = i + 1;
                }
            }
            return insertIndex;
        }

        /// <summary>
        /// Increases the size of the internal array
        /// </summary>
        private void GrowArray()
        {
            int newLength = elements.Length == 0 ? 4 : elements.Length * 2;
            Citizen[] newArray = new Citizen[newLength];
            elements.CopyTo(newArray, 0);
            elements = newArray;
        }
        #endregion

        #region  Implementation of IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
        #endregion

        #region  Implementation of IEnumerator
        int position = -1;
        bool IEnumerator.MoveNext()
        {
            if (position < Count - 1)
            {
                position++;
                return true;
            }
            ((IEnumerator)this).Reset();
            return false;
        }

        void IEnumerator.Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return elements[position];
            }
        }
        #endregion




    }
}
