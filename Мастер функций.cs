using System;
using System.Drawing;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace LR_1
{
    public partial class Мастер_функций : Form
    {
        private int _index;

        public Мастер_функций()
        {
            InitializeComponent();
        }

        public static string BufferText { get; set; }

        private void Мастер_функций_Load(object sender, EventArgs e)
        {
        }

        #region Byttons

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += 0;
        }

        private void button15_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += 6;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += 7;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += 8;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += 9;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += '.';
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "Pi";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += ')';
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += '(';
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox1.Text += '+';
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox1.Text += '-';
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox1.Text += '*';
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox1.Text += '/';
        }

        private void button30_Click(object sender, EventArgs e)
        {
            textBox1.Text += "ln";
        }

        private void button28_Click(object sender, EventArgs e)
        {
            textBox1.Text += "lg";
        }

        private void button26_Click(object sender, EventArgs e)
        {
            textBox1.Text += '^';
        }

        private void button25_Click(object sender, EventArgs e)
        {
            textBox1.Text += "exp";
        }

        private void button29_Click(object sender, EventArgs e)
        {
            textBox1.Text += "sqr";
        }

        private void button27_Click(object sender, EventArgs e)
        {
            textBox1.Text += "sqrt";
        }


        private void button38_Click(object sender, EventArgs e)
        {
            textBox1.Text += "sin";
        }

        private void button36_Click(object sender, EventArgs e)
        {
            textBox1.Text += "cos";
        }

        private void button34_Click(object sender, EventArgs e)
        {
            textBox1.Text += "tg";
        }

        private void button32_Click(object sender, EventArgs e)
        {
            textBox1.Text += "ctg";
        }

        private void button37_Click(object sender, EventArgs e)
        {
            textBox1.Text += "arcsin";
        }

        private void button35_Click(object sender, EventArgs e)
        {
            textBox1.Text += "arccos";
        }

        private void button33_Click(object sender, EventArgs e)
        {
            textBox1.Text += "arctg";
        }

        private void button31_Click(object sender, EventArgs e)
        {
            textBox1.Text += "arcctg";
        }

        private void button46_Click(object sender, EventArgs e)
        {
            textBox1.Text += "sh";
        }

        private void button44_Click(object sender, EventArgs e)
        {
            textBox1.Text += "ch";
        }

        private void button42_Click(object sender, EventArgs e)
        {
            textBox1.Text += "th";
        }

        private void button40_Click(object sender, EventArgs e)
        {
            textBox1.Text += "cth";
        }

        private void button45_Click(object sender, EventArgs e)
        {
            textBox1.Text += "arsh";
        }

        private void button43_Click(object sender, EventArgs e)
        {
            textBox1.Text += "arch";
        }

        private void button41_Click(object sender, EventArgs e)
        {
            textBox1.Text += "arth";
        }

        private void button39_Click(object sender, EventArgs e)
        {
            textBox1.Text += "arcth";
        }

        private void button50_Click(object sender, EventArgs e)
        {
            textBox1.Text += "round";
        }

        private void button49_Click(object sender, EventArgs e)
        {
            textBox1.Text += "trunc";
        }

        private void button48_Click(object sender, EventArgs e)
        {
            textBox1.Text += "func";
        }


        private void button47_Click(object sender, EventArgs e)
        {
            textBox1.Text += "abs";
        }

        private void button51_Click(object sender, EventArgs e)
        {
            textBox1.Text += "RandR";
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BufferText = textBox1.Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            _index = _index >= 0 ? --_index : _index;
            textBox1.SelectionStart = _index + 1;
            textBox1.Focus();
        }

        #region Курсор по textBox
        private void ButtonArrows()
        {
           
            textBox1.SelectionStart = _index + 1;
            textBox1.Focus();
            _index++;
           
        }
        private void button17_Click(object sender, EventArgs e)
        {
            _index = _index < textBox1.Text.Length - 1 ? ++_index : _index;
            textBox1.SelectionStart = _index + 1;
            textBox1.Focus();
          
        }
        private void button15_Click_1(object sender, EventArgs e)
        {
            textBox1.SelectionStart = 0;
            textBox1.Focus();
        }
        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.Focus();
        }
        #endregion
        
     
        private void button20_Click(object sender, EventArgs e)
        {
           
           textBox1.Text= textBox1.Text.Substring(0, textBox1.Text.Length - 1); 
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            
        }

        // Метод реализованнй для того, чтобы при повторном открытии мастера функций не стиралась старая форма 
        private void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (textBox1.Text == "" && Form1.BufferTextForm1 != null)
            {
                textBox1.Text = Form1.BufferTextForm1;
            }
        }

        #endregion
        // Кнопка принять
        private void button52_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Кнопка отклонить
        private void button53_Click(object sender, EventArgs e)
        {
           
            textBox1.Clear();
            Close();
        }
    }
}