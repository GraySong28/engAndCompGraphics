using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Создаю объек parabola класса Graphics и передаём ему право рисовать на PB1
            Graphics parabola = pictureBox1.CreateGraphics();
            // Меняю цвет фона при нажатии
            pictureBox1.BackColor = Color.FromName("White");
            pictureBox1.Refresh();
            // Переключаю юниты на пикселы
            parabola.PageUnit = GraphicsUnit.Pixel;
            // Создаю кисть для рисования контура и координатных осей
            Pen penForCountur = new Pen(Color.Tomato, 1);
            // Рисую рамку, оси X и Y
            parabola.DrawRectangle(penForCountur, 0, 0, pictureBox1.Size.Width - 1, pictureBox1.Size.Height - 1);
            parabola.DrawLine(penForCountur, 0, (pictureBox1.Size.Height / 2) - 1, pictureBox1.Size.Width - 1, (pictureBox1.Size.Height / 2) - 1);
            parabola.DrawLine(penForCountur, (pictureBox1.Size.Width / 2) - 1, 0, (pictureBox1.Size.Width / 2) - 1, pictureBox1.Size.Height - 1);
            // Получаю цену деления по осям в пикселях
            int delForX = pictureBox1.Size.Width / 20;
            int delForY = pictureBox1.Size.Height / 20;
            // Вывожу деления на оси
            for (int i = 0; i < 20; i++)
            {
                parabola.DrawLine(penForCountur, i * delForX, (pictureBox1.Size.Height / 2) - 1, i * delForX, (pictureBox1.Size.Height / 2) + 10);
                parabola.DrawLine(penForCountur, (pictureBox1.Size.Width / 2) - 1, Convert.ToInt16(i * delForY), (pictureBox1.Size.Width / 2) + 10, Convert.ToInt16(i * delForY));
            }
            // Создаю кисть для рисования графика
            Pen penForParabola = new Pen(Color.FromArgb(0, 0, 0), 1);
            // Рисую график функции y=3x^2+1
            int ex, ey, old_ex = 0, old_ey = 0;
            double x = 0, y = 0;
            x = -10;
            for (ex = 0; ex < pictureBox1.Size.Width; ex++)
            {
                y = (3 * x * x) + 1;
                ey = (pictureBox1.Size.Height - 1) - (Convert.ToInt32(y * delForY) + (pictureBox1.Size.Height / 2));
                parabola.DrawLine(penForParabola, old_ex, old_ey, ex, ey); 
                old_ex = ex; old_ey = ey;
                x += 0.02;
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            // Создаю объек parabola класса Graphics и передаём ему право рисовать на PB1
            Graphics parabola = pictureBox1.CreateGraphics();
            // Меняю цвет фона при нажатии
            pictureBox1.BackColor = Color.FromName("White");
            pictureBox1.Refresh();
            // Переключаю юниты на пикселы
            parabola.PageUnit = GraphicsUnit.Millimeter;
            // Создаю кисть для рисования контура и координатных осей
            Pen penForCountur = new Pen(Color.Tomato, 0.1f);
            // Получаем размеры PB в ММ
            int WidthInMM = Convert.ToInt16((pictureBox1.Size.Width - 1) / parabola.DpiX * 25.4);
            int HeightInMM = Convert.ToInt16((pictureBox1.Size.Height - 1) / parabola.DpiY * 25.4);
            //Console.WriteLine(WidthInMM);
            //Console.WriteLine(HeightInMM);
            // Рисую рамку, оси X и Y
            parabola.DrawRectangle(penForCountur, 0, 0, WidthInMM, HeightInMM);
            parabola.DrawLine(penForCountur, 0, HeightInMM / 2, WidthInMM, HeightInMM / 2);
            parabola.DrawLine(penForCountur, WidthInMM / 2, 0, WidthInMM / 2, HeightInMM);
            // Получаю цену деления по осям в пикселях
            int delForX = WidthInMM / 15;
            int delForY = HeightInMM / 10;
            // Вывожу деления на оси
            for (int i = 0; i < 15; i++)
            {
                parabola.DrawLine(penForCountur, i * delForX - 4, HeightInMM / 2, i * delForX - 4, (HeightInMM / 2) + 2);
                parabola.DrawLine(penForCountur, WidthInMM / 2, Convert.ToInt16(i * delForY + 1), (WidthInMM / 2) + 2, Convert.ToInt16(i * delForY + 1));
            }
            // Создаю кисть для рисования графика
            Pen penForParabola = new Pen(Color.FromArgb(0, 0, 0), 0.1f);
            // Рисую график функции y=3x^2+1
            int ex, ey, old_ex = 0, old_ey = 0;
            double x = 0, y = 0;
            x = -10;
            for (ex = 0; ex <= WidthInMM; ex++)
            {
                y = (3 * x * x) + 1;
                // (pictureBox1.Size.Height - 1) - (Convert.ToInt32(y * delForY) + (pictureBox1.Size.Height / 2));
                ey = HeightInMM - Convert.ToInt32(y * delForY) - (HeightInMM / 2);
                parabola.DrawLine(penForParabola, old_ex, old_ey, ex, ey);
                old_ex = ex; old_ey = ey;
                x += 0.075;
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            // Создаю объек parabola класса Graphics и передаём ему право рисовать на PB1
            Graphics parabola = pictureBox1.CreateGraphics();
            // Меняю цвет фона при нажатии
            pictureBox1.BackColor = Color.FromName("White");
            pictureBox1.Refresh();
            // Переключаю юниты на пикселы
            parabola.PageUnit = GraphicsUnit.Inch;
            // Создаю кисть для рисования контура и координатных осей
            Pen penForCountur = new Pen(Color.Tomato, 0.01f);
            // Получаем размер PB в Дюймах
            float WidthInInches = (pictureBox1.Size.Width - 1) / parabola.DpiX;
            float HeightInInches = (pictureBox1.Size.Height - 1) / parabola.DpiY;
            // Рисую рамку, оси X и Y
            parabola.DrawRectangle(penForCountur, 0, 0, WidthInInches, HeightInInches);
            parabola.DrawLine(penForCountur, 0, HeightInInches / 2, WidthInInches, HeightInInches / 2);
            parabola.DrawLine(penForCountur, WidthInInches / 2, 0, WidthInInches / 2, HeightInInches);
            Console.WriteLine(WidthInInches);
            Console.WriteLine(HeightInInches);
            // Получаю цену деления по осям в пикселях
            float delForX = WidthInInches / 10;
            //float delForY = HeightInInches / 5;
            // Вывожу деления на оси
            for (int i = 0; i < 10; i++)
            {
                parabola.DrawLine(penForCountur, (i * delForX), HeightInInches / 2, (i * delForX), (HeightInInches / 2) + 1);
                //parabola.DrawLine(penForCountur, WidthInInches / 2, Convert.ToInt16((i * delForY) + 1), (WidthInInches / 2) + 1, Convert.ToInt16((i * delForY) + 1));
            }
            // Создаю кисть для рисования графика
            Pen penForParabola = new Pen(Color.FromArgb(0, 0, 0), 0.01f);
            // Рисую график функции y=3x^2+1
            float ex = 0, old_ex = 0, ey = 0, old_ey = 0;
            float x = 0, y = 0;
            float shag;
            x = Convert.ToSingle(- 5.2);
            shag = Convert.ToSingle(WidthInInches / 100);
            while (ex <= WidthInInches + shag)
            {
                y = (3 * x * x) + 1;
                ey = Convert.ToSingle(-y) + HeightInInches / 2;
                parabola.DrawLine(penForParabola, old_ex, old_ey, ex, ey);
                old_ex = ex; old_ey = ey;
                ex = ex + shag;
                x += shag;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Graphics clear = pictureBox1.CreateGraphics();
            clear.Clear(Color.FromArgb(220, 220, 220));
        }                
    }
}
