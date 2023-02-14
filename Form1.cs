using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace LR_1
{
    public partial class Form1 : Form
    {
        public static string BufferTextForm1 { get; set; }
        public bool bol = false;
        string convertBuf = null;
        public Dictionary<char, string> dictionary = new Dictionary<char, string>();

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
        /*public void Letter()
        {
            Letter1.Add("arcsin", 'а');
            Letter1.Add("arccos", 'б');
            Letter1.Add("sin", 'в');
            Letter1.Add("cos", 'г');
            Letter1.Add("arcctg", 'д');
            Letter1.Add("arctg", 'е');
            Letter1.Add("ctg", 'ж');
            Letter1.Add("tg", 'з');
            Letter1.Add("ln", 'и');
            Letter1.Add("arsh", 'к');
            Letter1.Add("arch", 'л');
            Letter1.Add("arth", 'м');
            Letter1.Add("arcth", 'н');
            Letter1.Add("sh", 'о');
            Letter1.Add("ch", 'п');
            Letter1.Add("cth", 'р');
            Letter1.Add("th", 'с');
            Letter1.Add("abs", 'т');
            Letter1.Add("exp", 'у');
            Letter1.Add("lg", 'ф');
            Letter1.Add("round", 'х');
            Letter1.Add("trunc", 'ц');
            Letter1.Add("fruc", 'ч');
        }*/

        // Первеод функции и цифры  в символ
        private void TranslationOfFunctions(string textbox, StringBuilder strb)
        {
            char chDigit = 'A';
            char chLetter = 'а';

            for (int i = 0; i < textbox.Length; i++)
            {
                # region Цифра
                while (char.IsDigit(textbox[i]))
                {
                    strb.Append(textbox[i]);
                    dictionary.Add(chDigit, strb.ToString());
                    break;
                }

                if (char.IsDigit(textbox[i]))
                {
                    strb.Clear();
                    chDigit++;
                }
                #endregion
                
                # region Функция 
                while (!char.IsDigit(textbox[i]) && textbox[i] != '(' && textbox[i] != '-' && textbox[i] != '+' &&
                       textbox[i] != '/' && textbox[i] != '^' && textbox[i] != ')')
                {
                    strb.Append(textbox[i]);
                    dictionary.Add(chLetter, strb.ToString());
                    break;
                }

                if (!char.IsDigit(textbox[i]) && textbox[i] != '(' && textbox[i] != '-' && textbox[i] != '+' &&
                    textbox[i] != '/' && textbox[i] != '^' && textbox[i] != ')')
                {
                    strb.Clear();
                    chLetter++;
                }
                #endregion
                
                
            }

           
        }

        //Перевод из инфиксной в постфиксную форму
        private void TranslationInfPost()
        {
            string textbox = label1.Text;
            StringBuilder str = new StringBuilder();
            Stack<char> stack = new Stack<char>();
            Queue<char> queue = new Queue<char>();
            
            TranslationOfFunctions(textbox, str);
           
            foreach (char symb in textbox)
            {
                if (Char.IsUpper(symb))
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

                    if (symb == '(') // зайдем ли мы сюда хоть раз? Объяснить почему
                    {
                        stack.Pop();
                    }
                }
                else if (!char.IsUpper(symb))
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}