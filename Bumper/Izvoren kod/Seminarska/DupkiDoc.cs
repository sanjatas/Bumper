using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminarska
{
    class DupkiDoc
    {
        public List<Dupka> Dupki { get; set; }

        public DupkiDoc()
        {
            Dupki = new List<Dupka>();
        }

        public void AddDupka(Point centar)
        {
            Dupka c = new Dupka(centar);
            Dupki.Add(c);
        }

        public void Move(int width)
        {
            foreach (Dupka c in Dupki)
            {
                c.Move();
                if (c.Centar.Y == 1200)
                {
                   c.postoi = false;
                    // Lenti.Remove(c);
                }
            }
            for (int i = 0; i < Dupki.Count; i++)
            {
                if (Dupki[i].postoi == false)
                {
                    Dupki.RemoveAt(i);
                }
            }
           
        }

        public void Draw(Graphics g)
        {

            foreach (Dupka c in Dupki)
            {
                c.Draw(g);
            }
        }
    }
}
