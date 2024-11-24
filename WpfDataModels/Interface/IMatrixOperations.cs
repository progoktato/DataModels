using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfDataModels.AbstractClass;

namespace WpfDataModels.Interface
{
    internal interface IMatrixOperations
    {
        public void Fill(double value);
        public void FillRandomFloat(double start, double end);
        public void FillRandomInt(int start, int end);
        public void Add(AbsMatrix addMatrix);
        public void Sub(AbsMatrix subMatrix);
        public bool Equals(AbsMatrix other);

        public void RotateToLeft();
        public void RotatetToRight();
        public void RotatetToTop();
        public void RotatetToDown();

    }
}
