using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace thomjade_Assignment1
{
    abstract class A1_matrices
    {
        public int[,] _matrix1 { get; set; }
        public int[,] _matrix2 { get; set; }
        public int _col1 { get; set; }
        public int _col2 { get; set; }
        public int _row1 { get; set; }
        public int _row2 { get; set; }
    }

    class MatrixManip : A1_matrices
    {
         double _stdDeviation { get; set; }
        int[,] _productMatrix { get; set; }
        int[,] _sumMatrix { get; set; }

        public MatrixManip() { }
        public MatrixManip(int col1, int col2, int row1, int row2)
        {
            this._col1 = col1;
            this._col2 = col2;
            this._row1 = row1;
            this._row2 = row2;
            this._matrix1 = new int[this._col1, this._row1];
            this._matrix2 = new int[this._col2, this._row2];
            _sumMatrix = new int[_col1, _row1];
            _productMatrix = new int[_col1, _row1];
        }

        public void generateRand()
        {
            Random random = new Random();
            for (int i = 0; i < this._col1; i++)
            {
                for (int j = 0; j < this._row1; j++)
                {
                    this._matrix1[i, j] = random.Next(0, 10);
                    this._matrix2[i, j] = random.Next(0, 10);
                }
            }
            using (StreamWriter wr = new StreamWriter(@"C:\JadeThomas_Matrices.txt"))
            {
                for (int k = 0; k < this._col1; k++)
                {
                    for (int l = 0; l < this._row1; l++)
                    {
                        wr.WriteLine(String.Format("matrix1[{0}][{1}] = {2}", k, l, _matrix1[k, l]));
                        wr.WriteLine(String.Format("matrix2[{0}][{1}] = {2}", k, l, _matrix2[k, l]));
                    }
                }

            }
        }

        public void calcStdDev()
        {
            //calculate mean of first array
            int sum = 0;
            for (int a = 0; a < _col1; a++)
            {
                for (int b = 0; b < _row1; b++)
                {
                    sum += _matrix1[a, b];
                }
            }
            double mean = sum / (_col1 * _row1);
            //calculate differences
            double diff = 0;
            for (int a = 0; a < _col1; a++)
            {
                for (int b = 0; b < _row1; b++)
                {
                    diff += Math.Pow((_matrix1[a, b] - mean),2);
                }
            }
            //calculate variance
            double var = diff / (_col1 * _row1);
            _stdDeviation = Math.Sqrt(var);

            //print to file C:\JadeThomas_product.txt
            using (StreamWriter wr = new StreamWriter(@"C:\JadeThomas_stddev.txt"))
            {
                wr.WriteLine(String.Format("standard deviation: {0}",_stdDeviation));

            }
        }

        //overloaded standard deviation function to demonstrate static function
        public static void calcStdDev(int[,] inputArray, int col, int row)
        {
            //calculate mean of first array
            int sum = 0;
            for (int a = 0; a < col; a++)
            {
                for (int b = 0; b < row; b++)
                {
                    sum += inputArray[a, b];
                }
            }
            double mean = sum / (col * row);
            //calculate differences and square
            double diff = 0;
            for (int a = 0; a < col; a++)
            {
                for (int b = 0; b < row; b++)
                {
                    diff += Math.Pow((inputArray[a, b] - mean), 2);
                }
            }
            //calculate variance
            double var = diff / (col * row);
            double stdDeviation = Math.Sqrt(var);

            //print to file C:\JadeThomas_product.txt
            using (StreamWriter wr = new StreamWriter(@"C:\JadeThomas_stddev.txt"))
            {
                wr.WriteLine(String.Format("standard deviation: {0}", stdDeviation));

            }
        }
        public bool calcSum()
        {
            if (this._col1 == this._col2 && this._row2 == this._row1)
            {
                //sum matrices
                for (int a = 0; a < this._col1; a++)
                {
                    for (int b = 0; b < this._col1; b++)
                    {
                        _sumMatrix[a, b] = this._matrix1[a, b] + this._matrix2[a, b];
                    }
                }

                //print to file C:\JadeThomas_product.txt
                using (StreamWriter wr = new StreamWriter(@"C:\JadeThomas_sum.txt"))
                {
                    for (int k = 0; k < this._col1; k++)
                    {
                        for (int l = 0; l < this._col1; l++)
                        {
                            wr.WriteLine(String.Format("productMatrix[{0}][{1}] = {2}", k, l, _sumMatrix[k, l]));
                        }
                    }
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        public bool calcProduct()
        {
            if (this._col1 == this._col2 && this._row2 == this._row1)
            {
                for (int a = 0; a < _col1; a++)
                {
                    for (int b = 0; b < _row1; b++)
                    {
                        _productMatrix[a, b] = _matrix1[a, b] * _matrix2[a, b];
                    }
                }

                //print to file C:\JadeThomas_product.txt
                using (StreamWriter wr = new StreamWriter(@"C:\JadeThomas_product.txt"))
                {
                    for (int k = 0; k < this._col1; k++)
                    {
                        for (int l = 0; l < this._row1; l++)
                        {
                            wr.WriteLine(String.Format("productMatrix[{0}][{1}] = {2}", k, l, _productMatrix[k, l]));
                        }
                    }

                }
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
