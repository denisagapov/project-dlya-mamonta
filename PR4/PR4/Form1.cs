using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string text1="";
        private void ОткрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == String.Empty) return;
            try
            {
                var read = new System.IO.StreamReader(
                openFileDialog1.FileName, Encoding.GetEncoding(1251));
                richTextBox2.Text = read.ReadToEnd();
                text1 = richTextBox2.Text;
                read.Close();
            }
            catch (System.IO.FileNotFoundException Ситуация)
            {
                MessageBox.Show(Ситуация.Message + "\nНет такого файла",
                         "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception Ситуация)
            {
                MessageBox.Show(Ситуация.Message,
                     "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void СохранитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var write = new System.IO.StreamWriter(
                    saveFileDialog1.FileName, false,
                    System.Text.Encoding.GetEncoding(1251));
                    write.Write(richTextBox2.Text);
                    write.Close();
                }
                catch (Exception Ситуация)
                {
                    MessageBox.Show(Ситуация.Message,
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            openFileDialog1.FileName = @"";
            openFileDialog1.Filter =
                     "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Filter =
                     "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "НАЙТИ:" + Environment.NewLine;
            string source = richTextBox2.Text;
            string sub = textBox3.Text;
            int pos1 = richTextBox2.SelectionStart;
            int index = source.IndexOf(sub);
            while (index!=-1)
            {
                richTextBox2.Select(index, sub.Length);
                richTextBox2.SelectionFont = new Font(richTextBox2.SelectionFont, FontStyle.Bold);
                richTextBox2.SelectionStart = pos1;
                richTextBox2.SelectionFont = new Font(richTextBox2.SelectionFont, FontStyle.Regular);
                richTextBox1.Text = richTextBox1.Text + "Первое слово начинается с позиции - " + index + Environment.NewLine;
                index = source.IndexOf(sub, index + sub.Length);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text + Environment.NewLine;
            string source = richTextBox2.Text;
            string sub = textBox4.Text;
            int index = source.IndexOf(sub);
            while (index != -1)
            {
                richTextBox2.Select(index, sub.Length);
                richTextBox2.SelectionFont = new Font(richTextBox2.SelectionFont, FontStyle.Bold);
                richTextBox2.SelectionFont = new Font(richTextBox2.SelectionFont, FontStyle.Regular);
                richTextBox1.Text = richTextBox1.Text + "Второе слово начинается с позиции - " + index + Environment.NewLine;
                index = source.IndexOf(sub, index + sub.Length);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            string s = richTextBox2.Text;
            string[] words = s.Split(' ');
            string s1 = textBox3.Text;
            string s2 = textBox4.Text;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i]== s1)
                {
                    words[i] = s2;
                }
                else if(words[i] == s2)
                {
                    words[i] = s1;
                }
            }
            string s3 = string.Join(" ", words);
            richTextBox2.Text = s3;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = text1;
        }
    }
}
