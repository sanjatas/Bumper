using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminarska
{
    class CarsDoc
    {
        public List<Car> Cars { get; set; }

        public CarsDoc()
        {
            Cars = new List<Car>();
        }

        public void AddCar(Point centar)
        {
            Car c = new Car(centar);
            Cars.Add(c);
        }

        public void Move(int width)
        {
            foreach (Car c in Cars)
            {
                c.Move();
                if (c.Centar.Y == 1200)
                {
                   c.postoi = false;
                   // Cars.Remove(c);
                }
            }
           for (int i =0; i < Cars.Count; i++)
            {
               if (Cars[i].postoi == false)
                {
                    Cars.RemoveAt(i);
                }
            }
           
        }

        public void Draw(Graphics g)
        {
            foreach (Car c in Cars)
            {
                c.Draw(g);
            }
        }
    }
}
