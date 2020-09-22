using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Меняю цвет фона при нажатии
            pictureBox1.BackColor = Color.FromName("LightCyan");
            pictureBox1.Refresh();

            // Создаю кисть для рисования контура и координатных осей
            Pen penForCountur = new Pen(Color.Tomato, 1);
            // Объявил объект axles класса Graphics, ередал ему права для рисования в PB1
            Graphics axles = pictureBox1.CreateGraphics();
            // Рисуем прямоугольник:
            axles.DrawRectangle(penForCountur, 0, 0, pictureBox1.Size.Width - 1, pictureBox1.Size.Height - 1);
            // рисуем ось X и Y
            axles.DrawLine(penForCountur, 0, (pictureBox1.Size.Height / 2) - 1, pictureBox1.Size.Width - 1, (pictureBox1.Size.Height / 2) - 1);
            axles.DrawLine(penForCountur, (pictureBox1.Size.Width / 2) - 1, 0, (pictureBox1.Size.Width / 2) - 1, pictureBox1.Size.Height - 1);
            
            // Объявил объект parabola класса Graphics, ередал ему права для рисования в PB1
            Graphics parabola = pictureBox1.CreateGraphics();
            // Поменял единицы измерения на Пиксели
            parabola.PageUnit = GraphicsUnit.Pixel;
            // Кисть для рисование графика
            Pen penForParabola = new Pen(Color.FromArgb(0, 0, 0));            
            // Рисуем график функции y=3x^2+1
            int ex = 0, ey = 0, old_ex = 0, old_ey = 0;
            double x = 0, y = 0;
            x = - 10;
            for (ex = 350; ex <= 550; ex++)
            {
                y = (3 * x * x) + 1;
                ey = (pictureBox1.Size.Height - 1) - (Convert.ToInt16(y + 225));
                if (ex != 0) 
                { 
                    parabola.DrawLine(penForParabola, old_ex, old_ey, ex, ey); 
                }
                old_ex = ex; old_ey = ey;
                x += 0.1;
            }

            // Вызываю метод для отрисовки
            axles.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Меняю цвет фона при нажатии
            pictureBox1.BackColor = Color.FromName("LightCyan");
            pictureBox1.Refresh();

            // Создаю кисть для рисования контура и координатных осей
            Pen penForCountur = new Pen(Color.Tomato, 1);
            // Объявил объект axles класса Graphics, ередал ему права для рисования в PB1
            Graphics axles = pictureBox1.CreateGraphics();
            // Рисуем прямоугольник:
            axles.DrawRectangle(penForCountur, 0, 0, pictureBox1.Size.Width - 1, pictureBox1.Size.Height - 1);
            // рисуем ось X и Y
            axles.DrawLine(penForCountur, 0, (pictureBox1.Size.Height / 2) - 1, pictureBox1.Size.Width - 1, (pictureBox1.Size.Height / 2) - 1);
            axles.DrawLine(penForCountur, (pictureBox1.Size.Width / 2) - 1, 0, (pictureBox1.Size.Width / 2) - 1, pictureBox1.Size.Height - 1);

            // Объявил объект parabola класса Graphics, ередал ему права для рисования в PB1
            Graphics parabola = pictureBox1.CreateGraphics();
            // Поменял единицы измерения на Миллиметры
            parabola.PageUnit = GraphicsUnit.Millimeter;
            // Кисть для рисование графика
            Pen penForParabola = new Pen(Color.FromArgb(0, 0, 0), 0.1f);            
            // Рисуем график функции y=3x^2+1
            int ex = 0, ey = 0, old_ex = 0, old_ey = 0;
            double x = 0, y = 0;
            int WidthInMM = Convert.ToInt16((pictureBox1.Size.Width - 1) / parabola.DpiX * 25.4);
            int HeightInMM = Convert.ToInt16((pictureBox1.Size.Height - 1) / parabola.DpiY * 25.4);
            x = - 12;
            for (ex = 0; ex <= WidthInMM; ex++)
            {
                y = (3 * x * x) + 1;
                ey = HeightInMM - (Convert.ToInt16(y * Convert.ToSingle(200 / parabola.DpiX)) + Convert.ToInt16(250 / parabola.DpiX) + 55);
                if (ex != 0) 
                { 
                    parabola.DrawLine(penForParabola, old_ex, old_ey, ex, ey); 
                }
                old_ex = ex; old_ey = ey;
                x += 0.1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Меняю цвет фона при нажатии
            pictureBox1.BackColor = Color.FromName("LightCyan");
            pictureBox1.Refresh();

            // Создаю кисть для рисования контура и координатных осей
            Pen penForCountur = new Pen(Color.Tomato, 1);
            // Объявил объект axles класса Graphics, ередал ему права для рисования в PB1
            Graphics axles = pictureBox1.CreateGraphics();
            // Рисуем прямоугольник:
            axles.DrawRectangle(penForCountur, 0, 0, pictureBox1.Size.Width - 1, pictureBox1.Size.Height - 1);
            // рисуем ось X и Y
            axles.DrawLine(penForCountur, 0, (pictureBox1.Size.Height / 2) - 1, pictureBox1.Size.Width - 1, (pictureBox1.Size.Height / 2) - 1);
            axles.DrawLine(penForCountur, (pictureBox1.Size.Width / 2) - 1, 0, (pictureBox1.Size.Width / 2) - 1, pictureBox1.Size.Height - 1);
                        
            // Объявил объект parabola класса Graphics, ередал ему права для рисования в PB1
            Graphics parabola = pictureBox1.CreateGraphics();
            // Поменял единицы измерения на Дюймы
            parabola.PageUnit = GraphicsUnit.Inch;
            // Кисть для рисование графика
            Pen penForParabola = new Pen(Color.FromArgb(0, 0, 0), 0.01f);
            // Рисуем график функции y=3x^2+1
            float WidthInInches = (pictureBox1.Size.Width - 1) / parabola.DpiX;
            float HeightInInches = (pictureBox1.Size.Height - 1) / parabola.DpiY;
            float ex = 0, old_ex = 0, ey = 0, old_ey = 0;
            float x = 0, y = 0;
            float shag = 0;
            x = - 10;
            shag = Convert.ToSingle(WidthInInches / 200);
            while (ex <= WidthInInches + shag)
            {
                y = (3 * x * x) + 1;
                ey = Convert.ToSingle(-y) + (HeightInInches / 2 + 1);
                if (ex != 0) 
                { 
                    parabola.DrawLine(penForParabola, old_ex, old_ey, ex, ey); 
                }
                old_ex = ex; old_ey = ey;
                ex = ex + shag;
                x += Convert.ToSingle(0.1);
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Graphics clear = pictureBox1.CreateGraphics();
            clear.Clear(Color.FromArgb(220, 220, 220));
        }
                
    }
}
