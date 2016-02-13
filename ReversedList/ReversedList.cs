namespace ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IReversedList<T>, IEnumerable<T>
    {
        private const string OutOfRangeMessage = "The provided currentIndex is outside of the ReversedList.";
        private const int DefaultCapacity = 16;

        private T[] storage;
        private int currentIndex;
        private int capacity;

        public ReversedList(int capacity = DefaultCapacity)
        {
            this.currentIndex = 0;
            this.Capacity = capacity;

            this.storage = new T[this.Capacity];
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Capacity should be positive number.");
                }

                this.capacity = value;
            }
        }

        public int Count
        {
            get
            {
                return this.currentIndex;
            }
        }

        public T this[int index]
        {
            get
            {
                return this.Get(index);
            }

            set
            {
                this.Insert(index, value);
            }
        }

        public void Add(T item)
        {
            if (this.Capacity <= this.currentIndex)
            {
                this.ExtendCapacity();   
            }

            this.storage[this.currentIndex] = item;
            this.currentIndex++;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= this.currentIndex)
            {
                throw new IndexOutOfRangeException(OutOfRangeMessage);
            }

            var reversedIndex = this.CalculateReversedIndex(index);

            for (int i = reversedIndex; i < this.currentIndex - 1; i++)
            {
                this.storage[i] = this.storage[i + 1];
            }

            this.currentIndex--;
            this.storage[this.currentIndex] = default(T);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.currentIndex - 1; i >= 0; i--)
            {
                yield return this.storage[i];
            }
        }

        public override string ToString()
        {
            var result = string.Join(", ", this);

            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private T Get(int index)
        {
            if (index < 0 || index >= this.currentIndex)
            {
                throw new IndexOutOfRangeException(OutOfRangeMessage);
            }

            var reversedIndex = this.CalculateReversedIndex(index);

            return this.storage[reversedIndex];
        }

        private T Insert(int index, T item)
        {
            if (index < 0 || index >= this.currentIndex)
            {
                throw new IndexOutOfRangeException(OutOfRangeMessage);
            }

            var reversedIndex = this.CalculateReversedIndex(index);

            return this.storage[reversedIndex] = item;
        }

        private void ExtendCapacity()
        {
            this.Capacity *= 2;
            var newStorage = new T[this.Capacity];

            for (int i = 0; i < this.currentIndex; i++)
            {
                newStorage[i] = this.storage[i];
            }

            this.storage = newStorage;
        }

        private int CalculateReversedIndex(int index)
        {
            var reversedIndex = this.currentIndex - index - 1;

            return reversedIndex;
        }
    }
}