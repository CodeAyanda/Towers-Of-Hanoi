using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Towers_Of_Hanoi
{
    public partial class Form1 : Form
    {
        Platform plat;
        public static int numOfDisks = 3;  //Max 13
        List<Pole> mypoles = new List<Pole>();
        List<Color> colours = new List<Color> { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Aqua, Color.Gold, Color.Brown, Color.CornflowerBlue, Color.DarkKhaki, Color.BlanchedAlmond, Color.DeepPink, Color.ForestGreen, Color.Lime };
        Disk selectedDisk = null;
        bool pickup = false;
        bool invalid = false;
        int movesCounter = 0;
        bool gameOver = false;
        
        public Form1()
        {
            InitializeComponent();

            plat = new Platform();
            for (int i = 300; i <= 1100; i += 400)
            {
                int number = 1;
                Pole pole = new Pole(i, 200, number);
                mypoles.Add(pole);
                number++;
            }
            for (int i = 0; i < numOfDisks; i++)
            {
                Random rnd = new Random();

                int r = rnd.Next(colours.Count);
                Color currentColor = colours[r];
                Disk disk = new Disk(mypoles[0], i + 1, currentColor);
                colours.RemoveAt(r);
                mypoles[0].disks.Push(disk);
            }
        }


        private void Draw(object sender, PaintEventArgs e)
        {
            var relativePoint = this.PointToClient(Cursor.Position);

            Graphics g = e.Graphics;
            plat.Show(g);
            foreach (var poles in mypoles)
            {
                poles.Show(g);
                foreach(var disk in poles.disks)
                {
                    disk.Show(g);
                }
            }

            //touch zones
            for (int i = 0; i < 3; i++)
            {
                //g.DrawRectangle(new Pen(Color.Black), mypoles[i].x - 100, 0, 5, 4000);
                //g.DrawRectangle(new Pen(Color.Black), mypoles[i].x + 100 + 20, 0, 5, 4000);

            }

            if (pickup)
            {
                g.DrawRectangle(new Pen(Color.Black, 5), relativePoint.X-(float)(selectedDisk.size/2), relativePoint.Y, (float)selectedDisk.size, selectedDisk.height); ;
                g.FillRectangle(new SolidBrush(selectedDisk.color), relativePoint.X+1- (float)(selectedDisk.size / 2), relativePoint.Y+1, (float)selectedDisk.size-2, selectedDisk.height-2);
            }


            if(invalid)
            {
                g.DrawRectangle(new Pen(Color.Red, 8), relativePoint.X - (float)(selectedDisk.size / 2), relativePoint.Y, (float)selectedDisk.size, selectedDisk.height); ;

            }

            if(mypoles[1].disks.Count == numOfDisks || mypoles[2].disks.Count == numOfDisks)
            {
                label1.Visible = true;
                gameOver = true;
            }

            label2.Text = "Moves : " + movesCounter.ToString();
            

        }

        

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!gameOver)
            {
                var relativePoint = this.PointToClient(Cursor.Position);
                for (int i = 0; i < 3; i++)
                {
                    if (selectedDisk == null && relativePoint.X > mypoles[i].x - 100 && relativePoint.X < mypoles[i].x + 120)
                    {
                        mypoles[i].selected = true;

                        /// FIND SOLUTION   
                        if (mypoles[i].disks.Count > 0)
                        {
                            selectedDisk = mypoles[i].disks.Pop();
                            mypoles[i].selected = false;
                            pickup = true;
                        }
                    }
                    else if (selectedDisk != null && relativePoint.X > mypoles[i].x - 100 && relativePoint.X < mypoles[i].x + 120)
                    {
                        double topSize;
                        if (mypoles[i].disks.Count != 0)
                        {
                            topSize = mypoles[i].disks.Peek().size;
                        }
                        else
                        {
                            topSize = 0;
                        }

                        if (selectedDisk.size < topSize || topSize == 0)
                        {
                            if (selectedDisk.currentPole == mypoles[i])
                            {
                                selectedDisk.currentPole = mypoles[i];
                                Disk newDisk = new Disk(mypoles[i], mypoles[i].disks.Count + 1, selectedDisk.color, selectedDisk.size);
                                mypoles[i].disks.Push(newDisk);
                                selectedDisk = null;
                                pickup = false;

                            }
                            else
                            {
                                selectedDisk.currentPole = mypoles[i];
                                Disk newDisk = new Disk(mypoles[i], mypoles[i].disks.Count + 1, selectedDisk.color, selectedDisk.size);
                                mypoles[i].disks.Push(newDisk);
                                selectedDisk = null;
                                pickup = false;
                                movesCounter++;

                            }

                        }
                        else
                        {
                            invalid = true;
                            Invalid();
                        }

                    }
                    else
                    {
                        mypoles[i].selected = false;

                    }

                }


            }

        }

        public async Task Invalid()
        {
            if (invalid)
            {
                await Task.Delay(800);
                invalid = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

    }
}
