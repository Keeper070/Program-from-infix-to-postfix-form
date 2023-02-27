using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace LR_1
{
    public partial class Form1 : Form
    {
        public static string BufferTextForm1 { get; set; }
        public bool bol = false;
        private readonly Dictionary<char, string> _dictionaryFunction = new Dictionary<char, string>();
        public Dictionary<char, string> dictionaryDigit = new Dictionary<char, string>();
        private bool _automatic = false;
        private bool _takt = false;
     
        //для такта
        public int intBuf=0;
        private string textboxBuff;
        private Queue<char> queueBuff;
        private Stack<char> stackBuff;
        //
        
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        //Словарь для функций
        private void Init()
        {
            _dictionaryFunction.Add('а', "sin");
            _dictionaryFunction.Add('б', "cos");
            _dictionaryFunction.Add('в', "arcsin");
            _dictionaryFunction.Add('г', "arccos");
            _dictionaryFunction.Add('д', "arcctg");
            _dictionaryFunction.Add('е', "arctg");
            _dictionaryFunction.Add('ж', "ctg");
            _dictionaryFunction.Add('з', "tg");
            _dictionaryFunction.Add('и', "ln");
            _dictionaryFunction.Add('к', "arsh");
            _dictionaryFunction.Add('л', "arch");
            _dictionaryFunction.Add('м', "arth");
            _dictionaryFunction.Add('н', "arcth");
            _dictionaryFunction.Add('о', "sh");
            _dictionaryFunction.Add('п', "ch");
            _dictionaryFunction.Add('р', "cth");
            _dictionaryFunction.Add('c', "th");
            _dictionaryFunction.Add('т', "abs");
            _dictionaryFunction.Add('у', "exp");
            _dictionaryFunction.Add('ф', "lg");
            _dictionaryFunction.Add('х', "round");
            _dictionaryFunction.Add('ц', "trunc");
            _dictionaryFunction.Add('ч', "fruc");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Мастер_функций f2 = new Мастер_функций();
            f2.Show();
        }

        #region Кнопка инфиксной формы

        //Для запуска формы 2 
        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = Мастер_функций.BufferText;
        }

        //таймер для синхронизации второй формы textbox c label первой формы
        private void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            label1.Text = Мастер_функций.BufferText;
            BufferTextForm1 = label1.Text;
        }

        #endregion

        // Перебор очереди 
        private string EnumerationQueue(Queue<char> queue)
        {
            string convertBuf = null;
            foreach (var q in queue)
            {
                convertBuf += q;
            }

            textBox2.Text = convertBuf;
            return convertBuf;
        }

        //Перебор и вывод стека
        private void EnumerationStack(Stack<char> stack)
        {
            textBox1.Text = "";
            foreach (var s in stack)
            {
                textBox1.Text += s + @"
 ";
            }
        }

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

        private TextBox texbox2Buff;
        private TextBox texbox1Buff;
        //Перевод из инфиксной в постфиксную форму
        public async Task<string> Translation(string texbox)
        {
            StringBuilder str = new StringBuilder();
            Stack<char> stack = new Stack<char>();
            Queue<char> queue = new Queue<char>();
            
            if (intBuf == 0)
            {
                texbox = TranslationOfFunctions(texbox);
                textboxBuff = texbox;
            }
            else
            {
                texbox = textboxBuff;
                textBox2 = texbox2Buff;
                textBox1 = texbox1Buff;

            }
            
            label7.Text = texbox;
            await Task.Delay(1000);
            
            for (var index = intBuf; index < texbox.Length; index++)
            {
                var symb = texbox[index];
                if (symb == '(')
                {
                    stack.Push(symb);
                }
                else if (symb == ')')
                {
                    while (stack.Peek() != '(')
                    {
                        var buff = stack.Pop();
                        EnumerationStack(stack);
                        await Task.Delay(1000);
                        queue.Enqueue(buff);
                    }

                    if (stack.Peek() == '(')
                    {
                        stack.Pop();
                        EnumerationStack(stack);
                        await Task.Delay(1000);
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
                        while (stack.Peek() != '(')
                        {
                            var buff = stack.Pop();
                            EnumerationStack(stack);
                            await Task.Delay(1000);
                            queue.Enqueue(buff);
                            if (stack.Count == 0)
                            {
                                break;
                            }
                        }

                        stack.Push(symb);
                    }
                }

                EnumerationQueue(queue);
                EnumerationStack(stack);
                await Task.Delay(1000);
                if (_takt)
                {
                    intBuf++;
                    break;
                }
            }

            while (stack.Count != 0)
            {
                var buff2 = stack.Pop();
                EnumerationStack(stack);
                await Task.Delay(3000);
                queue.Enqueue(buff2);
                if (stack.Count == 0)
                {
                    break;
                }
            }

            texbox2Buff = textBox2;
            texbox1Buff = textBox1;
            //Для вывода букв в постфиксный текст бокс
            var convertbuf = EnumerationQueue(queue);

            return convertbuf;
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


        //Стоп
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //Такт
        private async void button4_Click(object sender, EventArgs e)
        {
            await Translation("2+(3*(4+5)");
        }

        //Старт
        private async void button2_Click(object sender, EventArgs e)
        {
            if (_automatic)
            {
                await Translation("2+(3*(4+5)");
            }
            else if (_takt)
            {
                await Translation("2+(3*(4+5)");
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        // Потактовый режим
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _takt = true;
        }


        // Автоматический режим
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _automatic = true;
        }


        private void label5_Click_1(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        //Кнопка очистки
        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label7.Text = "";
            textBox2.Clear();
            textBox1.Clear();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }
    }
}