using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            Graphics g = e.Graphics;
            SolidBrush lodka = new SolidBrush(Color.Red);
            SolidBrush lodkaPolosa = new SolidBrush(Color.White);
            SolidBrush machta = new SolidBrush(Color.Gray);
            SolidBrush parus = new SolidBrush(Color.White);
            SolidBrush voda = new SolidBrush(Color.DarkBlue);
            SolidBrush nebo = new SolidBrush(Color.LightBlue);
            SolidBrush solnce = new SolidBrush(Color.Yellow);

            // Вода и небо
            g.FillRectangle(voda, 0, 300, 999, 499);
            g.FillRectangle(nebo, 0, 0, 999, 300);

            // Лодка
            g.FillPolygon(lodka, new Point[] {
            new Point(100, 400), new Point(650, 400),
            new Point(700, 350), new Point(750, 300),
            new Point(800, 250), new Point(850, 200),
            new Point(800, 200), new Point(720, 275),
            new Point(250, 275), new Point(250, 200),
            new Point(100, 200), new Point(100, 400)
            });
            // Полоса на лодке
            g.FillPolygon(lodkaPolosa, new Point[] {
            new Point(100, 375), new Point(675, 375),
            new Point(725, 325), new Point(100, 325),
            new Point(100, 375)
            });
            // Мачта
            g.FillPolygon(machta, new Point[] {
            new Point(425, 10), new Point(450, 10),
            new Point(450, 275), new Point(425, 275)
            });
            // Парус
            g.FillPolygon(parus, new Point[] {
            new Point(425, 10), new Point(425, 260),
            new Point(250, 120)
            });
            // Парус 2
            g.FillPolygon(parus, new Point[] {
            new Point(450, 10), new Point(550, 140),
            new Point(450, 255), new Point(750, 140)
            });
            // Солнце
            g.FillEllipse(solnce, 700, 10, 70, 70);
        }
    }
}
