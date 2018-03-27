using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studia_dn
{
    class Bike : Tool, IAccelerate
    {
        public int accelarate = 0;

        public Bike(string name) : base(name)
        {
        }

        public void ChangeAccelarate(int accelarate)
        {
            this.accelarate = accelarate;
        }

        public override string ToString()
        {
            return "Bike [Accelarate: " + accelarate + "]";
        }
    }
}
