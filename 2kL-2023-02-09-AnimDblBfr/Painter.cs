using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2kL_2023_02_09_AnimDblBfr
{
    public class Painter
    {
        private List<Animator> animators = new();
        private Size containerSize;
        private Thread t;
        private Graphics mainGraphics;
        private BufferedGraphics bg;

        public Graphics MainGraphics
        {
            get => mainGraphics;
            set
            {
                mainGraphics = value;
                ContainerSize = mainGraphics.VisibleClipBounds.Size.ToSize();
                bg = BufferedGraphicsManager.Current.Allocate(
                    mainGraphics, new Rectangle(new Point(0, 0), ContainerSize)
                );
            }
        }

        public Size ContainerSize
        {
            get => containerSize;
            set
            {
                containerSize = value;
            }
        }

        public Painter(Graphics mainGraphics)
        {
            MainGraphics = mainGraphics;
        }

        public void AddNew()
        {
            var a = new Animator(ContainerSize);
            animators.Add(a);
            a.Start();
        }

        public void Start()
        {
            t = new Thread(() =>
            {
                bg.Graphics.Clear(Color.White);
                foreach (var animator in animators)
                {
                    animator.PaintCircle(bg.Graphics);
                }
                bg.Render(MainGraphics);
                Thread.Sleep(30);
            });
            t.IsBackground = true;
            t.Start();
        }
    }
}
