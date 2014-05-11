using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminarska
{
    class Dupka
    {
        public Point Centar { get; set; }
        public Boolean postoi { get; set; }
        public int BrojDupka { get; set; }

        public Image img { get; set; }
        
        public Dupka(Point centar)
        {
            Centar = centar;
            postoi = true;
            Random r = new Random();
            BrojDupka = r.Next(2);
        }

        public void Move()
        {
            Centar = new Point(Centar.X, Centar.Y + 50);

        }

        public void Draw(Graphics g)
        {
            if (BrojDupka == 0)
            {
                img = Properties.Resources.crack1;
            }
            else if (BrojDupka == 1)
            {
                img = Properties.Resources.crack3;
            }
            



            g.DrawImage(img, Centar.X, Centar.Y - 100, 46, 40);
        }
    }
}
