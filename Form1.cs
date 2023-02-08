using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using System.Windows.Forms;

namespace LR_1
{
    public partial class Form1 : Form
    {
        public static string BufferTextForm1 { get; set; }
        public bool bol = false;
        string convertBuf = null;

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            bol = true;
            if (bol)
            {
                TranslationInfPost();
            }
        }

        #region Кнопка инфиксной формы

        //Для запуска формы 2 
        private void label1_Click(object sender, EventArgs e)
        {
            Мастер_функций f2 = new Мастер_функций();
            f2.Show();
        }

        //таймер для синхронизации второй формы textbox c label первой формы
        private void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            label1.Text = Мастер_функций.BufferText;
            BufferTextForm1 = label1.Text;
        }

        #endregion


        private void TranslationInfPost()
        {
            String el = label1.Text;
            Stack<char> stack = new Stack<char>();
            Queue<char> queue = new Queue<char>();
            
            foreach (char symb in el)
            {
                if (Char.IsDigit(symb))
                {
                    queue.Enqueue(symb);
                }
                else if (symb == '(')
                {
                    stack.Push(symb);
                }
                else if (symb == ')')
                {
                    while (stack.Peek() != '(')
                    {
                        var buff1 = stack.Pop();
                        queue.Enqueue(buff1);
                        
                        if (stack.Count == 0 || stack.Peek()=='(')
                        {
                            stack.Pop();
                            break;
                        }
                        
                    }

                    if (symb == '(')
                    {
                        stack.Pop();
                    }
                }
                else if (!Char.IsDigit(symb))
                {
                    if (stack.Count == 0 || stack.Peek() == '(')
                    {
                        stack.Push(symb);
                    }
                    else if (symb == '*' || symb == '/')
                    {
                        stack.Push(symb);
                    }
                    else if (symb == '+' || symb == '-')
                    {
                       
                            while (stack.Peek() != '('  || stack.Peek() != '+' || stack.Peek() != '-' )
                            {
                               

                                var buff = stack.Pop();
                                queue.Enqueue(buff);
                                if (stack.Count == 0  )
                                {
                                    break;
                                }
                                

                            }
                            stack.Push(symb);
                    }
                }
            }

            while (stack.Count != 0)
            {
                var buff2 = stack.Pop();
                queue.Enqueue(buff2);

                if (stack.Count == 0)
                {
                    break;
                }
            }

            foreach (var q in queue)
            {
                convertBuf += q;
            }

            textBox2.Text = convertBuf;
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}