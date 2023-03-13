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
                    CheckWalls(c);
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
        public void CheckWalls(Circle c)
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
                    if (rast <= 2*r)
                    {
                        circles[i].dx = 0;
                        circles[i].dy = 0;
                        circles[j].dx = 0;
                        circles[j].dy = 0;
                    }
                }
            }
        }
    }
}
