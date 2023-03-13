using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2kL_2023_02_09_AnimDblBfr
{
    public class Circle
    {
        private Random r = new();
        private double diam;
        private double x, y;

        public double X
        {
            get => x; set => x = value;
        }
        public double Y
        {
            get => y; set => y = value;
        }
        public double Diam => diam;
        public Color Color { get; set; }
        public double dx, dy;

        public Circle(double diam, int x, int y, Color color)
        {
            this.diam = diam;
            this.x = x;
            this.y = y;
            this.Color = color;
        }

        public Circle(double diam, int x, int y)
        {
            this.diam = diam;
            this.x = x;
            this.y = y;
            this.dx = RandomDir();
            this.dy = RandomDir();
            this.Color = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
        }

        public void Move()
        {
            x += dx;
            y += dy;
        }

        public void Paint(Graphics g)
        {
            var brush = new SolidBrush(Color);
            g.FillEllipse(brush, (int)x, (int)y, (int)Diam, (int)Diam);
        }
        private int RandomDir()
        {
            int a = r.Next(-5, 5);
            while (a == 0)
            {
                a = r.Next(-5, 5);
            }
            return a;
        }
    }
}
