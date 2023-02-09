using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2kL_2023_02_09_AnimDblBfr
{
    public class Animator
    {
        private Circle c;
        private Thread t;
        public Size ContainerSize { get; set; }

        public Animator(Size containerSize)
        {
            c = new Circle(50, 0, 0);
            ContainerSize = containerSize;
        }

        public void Start()
        {
            t = new Thread(() =>
            {
                while (c.X + c.Diam < ContainerSize.Width)
                {
                    Thread.Sleep(30);
                    c.Move(1, 0);
                }
            });
            t.IsBackground = true;
            t.Start();
        }

        public void PaintCircle(Graphics g)
        {
            c.Paint(g);
        }
    }
}
