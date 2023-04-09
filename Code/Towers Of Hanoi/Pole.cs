using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Towers_Of_Hanoi
{
    class Pole
    {
        public int x;
        public int y;
        public int width;
        public int height;
        int number;
        public Stack<Disk> disks = new Stack<Disk>();
        public bool selected = false;

        public Pole(int x, int y, int number)
        {
            this.x = x;
            this.y = y;
            this.width = 20;
            this.height = 399;
            this.number = number;
        }

        public void Show(Graphics g)
        {
            Pen brown = new Pen(Color.Brown, 4);
            SolidBrush brownFill = new SolidBrush(Color.LightSlateGray);

            g.FillRectangle(brownFill, x + 1, y + 1, width - 2, height - 2);
            g.DrawRectangle(brown, x, y, width, height);

        }

    }
}
