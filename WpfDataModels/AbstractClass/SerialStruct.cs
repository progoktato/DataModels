using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDataModels.Interface
{
    public abstract class SerialStruct<T>
    {
        protected T[] _array;
        protected int _index = 0;

        public SerialStruct() : this(50)
        {
        }

        public SerialStruct(int capacity)
        {
            _array = new T[capacity];
            _index = 0;
        }

        public void Clear()
        {
            _index = 0;
        }

        public int Count { get => _index; }

        public int Capacity => _array.Length;

        public String DevGetElements()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Capacity; i++)
            {
                sb.Append(i < Count ? _array[i] + ";" : ";");
            }
            return (sb.Length > 0 ? sb.Remove(sb.Length - 1, 1).ToString() : "");
        }

        public abstract void Push(T item);

        public abstract T Pop();

        public override string ToString()
        {
            return $"Count: {Count}, LastItem: {_array[Count - 1]}, Capacity: {Capacity}";
        }

    }
}
