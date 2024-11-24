using System;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfDataModels.Models
{

    //
    // Az Ustack<T> esetén a T helyére bármilyen konkrét típus behelyettesíthető az osztály példányosítása során.
    //
    public class Ustack<ItemType> //Konvencionálisan inkább nagy T-t írunk. 
    {
        private ItemType[] _array;
        private int _index = 0;

        public Ustack() : this(50)
        {
        }

        public Ustack(int capacity)
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
                throw new OverflowException("ERROR: Ustack overflow! ");
            }
            _array[_index++] = item;
        }

        public ItemType Pop()
        {
            if (_index == 0)
            {
                throw new MissingMemberException("ERROR: Ustack is empty!");
            }
            _index--;
            return _array[_index];
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
