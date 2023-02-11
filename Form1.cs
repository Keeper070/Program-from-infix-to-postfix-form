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
        public Dictionary<string, char> Letter1 = new Dictionary<string, char>();
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

       
        //Метод замены всех кнопок Мастера функций на буквы A-Ч
        public  void Letter()
        {
            Letter1.Add("arcsin", 'а');
            Letter1.Add("arccos", 'б');
            Letter1.Add("sin", 'в');
            Letter1.Add("cos", 'г');
            Letter1.Add( "arcctg", 'д');
            /*{ "sin", 'в' },
            { "cos", 'г' },
            { "arcctg", 'д' },
            { "arctg", 'е' },
            { "ctg", 'ж' },
            { "tg", 'з' },
            { "ln", 'и' },
            { "arsh", 'к' },
            { "arch", 'л' },
            { "arth", 'м' },
            { "arcth", 'н' },
            { "sh", 'о' },
            { "ch", 'п' },
            { "cth", 'р' },
            { "th", 'с' },
            { "abs", 'т' },
            { "exp", 'у' },
            { "lg", 'ф' },
            { "round", 'х' },
            { "trunc", 'ц' },
            { "fruc", 'ч' }*/

        }


        //Перевод из инфиксной в постфиксную форму
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

                        if (stack.Count == 0 || stack.Peek() == '(')
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
                    if (Letter1.ContainsKey(symb.ToString()))
                    {
                        /*Letter1.TryGetValue(symb.ToString(),symb)*/
                    } 
                    else  if (stack.Count == 0 || stack.Peek() == '(')
                    {
                        stack.Push(symb);
                    }
                    else if (symb == '*' || symb == '/')
                    {
                        stack.Push(symb);
                    }
                    else if (symb == '+' || symb == '-')
                    {
                        while (stack.Peek() != '(' || stack.Peek() != '+' || stack.Peek() != '-')
                        {
                            var buff = stack.Pop();
                            queue.Enqueue(buff);
                            if (stack.Count == 0)
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

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        //Вывод стека
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}