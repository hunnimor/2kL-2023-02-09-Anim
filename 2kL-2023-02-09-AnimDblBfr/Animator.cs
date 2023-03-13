using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace _2kL_2023_02_09_AnimDblBfr
{
    public class Animator
    {
        private Circle c;
        private Thread? t = null;
        public bool IsAlive => t == null || t.IsAlive;
        public Size ContainerSize { get; set; }
        //private Random r = new Random();
        private static List<Circle> circles = new();

        public Animator(Size containerSize)
        {
            Random rnd = new Random();
            ContainerSize = containerSize;
            c = new Circle(50, rnd.Next(75, ContainerSize.Width - 75), rnd.Next(75, ContainerSize.Height - 75));
            circles.Add(c);
        }
        public void Start()
        {
            t = new Thread(() =>
            {
                while (IsAlive)
                {
                    Thread.Sleep(30);
                    Walls(c);
                    Collision(circles);
                    c.Move();
                }

            });
            t.IsBackground = true;
            t.Start();
        }

        public void PaintCircle(Graphics g)
        {
            c.Paint(g);
        }
        private void Walls(Circle c)
        {
            if (c.X + c.Diam >= ContainerSize.Width || c.X <= 0)
            {
                c.dx = -c.dx;
            }
            if (c.Y + c.Diam >= ContainerSize.Height || c.Y <= 0)
            {
                c.dy = -c.dy;
            }

        }
        private void Collision(List<Circle> circles)
        {
            for (int i = 0; i < circles.Count; i++)
            {
                for (int j = i + 1; j < circles.Count; j++)
                {
                    var rastX = circles[i].X - circles[j].X;
                    var rastY = circles[i].Y - circles[j].Y;
                    var r = circles[i].Diam / 2;
                    var rast = Math.Sqrt(rastX*rastX + rastY*rastY);
                    if (rast == 0) rast = 0.01;
                    var s = rastX / rast; //sin
                    var e = rastY / rast; //cos
                    if (rast <= 2*r)
                    {
                        //переворачиваем систему координат
                        var Vn1 = circles[j].dx * s + circles[j].dy * e; // находим вектор В1
                        var Vn2 = circles[i].dx * s + circles[i].dy * e; // находим вектор В2
                        //слипание шариков
                        var dt = (r * 2 - rast) / (Vn1 - Vn2);
                        if (dt > 0.6) dt = 0.6;
                        if (dt < -0.6) dt = -0.6;
                        circles[i].X -= circles[i].dx * dt;
                        circles[i].Y -= circles[i].dy * dt;
                        circles[j].X -= circles[j].dx * dt;
                        circles[j].Y -= circles[j].dy * dt;

                        var Vt1 = -circles[j].dx * e + circles[j].dy * s;
                        var Vt2 = -circles[i].dx * e + circles[i].dy * s;
                        // меняем местами в1 и в2
                        var o = Vn2;
                        Vn2 = Vn1;
                        Vn1 = o;
                        //переворачиваем систему координат и меняем направление шариков
                        circles[i].dx = Vn2 * s - Vt2 * e;
                        circles[i].dy = Vn2*e + Vt2*s;
                        circles[j].dx = Vn1 * s - Vt1 * e;
                        circles[j].dy = Vn1 * e + Vt1 * s;
                    }
                }
            }
        }
    }
}
