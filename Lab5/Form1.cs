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

namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Создание надписи и её вывод
            this.Show();
            Graphics g = this.CreateGraphics();
            g.DrawString("Для активации кликните по белому прямоугольнику", new Font("Roboto", 10, FontStyle.Bold), Brushes.White, 12, 6);
            g.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Обновление формы после нажатия по ПБ
            this.Refresh();
            Graphics g = pictureBox1.CreateGraphics();
            // Создания массива точек для создания пятиугольника
            Point[] point = new Point[5]    {new Point(640, 10),
                                             new Point(840, 50),
                                             new Point(780, 90),
                                             new Point(500, 90),
                                             new Point(440, 50)};
            // Рисую пятиугольник
            g.DrawPolygon(new Pen(Color.Gray, 2), point);

            // Создаю шрифт, задаю его свойства и вывожу внутри пятиугольника
            Font fn = new Font("Roboto", 10, FontStyle.Bold);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            string s = "Средняя температура воздуха в г. Донецке за шесть месяцев";
            g.DrawString(s, fn, Brushes.Gray, new Rectangle(440, 25, 400, 75), sf);

            // Создаю обводку вокруг ПБ
            g.DrawRectangle(new Pen(Color.DarkGray, 8), 0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);

            // Вывод осей X и Y
            int nachalo_x = 40; int konec_x = pictureBox1.Width - 40;
            int nachalo_y = 140; int konec_y = pictureBox1.Height - 40;
            g.DrawLine(new Pen(Color.Black, 2), nachalo_x, konec_y, konec_x, konec_y);
            g.DrawLine(new Pen(Color.Black, 2), nachalo_x, nachalo_y, nachalo_x, konec_y);

            // Массивы для хранение мясяцев и значений темперауры для них
            string[] month = new string[6] { "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь" };
            double[] temperature = new double[6] { 12.5, 23.0, 23.8, 24.6, 28.6, 19.8 };

            // Нахожу максимальное значение температуры для коретного вывода диаграммы
            double max = -1;
            double mash = 5.0;
            for (int i = 0; i < temperature.Length; i++) { if (temperature[i] > max) max = temperature[i]; }
            // Нахожу количество точек на единицу температуры
            double dy = (konec_y - nachalo_y) / (max / mash);
            // Ширина прямоугольника диаграммы
            int widthRect = ((konec_x - nachalo_x) / temperature.Length) / 2;
            // Создаю свои кисти для закрашивания диаграммы
            SolidBrush sb = new SolidBrush(Color.Gray);
            HatchBrush hb = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Black, Color.Gray);
            Image img = Image.FromFile("texture.bmp");
            TextureBrush tb = new TextureBrush(img);

            // Вывод элементов диаграммы
            int x = nachalo_x + widthRect;
            for (int i = 0; i < temperature.Length; i++)
            {
                // Задаю прямоугольную область элемента диаграммы
                Rectangle rect = new Rectangle(x, konec_y - (int)(dy * (temperature[i] / mash)), widthRect, (int)(dy * (temperature[i] / mash)));
                // Вывожу столбцы диаграммы
                if (i < 2) g.FillRectangle(sb, rect);
                if ((i >= 2) && (i < 4)) g.FillRectangle(hb, rect);
                if ((i >= 4) && (i < 6)) g.FillRectangle(tb, rect);
                // Вывожу рамку вокруг столбцов диаграммы
                g.DrawRectangle(new Pen(Color.Black, 1), rect);
                // Переход к следущему элементу
                x += 2 * widthRect;
            }

            // Вывод штрихованой линии и обозначений перпиндикулярно оси y
            Pen p = new Pen(Color.Black, 2);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            fn = new Font("Roboto", 8, FontStyle.Bold);
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            for (int i = 0; i < temperature.Length; i++)
            {
                // Рисую штрих линии
                g.DrawLine(p, nachalo_x - 5, konec_y - (int)(dy * (temperature[i] / mash)), konec_x, konec_y - (int)(dy * (temperature[i] / mash)));
                // Вывожу значение температуры
                g.DrawString(temperature[i].ToString(), fn, Brushes.Black, new Rectangle(1, konec_y - (int)(dy * (temperature[i] / mash)) - (int)fn.Size, 30, 20), sf);
            }

            // Вывод разметки и названий месяцев на ось x
            sf.Alignment = StringAlignment.Center;
            x = nachalo_x + widthRect + widthRect / 2;
            for (int i = 0; i < month.Length; i++)
            {
                // Рисую черточки по оси X
                g.DrawLine(new Pen(Color.Black, 1), x, konec_y - 5, x, konec_y + 5);
                // Вывожу месяци
                g.DrawString(month[i], fn, Brushes.Black, new Rectangle(x - 25, konec_y, 55, 22), sf);
                x += 2 * widthRect;
            }
        }
    }
}
