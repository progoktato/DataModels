﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDataModels.AbstractClass;
using WpfDataModels.Interface;

namespace WpfDataModels.Models
{
    public class AImatrix : MatrixStruct, IMatrixOperations
    {
        public AImatrix(int row, int column) : base(row, column)
        {
        }

        public AImatrix(int n) : base(n, n)
        {
        }

        public AImatrix() : base()
        {
        }

        public String ToString(String caption)
        {
            return $"\n{caption}\n{ToString()}";
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
        public void Add(MatrixStruct addMatrix)
        {
            for (int rowIndex = 0; rowIndex < RowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < ColumnCount; columnIndex++)
                {
                    this[rowIndex, columnIndex] += addMatrix[rowIndex, columnIndex];
                }
            }
        }

        public bool Equals(MatrixStruct other)
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


        public void RotateToRight()
        {
            for (int rowIndex = 0; rowIndex < RowCount; rowIndex++)
            {
                double temp = this[rowIndex, ColumnCount - 1];
                for (int columnIndex = ColumnCount - 1; columnIndex > 0; columnIndex--)
                {
                    this[rowIndex, columnIndex] = this[rowIndex, columnIndex - 1];
                }
                this[rowIndex, 0] = temp;
            }
        }

        public void RotateToUp()
        {
            for (int columnIndex = 0; columnIndex < ColumnCount; columnIndex++)
            {
                double temp = this[0, columnIndex];
                for (int rowIndex = 1; rowIndex < RowCount; rowIndex++)
                {
                    this[rowIndex - 1, columnIndex] = this[rowIndex, columnIndex];
                }
                this[RowCount - 1, columnIndex] = temp;
            }
        }

        public void RotateToDown()
        {
            for (int columnIndex = 0; columnIndex < ColumnCount; columnIndex++)
            {
                double temp = this[RowCount - 1, columnIndex];
                for (int rowIndex = RowCount - 1; rowIndex > 0; rowIndex--)
                {
                    this[rowIndex, columnIndex] = this[rowIndex - 1, columnIndex];
                }
                this[0, columnIndex] = temp;
            }
        }

        public void Sub(MatrixStruct subMatrix)
        {
            for (int rowIndex = 0; rowIndex < RowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < ColumnCount; columnIndex++)
                {
                    this[rowIndex, columnIndex] -= subMatrix[rowIndex, columnIndex];
                }
            }
        }

        public void FillRandomFloat(double start, double end)
        {
            Random rnd = new Random();
            for (int rowIndex = 0; rowIndex < RowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < ColumnCount; columnIndex++)
                {
                    this[rowIndex, columnIndex] = (float)(rnd.NextDouble() * (end - start) + start);
                }
            }

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
