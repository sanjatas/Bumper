using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminarska
{
    class LentiDoc
    {
        public List<Lenta> Lenti { get; set; }

        public LentiDoc()
        {
            Lenti = new List<Lenta>();
        }

        public void AddLenta(Point centar)
        {
            Lenta c = new Lenta(centar);
            Lenti.Add(c);
        }

        public void Move(int width)
        {
            foreach (Lenta c in Lenti)
            {
                c.Move();
                if (c.Centar.Y == 1200)
                {
                   c.postoi = false;
                    // Lenti.Remove(c);
                }
            }
            for (int i = 0; i < Lenti.Count; i++)
            {
                if (Lenti[i].postoi == false)
                {
                    Lenti.RemoveAt(i);
                }
            }
           
        }

        public void Draw(Graphics g)
        {
            
            foreach (Lenta c in Lenti)
            {
                c.Draw(g);
            }
        }
    }
}
