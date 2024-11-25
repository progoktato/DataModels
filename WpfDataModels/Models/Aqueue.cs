using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDataModels.Interface;

namespace WpfDataModels.Models
{
    public class Aqueue<T> : SerialStruct<T>
    {
        public override T Pop()
        {
            if (_index == 0)
            {
                throw new MissingMemberException("ERROR: Uqueue is empty!");
            }
            T? popResult = _array[0];
            for (int i = 1; i < Count; i++)
            {
                _array[i - 1] = _array[i];
            }
            _index--;
            return popResult;
        }

        public override void Push(T item)
        {
            if (_index == Capacity)
            {
                throw new OverflowException("ERROR: Uqueue overflow! ");
            }
            _array[_index++] = item;
        }
    }
}
