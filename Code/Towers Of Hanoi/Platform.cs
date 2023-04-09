using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Towers_Of_Hanoi
{
    class Platform
    {
        public static int x;
        public static int y;
        int thick;
        public static int length;

        public Platform()
        {
            thick = 80;
            length = 1370;
            x = 30;
            y = 600;
        }

        public void Show(Graphics g)
        {
            

            Pen brown = new Pen(Color.Brown, 4);
            Pen black = new Pen(Color.Black, 2);

            SolidBrush brownFill = new SolidBrush(Color.LightSlateGray);
            g.DrawRectangle(brown, x, y, length, thick);
            g.FillRectangle(brownFill, x + 1, y + 1, length - 2, thick - 2);



        }


    }
}
