﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calcApp
{
    public enum Operators { Add, Sub, Multi, Div }
    public partial class Calculator : Form
    {
        public int Result = 0;
        public bool isNewNum = true;
        public Operators Opt = Operators.Add;
        public Calculator()
        {
            InitializeComponent();
        }
        public int Add(int number1, int number2)
        {
            int sum = number1 + number2;
            return sum;
        }
        public int Sub(int number1, int number2)
        {
            int sub = number1 - number2;
            return sub;
        }
        public int Multi(int number1, int number2)
        {
            int mul = number1 * number2;
            return mul;
        }
        public int Div(int number1, int number2)
        {
            int div = number1 / number2;
            return div;
        }


        public void setNum(string num)
        {
            if (isNewNum)
            {
                NumDisplay.Text = num;
                isNewNum = false;
            }
            else
            {
                NumDisplay.Text = NumDisplay.Text + num;
            }
        }

        private void ButtonNum_Click(object sender, EventArgs e)
        {
            Button numButton = (Button)sender;
            setNum(numButton.Text);
        }

        private void NumOpt_Click(object sender, EventArgs e)
        {
            // isNewNum이 false라는 의미는 연산자가 눌러진 다음에 숫자가 눌러졌다는 의미 
            if (isNewNum == false)
            {
                int num = int.Parse(NumDisplay.Text);
                if (Opt == Operators.Add)
                    Result = Add(Result, num);
                else if (Opt == Operators.Sub)
                    Result = Sub(Result, num);
                else if (Opt == Operators.Multi)
                    Result = Multi(Result, num);
                else if (Opt == Operators.Div)
                    Result = Div(Result, num);

                NumDisplay.Text = Result.ToString();
                isNewNum = true;
            }
            Button optButton = (Button)sender;
            if (optButton.Text == "+")
                Opt = Operators.Add;
            else if (optButton.Text == "-")
                Opt = Operators.Sub;
            else if (optButton.Text == "×")
                Opt = Operators.Multi;
            else if (optButton.Text == "÷")
                Opt = Operators.Div;
        }
        private void NumClear_Click(object sender, EventArgs e)
        {
            Result = 0;
            isNewNum = true;
            Opt = Operators.Add;

            NumDisplay.Text = "0";
        }
    }
}