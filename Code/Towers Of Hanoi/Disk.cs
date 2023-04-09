using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Towers_Of_Hanoi
{
    class Disk
    {
        int max = 450;
        public double size;
        public int height = 35;
        public Color color;
        public Pole currentPole;
        int poleCenter;
        public int numberInStack;

        public Disk(Pole pole, int stackNumber, Color color)
        {
            this.currentPole = pole;
            this.size = max - (max / Form1.numOfDisks) * (stackNumber*0.8);
            this.poleCenter = pole.x + (pole.width / 2);
            this.numberInStack = stackNumber;
            this.color = color;
        }

        public Disk(Pole pole, int stackNumber, Color color, double size)
        {

            this.currentPole = pole;
            this.size = size;
            this.poleCenter = pole.x + (pole.width / 2);
            this.numberInStack = stackNumber;
            this.color = color;
        }

        public void Show(Graphics g)
        {
            Pen black = new Pen(Color.Black, 4);
            g.FillRectangle(new SolidBrush(color), (poleCenter - (int)(size / 2))+1, (Platform.y - (height * numberInStack))+1, ((int)size)-2, (height)-2);

            if (currentPole.selected && numberInStack == currentPole.disks.Peek().numberInStack)
            {
                g.DrawRectangle(new Pen(Color.White, 5), poleCenter - (int)(size / 2), Platform.y - (height * numberInStack), (int)size, height);

            }
            else
            {
                g.DrawRectangle(black, poleCenter - (int)(size / 2), Platform.y - (height * numberInStack), (int)size, height);

            }


        }

    }
}
