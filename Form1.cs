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
        private readonly Dictionary<char, string> _dictionaryFunction = new Dictionary<char, string>();
        public Dictionary<char, string> dictionaryDigit = new Dictionary<char, string>();

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            _dictionaryFunction.Add('а', "sin");
            _dictionaryFunction.Add('б', "cos");
            _dictionaryFunction.Add('в', "arcsin");
            _dictionaryFunction.Add('г', "arccos");
            _dictionaryFunction.Add('д', "^");
            // dictionaryDigit.Add('a', "sin");   
            // dictionaryDigit.Add('a', "sin");   
            // dictionaryDigit.Add('a', "sin");   
            // dictionaryDigit.Add('a', "sin");   
            // dictionaryDigit.Add('a', "sin");   
        }


        private void button1_Click(object sender, EventArgs e)
        {
            /*TranslationInfPost(label1.Text);*/
            Translation(label1.Text);
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

        // Перевод функций и цифр  в символ
        private string TranslationOfFunctions(string str)
        {
            char charDigit = 'A';
            StringBuilder list = new StringBuilder();
            StringBuilder outStr = new StringBuilder();

            var i = 0;
            while (i < str.Length)
            {
                if (char.IsDigit(str[i]))
                {
                    // Цикл для добавления цифры в список 
                    while (char.IsDigit(str[i]))
                    {
                        list.Append(str[i]);
                        if (i + 1 >= str.Length || !char.IsDigit(str[i + 1]))
                        {
                            i++;
                            break;
                        }

                        i++;
                    }

                    dictionaryDigit.Add(charDigit, list.ToString());
                    list.Clear();
                    outStr.Append(charDigit);
                    charDigit++;
                }
                else if (char.IsLetter(str[i]))
                {
                    //Цикл для добавления функции в список 
                    while (char.IsLetter(str[i]))
                    {
                        list.Append(str[i]);
                        if (i + 1 >= str.Length && char.IsLetter(str[i + 1]))
                            break;
                        i++;
                    }

                    //Для добавления функции в выходной список 
                    for (int j = 0; j < _dictionaryFunction.Count; j++)
                    {
                        if (list.ToString() == _dictionaryFunction.Values.ElementAt(j))
                        {
                            outStr.Append(_dictionaryFunction.Keys.ElementAt(j));
                            list.Clear();
                            break;
                        }
                    }
                }
                // Для добавления символов в выходной список 
                else if (str[i] == '(' || str[i] == '+' || str[i] == '-' || str[i] == ')' || str[i] == '/' ||
                         str[i] == '*' || str[i] == '^')
                {
                    outStr.Append(str[i]);
                    i++;
                }
            }

            return outStr.ToString();
        }

        //Перевод из инфиксной в постфиксную форму
        public string Translation(string texbox)
        {
            StringBuilder str = new StringBuilder();
            Stack<char> stack = new Stack<char>();
            Queue<char> queue = new Queue<char>();

            texbox = TranslationOfFunctions(texbox);
            foreach (var symb in texbox)
            {
                if (symb == '(')
                {
                    stack.Push(symb);
                }
                else if (symb == ')')
                {
                    while (stack.Peek() != '(')
                    {
                        var buff = stack.Pop();
                        queue.Enqueue(buff);
                    }

                    if (stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                }
                else if (char.IsUpper(symb))
                {
                    queue.Enqueue(symb);
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
                        while (stack.Peek() != '(' )
                        {
                            var buff = stack.Pop();
                            queue.Enqueue(buff);
                            if (stack.Count == 0 )
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

            return convertBuf;
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