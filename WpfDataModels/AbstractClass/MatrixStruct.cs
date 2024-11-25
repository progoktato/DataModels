using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfDataModels.AbstractClass
{
    public abstract class MatrixStruct
    {
        private double[,] matrix;

        public MatrixStruct(int row, int column)
        {
            if (row <= 0 || column <= 0)
                throw new ArgumentException("Bad argument!");
            matrix = new double[row, column];
        }
        public MatrixStruct() : this(3, 3) { }


        public MatrixStruct(int n) : this(n, n) { }

        public int RowCount
        {
            get
            {
                if (matrix != null)
                    return matrix.GetLength(0);
                else
                    return -1;
            }
        }

        public int ColumnCount
        {
            get
            {
                if (matrix != null)
                    return matrix.GetLength(1);
                else
                    return -1;
            }
        }

        public double this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= RowCount || column < 0 || column >= ColumnCount)
                    throw new IndexOutOfRangeException("Index out of bounds!");
                return matrix[row, column];
            }
            set
            {
                if (row < 0 || row >= RowCount || column < 0 || column >= ColumnCount)
                    throw new IndexOutOfRangeException("Index out of bounds!");
                matrix[row, column] = value;
            }
        }
    }
}
