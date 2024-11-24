using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDataModels.AbstractClass;
using WpfDataModels.Interface;

namespace WpfDataModels.Models
{
    public class Umatrix : AbsMatrix, IMatrixOperations
    {
        public Umatrix(int row, int column) : base(row, column)
        {
        }

        public Umatrix() : base()
        {
        }

        public String ToString(String message)
        {
            return message+"\n"+ToString();
        }

        public override String ToString()
        {
            int maxLength = 3;
            for (int rowIndex = 0; rowIndex < RowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < ColumnCount; columnIndex++)
                {
                    int actLength = this[rowIndex, columnIndex].ToString().Length;
                    if (actLength > maxLength)
                        maxLength = actLength;
                }
            }


            StringBuilder sb = new StringBuilder();
            for (int rowIndex = 0; rowIndex < RowCount; rowIndex++)
            {
                sb.Append("│");
                for (int columnIndex = 0; columnIndex < ColumnCount; columnIndex++)
                {
                    sb.Append(this[rowIndex, columnIndex].ToString().PadLeft(maxLength));
                    sb.Append(";");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("│\n");
            }
            return sb.ToString();
        }
        public void Add(AbsMatrix addMatrix)
        {
            for (int rowIndex = 0; rowIndex < RowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < ColumnCount; columnIndex++)
                {
                    this[rowIndex, columnIndex] += addMatrix[rowIndex, columnIndex];
                }
            }
        }

        public bool Equals(AbsMatrix other)
        {
            bool isEqual = true; //assumption
            for (int rowIndex = 0; rowIndex < RowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < ColumnCount; columnIndex++)
                {
                    if (this[rowIndex, columnIndex] != other[rowIndex, columnIndex])
                        return false;
                }
            }
            return isEqual;
        }

        public void Fill(double value)
        {
            for (int rowIndex = 0; rowIndex < RowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < ColumnCount; columnIndex++)
                {
                    this[rowIndex, columnIndex] = value;
                }
            }

        }

        public void RotateToLeft()
        {
            for (int rowIndex = 0; rowIndex < RowCount; rowIndex++)
            {
                double temp = this[rowIndex, 0];
                for (int columnIndex = 1; columnIndex < ColumnCount; columnIndex++)
                {
                    this[rowIndex, columnIndex - 1] = this[rowIndex, columnIndex];
                }
                this[rowIndex, ColumnCount - 1] = temp;
            }
        }

        public void RotatetToDown()
        {
            throw new NotImplementedException();
        }

        public void RotatetToRight()
        {
            throw new NotImplementedException();
        }

        public void RotatetToTop()
        {
            throw new NotImplementedException();
        }

        public void Sub(AbsMatrix subMatrix)
        {
            throw new NotImplementedException();
        }

        public void FillRandomFloat(double start, double end)
        {
            throw new NotImplementedException();
        }

        public void FillRandomInt(int start, int end)
        {
            Random rnd = new Random();
            for (int rowIndex = 0; rowIndex < RowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < ColumnCount; columnIndex++)
                {
                    this[rowIndex, columnIndex] = rnd.Next(start, end);
                }
            }

        }
    }
}
