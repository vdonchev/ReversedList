namespace ReversedList
{
    using System.Collections.Generic;

    public interface IReversedList<T>
    {
        int Count { get; }

        int Capacity { get; }

        T this[int index] { get; set; }

        IEnumerator<T> GetEnumerator();

        void Add(T item);

        void Remove(int index);
    }
}