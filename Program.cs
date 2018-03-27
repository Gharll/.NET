using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studia_dn
{
    class Program
    {
        static void createTestTools(ToolBox tb)
        {
            var ma1 = tb.CreateAirplane("myAirplane1");
            ma1.Age = 2;
            ma1.BaseWorth = new Worth(5, 10);

            var ma2 = tb.CreateAirplane("myAirplane2");
            ma2.Age = 3;
            ma2.BaseWorth = new Worth(20, 10);

            var mb = tb.CreateBike("myBike");
            mb.Age = 6;
            mb.BaseWorth = new Worth(60, 30);

            var ms = tb.CreateSubmarine("mySubmarine");
            ms.Age = 10;
            ms.BaseWorth = new Worth(30, 20);

            tb.ChangeAccelarate(100);
        }

        static void printTools(ToolBox tb)
        {
            foreach (var tool in tb.GetRiseTools())
            {
                Console.WriteLine(tool.ToString());
            }
            Console.WriteLine("\n");

            foreach (var tool in tb.GetAccelarateTools())
            {
                Console.WriteLine(tool.ToString());
            }

            Console.WriteLine("\n");

            foreach (var tool in tb.GetDiveTools())
            {
                Console.WriteLine(tool.ToString());
            }

            Console.WriteLine("\n");
        }

        static void showToolsWorth(ToolBox tb)
        {
            foreach(var tool in tb.tools)
            {
                Console.WriteLine("Tool name: " + tool.Name);
                Console.WriteLine("Age: " + tool.Age);
                Console.WriteLine("Base worth: " + tool.BaseWorth);
                Console.WriteLine("Current worth: " + tool.CurrentWorth + "\n");
            }
        }

        static void Main(string[] args)
        {
            ToolBox tb = new ToolBox();
            createTestTools(tb);
            printTools(tb);
            showToolsWorth(tb);
            Console.ReadKey();
        }
    }
}
