using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studia_dn.Tools
{
    class ToolFactory
    {
        public Bike CreateBike(String name)
        {
            Bike bike = new Bike(name);
            return bike;
        }

        public Airplane CreateAirplane(String name)
        {
            Airplane airplane = new Airplane(name);
            return airplane;
        }

        public Submarine CreateSubmarine(String name)
        {
            Submarine submarine = new Submarine(name);
            return submarine;
        }

    }
}
