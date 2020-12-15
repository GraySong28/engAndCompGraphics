using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class Form1 : Form
    {
        // битовая картинка pictureBox
        Bitmap pictureBoxBitMap;
        // битовая картинка динамического изображения
        Bitmap spriteBitMap;
        // битовая картинка для временного хранения области экрана
        Bitmap cloneBitMap;
        // объект Graphics, на котором будет двигаться объект
        Graphics g_pictureBox;
        // объект Graphics для рисования динамического изображения
        Graphics g_sprite;
        int width = 500, height = 230; // Ширина и высота тарелки
        int x, y; // координаты динамического изображения
        public Form1()
        {
            InitializeComponent();
        }
        // Метод для рисования динамического изображения
        void DrawSprite()
        {
            g_sprite.DrawEllipse(new Pen(Color.Black, 4), 0, 15, 400, 130);
            g_sprite.FillEllipse(new SolidBrush(Color.Gray), 0, 15, 400, 130);
            g_sprite.DrawEllipse(new Pen(Color.Black, 4), 100, 0, 200, 75);
            g_sprite.FillEllipse(new SolidBrush(Color.DarkGray), 100, 0, 200, 75);
            g_sprite.FillEllipse(new SolidBrush(Color.Yellow), 30, 50, 30, 30);
            g_sprite.FillEllipse(new SolidBrush(Color.Yellow), 185, 100, 30, 30);
            g_sprite.FillEllipse(new SolidBrush(Color.Yellow), 340, 50, 30, 30);
        }
        // Метод для сохранения части изображения экрана
        void SavePart(int xt, int yt)
        {
            Rectangle cloneRect = new Rectangle(xt, yt, width, height);
            System.Drawing.Imaging.PixelFormat format = pictureBoxBitMap.PixelFormat;
            // Клонируем изображение, заданное прямоугольной областью
            //cloneBitMap = pictureBoxBitMap.Clone(cloneRect, format);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Создаём Bitmap для pictureBox1 и графическую поверхность
            pictureBox1.Image = Image.FromFile(@"fon.jpg");
            pictureBoxBitMap = new Bitmap(pictureBox1.Image);
            g_pictureBox = Graphics.FromImage(pictureBox1.Image);
            // Создаём Bitmap для объекта и графическую поверхность
            spriteBitMap = new Bitmap(width, height);
            g_sprite = Graphics.FromImage(spriteBitMap);
            // Создаем изображение движущегося объекта
            DrawSprite();
            // Создаём Bitmap для временного хранения части изображения
            cloneBitMap = new Bitmap(width, height);
            // Начальные координаты вывода движущегося объекта
            x = pictureBox1.Width / 2 - 125; y = 100;
            // Сохраняем область экрана перед первым выводом объекта
            SavePart(x, y);
            // Выводим объект
            g_pictureBox.DrawImage(spriteBitMap, x, y);
            // Перерисовываем pictureBox1
            pictureBox1.Invalidate();
            // Создаём таймер
            timer1 = new Timer();
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Восстанавливаем затёртую область статического изображения
            g_pictureBox.DrawImage(cloneBitMap, x, y);
            // Изменяем координаты для следующего вывода объекта
            y = y + 5;
            // Проверяем на выход изображения объекта за правую границу
            if (y > pictureBox1.Height - 175) y = pictureBox1.Location.Y + 100;
            // Сохраняем часть статического изображения перед выводом
            SavePart(x, y);
            // Выводим движущийся объект
            g_pictureBox.DrawImage(spriteBitMap, x, y);
            // Перерисовываем pictureBox1
            pictureBox1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
