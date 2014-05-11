using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminarska
{
    class Budala
    {
        public Point Centar { get; set; }
        public Image img { get; set; }

        public Budala(Point centar)
        {
            Centar = centar;
        }

        public void Draw(Graphics g)
        {
            img = Properties.Resources.kola4;
            g.DrawImage(img, Centar.X, Centar.Y, 70, 110);
        }

        public void Move(string strana)
        {

            if (strana == "levo")
            {
                if (Centar.X != 25)
                {
                    Centar = new Point(Centar.X - 110, Centar.Y); 
                }
            }
            else if (strana == "desno")
            {
                if (Centar.X != 245)
                {
                    Centar = new Point(Centar.X + 110, Centar.Y);
                }
            }
            else if (strana == "gore")
            {
                if (Centar.Y != 300)
                {
                    Centar = new Point(Centar.X, Centar.Y - 10);
                }
            }
            else
            {
                if (Centar.Y != 500)
                {
                    Centar = new Point(Centar.X, Centar.Y + 10);
                }
                
            }
        }
    }
}
