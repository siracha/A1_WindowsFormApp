using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace thomjade_Assignment1
{
    public partial class Form1 : Form
    {
        private MatrixManip test1;

        public Form1()
        {
            InitializeComponent();
            MatrixManip test1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        //calculate the product
        private void button3_Click(object sender, EventArgs e)
        {
            if (test1.calcProduct())
            {
                MessageBox.Show("product of matrices stored in JadeThomas_product.txt");
            }
            else
            {
                MessageBox.Show("The columns and rows are not the same");
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //generate random numbers
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int matrix1column = int.Parse(textBox1.Text);
                int matrix1row = int.Parse(textBox2.Text);

                int matrix2column = int.Parse(textBox4.Text);
                int matrix2row = int.Parse(textBox3.Text);

                test1 = new MatrixManip(matrix1column, matrix2column, matrix1row, matrix2row);
                test1.generateRand();
                MessageBox.Show("generated 2 matrices stored in JadeThomas_Matrices.txt");
            }
            catch (OutOfMemoryException oeme)
            {

                throw oeme;
            }
        }

        //calculate sum
        private void button2_Click(object sender, EventArgs e)
        {
            if (test1.calcSum())
            {
                MessageBox.Show("sum of matrices stored in JadeThomas_sum.txt");
            }
            else
            {
                MessageBox.Show("The columns and rows are not the same");
            }
        }

        private void button1_Click(object sender, EventArgs e)//find std deviation
        {
            test1.calcStdDev();
            MessageBox.Show("std dev of matrix 1 stored in JadeThomas_stddev.txt");
        }
    }
}
