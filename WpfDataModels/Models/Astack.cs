using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WpfDataModels.Interface;

namespace WpfDataModels.Models
{
    internal class Astack<T> : SerialStruct<T>
    {
        public override T Pop()
        {
            if (_index == 0)
            {
                throw new MissingMemberException("ERROR: Ustack is empty!");
            }
            _index--;
            return _array[_index];
        }

        public override void Push(T item)
        {
            if (_index == Capacity)
            {
                throw new OverflowException("ERROR: Ustack overflow! ");
            }
            _array[_index++] = item;
        }
    }
}
