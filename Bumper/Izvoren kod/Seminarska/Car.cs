using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace Seminarska
{
    class Car
    {
        public Point Centar { get; set; }
        public int BrojKola { get; set; }
        public Boolean postoi { get; set; }
        public Image img { get; set; }
        public Car(Point centar)
        {
            Centar = centar;
            Random r = new Random();
            BrojKola = r.Next(6);
            postoi = true;
        }

        public void Move()
        {
            Centar = new Point(Centar.X, Centar.Y + 20);
        }

        public void Draw(Graphics g)
        {
            if (BrojKola == 0)
            {
                img = Properties.Resources.kola1;
            }
            else if(BrojKola == 1)
            {
                img = Properties.Resources.Kola2;
            }
            else if (BrojKola == 2)
            {
                img = Properties.Resources.kola3;
            }
            else if (BrojKola == 3)
            {
                img = Properties.Resources.Untitled_3;
            }
            else if (BrojKola == 4)
            {
                img = Properties.Resources.Untitled_1;
            }
            else if(BrojKola == 5)
            {
                img = Properties.Resources.Untitled_2;
            }
            else
            {
                img = Properties.Resources.kola5;
            }

            g.DrawImage(img, Centar.X, Centar.Y - 100, 70, 110);
            
        }
    }
}
