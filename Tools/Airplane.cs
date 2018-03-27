using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studia_dn
{
    class Airplane : Tool, IAccelerate, IRise, IDive
    {
        public int rise;
        public int dive;
        public int accelarate;

        public Airplane(string name) : base(name)
        {
        }

        public void ChangeDive(int dive)
        {
            this.dive = dive;
        }

        public void ChangeRise(int rise)
        {
            this.rise = rise;
        }

        public void ChangeAccelarate(int accelarate)
        {
            this.accelarate = accelarate;
        }

        public override string ToString()
        {
            return "Airplane  [Rise:" + rise + " Dive:" + dive + " Accelarate: " + accelarate + "]";

        }
    }
}
