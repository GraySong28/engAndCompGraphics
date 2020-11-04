using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        // Объявляем объект "g" класса Graphics
        Graphics g;
        string filename = @"Strings.txt";
        string[] sm = {"First line", "Second line", "Third line",
                       "Fourth line", "Fifth line", "Sixth line",
                       "Seventh line", "Eighth line", "Ninth line",
                       "Tenth line", "Eleven line", "Twelve line"};
        public Form1()
        {
            InitializeComponent();
            // Предоставляем объекту "g" класса Graphics возможность рисования на pictureBox1:
            g = pictureBox1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter f = new StreamWriter(new FileStream(filename, FileMode.Create, FileAccess.Write));
            foreach (string s in sm) { f.WriteLine(s); }
            f.Close();
            MessageBox.Show("12 строк записано в файл!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int k = 0;
            // Чтение строк из файла
            try
            {
                StreamReader f = new StreamReader(new FileStream(filename, FileMode.Open, FileAccess.Read));
                for (int i = 0; i < 12; i++) { sm[i] = f.ReadLine(); }
                f.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            // Отображение строк 
            pictureBox1.BackColor = Color.FromName("White");
            pictureBox1.Refresh();
            for (int i = 0; i < 12; i++)
            {
                // Отображение первой группы строк
                if ((i >= 0) && (i < 6))
                {
                    Font fn = new Font("Calibri", 36, FontStyle.Strikeout);
                    StringFormat sf = (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    g.DrawString(sm[i], fn, Brushes.Yellow, new RectangleF(0 + i * 36, 0, pictureBox1.Size.Width-1, pictureBox1.Size.Height-1), sf);
                    fn.Dispose();
                }
                // Отображение второй группы строк
                if ((i >= 6) && (i < 11))
                {
                    k = i - 6;
                    Font fn = new Font("Consolas", 24, FontStyle.Bold);
                    StringFormat sf = (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Near;
                    g.DrawString(sm[i], fn, Brushes.Purple, new RectangleF(0, 0 + k * 24, pictureBox1.Size.Width - 20, pictureBox1.Size.Height - 20), sf);
                    fn.Dispose();
                }
                // Отображение третьей группы строк
                if (i == 11)
                {
                    //g.PageUnit = GraphicsUnit.Inch;
                    Font fn = new Font("Corbel", 36, FontStyle.Underline);
                    StringFormat sf = (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Near;
                    g.DrawString(sm[i], fn, Brushes.Green, new RectangleF(0, 0 + i * 10, pictureBox1.Size.Width, pictureBox1.Size.Height), sf);
                    fn.Dispose();
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.FromArgb(220, 220, 220));
            File.Delete(filename);
            MessageBox.Show("Файл Strings.txt удалён!");
        }
    }
}
