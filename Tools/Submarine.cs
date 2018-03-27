using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studia_dn
{
    class Submarine : Tool, IDive, IRise
    {
        int dive;
        int rise;
        public Submarine(string name) : base(name)
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

        public override string ToString()
        {
            return "Submarine   [Rise:" + rise + " Dive:" + dive + "]";
        }
    }
}
