using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminarska
{
    class Lenta
    {
        public Point Centar { get; set; }
        public Boolean postoi { get; set; }
        
        public Lenta(Point centar)
        {
            Centar = centar;
            postoi = true;
        }

        public void Move()
        {
            Centar = new Point(Centar.X, Centar.Y + 50);
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(Properties.Resources.lenta, Centar.X, Centar.Y - 100, 13, 78);
        }
    }
}
