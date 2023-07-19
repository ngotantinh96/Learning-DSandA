using System.Collections;

namespace TinhNgo.DynamicArray
{
    public class DynamicArray<T> : IEnumerable<T>
    {
        private T[] arr;
        private int capacity;
        private int size = 0;

        public DynamicArray()
        {
            this.capacity = 10;
            arr = new T[capacity];
        }

        public DynamicArray(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentException("Capacity cannot be negative: " + capacity);
            
            this.capacity = capacity;
            arr = new T[capacity];
        }

        public int Size
        {
            get { return this.size; }
        }

        public bool IsEmpty
        {
            get { return Size == 0; }
        }

        public T Get(int index)
        {
            return arr[index];
        }

        public void Set(int index, T element)
        {
            arr[index] = element;
        }

        public void Clear()
        {
            for (int i = 0; i < size; i++)
            {
                arr[i] = default(T);
            }
            size = 0;
        }

        public void Add(T element)
        {
            if (size >= capacity - 1)
            {
                if (capacity == 0)
                    capacity = 1;
                else
                    capacity *= 2;
                
                T[] newArr = new T[capacity];
                Array.Copy(arr, newArr, arr.Length);
                arr = newArr;
            }
            arr[size++] = element;
        }

        public void RemoveAt(int removeIndex)
        {
            if (removeIndex >= size || removeIndex < 0)
                throw new IndexOutOfRangeException();
            
            T[] newArr = new T[size - 1];

            for (int oldArrIndex = 0, newArrIndex = 0; oldArrIndex < size; oldArrIndex++, newArrIndex++)
            {
                if (oldArrIndex == removeIndex)
                    newArrIndex--;
                else
                    newArr[newArrIndex] = arr[oldArrIndex];
            }
            arr = newArr;
            capacity = --size;
        }

        public T RemoveAtWithoutMoving(int removeIndex)
        {
            if (removeIndex >= size || removeIndex < 0)
                throw new IndexOutOfRangeException();
            
            T item = arr[removeIndex];
            arr[removeIndex] = default(T);
            capacity = --size;
            return item;
        }

        public void Remove(object obj)
        {
            int removeIndex = IndexOf(obj);
            RemoveAt(removeIndex);
        }

        public int IndexOf(object obj)
        {
            for (int i = 0; i < size; i++)
            {
                if (obj == null)
                {
                    if (arr[i] == null)
                        return i;
                }
                else
                {
                    if (obj.Equals(arr[i]))
                        return i;
                }
            }
            return -1;
        }

        public bool Contains(object obj)
        {
            return IndexOf(obj) != -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DynamicArrayEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            if (IsEmpty)
                return "[]";
            else
            {
                var sb = new System.Text.StringBuilder(size);
                sb.Append("[");
                for (int i = 0; i < size - 1; i++)
                {
                    sb.Append(arr[i]).Append(",");
                }
                sb.Append(arr[size - 1]).Append("]");
                return sb.ToString();
            }
        }

        private class DynamicArrayEnumerator : IEnumerator<T>
        {
            private DynamicArray<T> dynamicArray;
            private int index = -1;

            public DynamicArrayEnumerator(DynamicArray<T> dynamicArray)
            {
                this.dynamicArray = dynamicArray;
            }

            public bool MoveNext()
            {
                index++;
                return index < dynamicArray.Size;
            }

            public void Reset()
            {
                index = -1;
            }

            public T Current
            {
                get { return dynamicArray.Get(index); }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
            }
        }
    }
}
