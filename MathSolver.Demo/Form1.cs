using System;
using System.Drawing;
using System.Windows.Forms;
using MathSolver;

namespace MathSolver.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.TextChanged += textBox1_TextChanged;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ClearMsg();
        }

        private void ClearMsg()
        {
            msg.Text = string.Empty;
            textBox1.BackColor = SystemColors.Window;
            textBox1.ForeColor = SystemColors.ControlText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Parser p = new Parser();
                IExpression exp = p.Parse(textBox1.Text);
                if (exp != null)
                {
                    ClearMsg();
                    MessageBox.Show(exp.Calc(new ConstantResolver(double.Parse(textBox2.Text))).ToString());
                }
                else
                {
                    msg.Text = "Expressão Inválida!";
                    textBox1.BackColor = Color.LightYellow;
                    textBox1.ForeColor = Color.Black;
                }
            }
            catch (FormatException)
            {
                msg.Text = "Verifique o valor de x";
            }
            catch (Exception ex)
            {
                msg.Text = ex.Message;
            }
        }
    }
}