using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WpfDataModels.Models
{
    public class Uqueue<ItemType>
    {
        private ItemType[] _array;
        private int _index = 0;

        public Uqueue() : this(50)
        {
        }

        public Uqueue(int capacity)
        {
            _array = new ItemType[capacity];
            _index = 0;
        }


        public void Clear()
        {
            _index = 0;
        }

        public int Count { get => _index; }

        public int Capacity => _array.Length;

        public void Push(ItemType item)
        {
            if (_index == Capacity)
            {
                throw new OverflowException("ERROR: Uqueue overflow! ");
            }
            _array[_index++] = item;
        }

        public ItemType Pop()
        {
            if (_index == 0)
            {
                throw new MissingMemberException("ERROR: Uqueue is empty!");
            }
            ItemType? popResult = _array[0];
            for (int i = 1; i < Count; i++)
            {
                _array[i - 1] = _array[i];
            }
            _index--;
            return popResult;
        }

        public override string ToString()
        {
            return $"Count: {Count}, LastItem: {_array[Count - 1]}, Capacity: {Capacity}";
        }

        public String DevGetElements()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Capacity; i++)
            {
                sb.Append(i < Count ? _array[i] + ";" : ";");
            }
            return (sb.Length > 0 ? sb.Remove(sb.Length - 1, 1).ToString() : "");
        }
    }
}
