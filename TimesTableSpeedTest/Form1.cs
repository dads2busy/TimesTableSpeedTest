using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace TimesTableSpeedTest
{
    public partial class Form1 : Form
    {

        public static List<int> leftInts;
        public static List<int> rightInts;
        public static List<Equation> equations;
        public static Equation currentEquation;
        public static int currentEquationNumber;
        public static int maxEquationNumber;
        public static Stopwatch sw;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateInts();
            
            equations = GenerateEq.GenerateEquations(leftInts, Operation.Multiply, rightInts).ToList();
            currentEquation = equations[0];
                
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = equations;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSource1;

            textBox4.Text = BuildEquation(0);

            sw = new Stopwatch();
            sw.Start();
        }

        private string BuildEquation(int equationNumber)
        {
            string operation = "";
            switch (equations[equationNumber].operation)
            {
                case Operation.Multiply:
                    operation = " x ";
                    break;
                case Operation.Divide:
                    operation = " / ";
                    break;
                case Operation.Add:
                    operation = " + ";
                    break;
                case Operation.Subtract:
                    operation = " - ";
                    break;
            }
            return equations[equationNumber].leftTerm.ToString() + operation + equations[equationNumber].rightTerm.ToString();
        }

        private void updateInts()
        {
            if (leftInts != null)
                leftInts.Clear();
            else
                leftInts = new List<int>();
            if (checkBoxL1.Checked)
                leftInts.Add(1);
            if (checkBoxL2.Checked)
                leftInts.Add(2);
            if (checkBoxL3.Checked)
                leftInts.Add(3);
            if (checkBoxL4.Checked)
                leftInts.Add(4);
            if (checkBoxL5.Checked)
                leftInts.Add(5);
            if (checkBoxL6.Checked)
                leftInts.Add(6);
            if (checkBoxL7.Checked)
                leftInts.Add(7);
            if (checkBoxL8.Checked)
                leftInts.Add(8);
            if (checkBoxL9.Checked)
                leftInts.Add(9);
            if (checkBoxL10.Checked)
                leftInts.Add(10);
            if (checkBoxL11.Checked)
                leftInts.Add(11);
            if (checkBoxL12.Checked)
                leftInts.Add(12);
            if (leftInts.Count == 0)
            {
                leftInts.Add(1);
                checkBoxL1.Checked = true;
            }

            if (rightInts != null)
                rightInts.Clear();
            else
                rightInts = new List<int>();
            if (checkBoxL1.Checked)
                rightInts.Add(1);
            if (checkBoxL2.Checked)
                rightInts.Add(2);
            if (checkBoxL3.Checked)
                rightInts.Add(3);
            if (checkBoxL4.Checked)
                rightInts.Add(4);
            if (checkBoxL5.Checked)
                rightInts.Add(5);
            if (checkBoxL6.Checked)
                rightInts.Add(6);
            if (checkBoxL7.Checked)
                rightInts.Add(7);
            if (checkBoxL8.Checked)
                rightInts.Add(8);
            if (checkBoxL9.Checked)
                rightInts.Add(9);
            if (checkBoxL10.Checked)
                rightInts.Add(10);
            if (checkBoxL11.Checked)
                rightInts.Add(11);
            if (checkBoxL12.Checked)
                rightInts.Add(12);
            if (rightInts.Count == 0)
            {
                rightInts.Add(1);
                checkBoxR1.Checked = true;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Text += "1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Text += "2";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox5.Text += "3";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox5.Text += "4";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox5.Text += "5";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Text += "6";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox5.Text += "9";
        }
 
        private void button9_Click(object sender, EventArgs e)
        {
            textBox5.Text += "8";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox5.Text += "7";
        }

        private void NumPad0_Click(object sender, EventArgs e)
        {
            textBox5.Text += "0";
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.NumPad1)
            {
                NumPad1.PerformClick();
                return true;
            }
            if (keyData == Keys.NumPad2)
            {
                NumPad2.PerformClick();
                return true;
            }
            if (keyData == Keys.NumPad3)
            {
                NumPad3.PerformClick();
                return true;
            }
            if (keyData == Keys.NumPad4)
            {
                NumPad4.PerformClick();
                return true;
            }
            if (keyData == Keys.NumPad5)
            {
                NumPad5.PerformClick();
                return true;
            }
            if (keyData == Keys.NumPad6)
            {
                NumPad6.PerformClick();
                return true;
            }
            if (keyData == Keys.NumPad7)
            {
                NumPad7.PerformClick();
                return true;
            }
            if (keyData == Keys.NumPad8)
            {
                NumPad8.PerformClick();
                return true;
            }
            if (keyData == Keys.NumPad9)
            {
                NumPad9.PerformClick();
                return true;
            }
            if (keyData == Keys.NumPad0)
            {
                NumPad0.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private bool checkAnswer()
        {
            if (float.Parse(textBox5.Text) == currentEquation.answer)
            {
                currentEquationNumber++;
                currentEquation = equations[currentEquationNumber];
                textBox4.Text = BuildEquation(currentEquationNumber);
                textBox5.Text = "";
                return true;
            }
            else
                return false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (currentEquationNumber != equations.Count)
            {
                if (textBox5.Text.Length > 0 && equations != null)
                {
                    if (currentEquationNumber < equations.Count - 1)
                        currentAnswer.Text = checkAnswer().ToString();
                }
            }
            else
            {
                sw.Stop();
                currentAnswer.Text = sw.ElapsedMilliseconds.ToString();
            }
                       
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox5.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
              
    }


}
