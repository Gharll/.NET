using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studia_dn
{
    class ToolBox
    {

        const int PREFERED_SIZE = 2;
        public delegate void LimitExceeded(int currentSize);
        public delegate void ShowMessage();

        public event LimitExceeded DetectedLimitOfToolsExceeded;
        public event ShowMessage ToolsSizeIncreased;

        public void LimitOfToolsExceededHandler(int currentSize)
        {
            Console.WriteLine("Limit Of Tools Exceeded!");
            Console.WriteLine("Current size is " + currentSize + " of prefered size " + PREFERED_SIZE + "\n");
        }

        public void ToolsSizeIncreasedHandler()
        {
            Console.WriteLine("Tools size has been increased!\n");
        }

        public void InitEvent()
        {
            DetectedLimitOfToolsExceeded += LimitOfToolsExceededHandler;
            ToolsSizeIncreased += ToolsSizeIncreasedHandler;
        }

        public ToolBox()
        {
            InitEvent();
        }

        public List<Tool> tools = new List<Tool>();

        public List<Tool> GetAccelarateTools()
        {
            List<Tool> accelarateTools = new List<Tool>();
            foreach (var tool in tools)
            {
                if (tool is IAccelerate)
                {
                    accelarateTools.Add(tool);
                }
            }
            return accelarateTools;
        }

        public List<Tool> GetDiveTools()
        {
            List<Tool> diveTools = new List<Tool>();
            foreach (var tool in tools)
            {
                if (tool is IDive)
                {
                    diveTools.Add(tool);
                }
            }
            return diveTools;
        }

        public List<Tool> GetRiseTools()
        {
            List<Tool> riseTools = new List<Tool>();
            foreach (var tool in tools)
            {
                if (tool is IRise)
                {
                    riseTools.Add(tool);
                }
            }
            return riseTools;
        }

        public void ChangeRise(int value)
        {
            foreach (IRise tool in GetRiseTools())
            {
                tool.ChangeRise(value);
            }
        }

        public void ChangeDive(int value)
        {
            foreach (IDive tool in GetDiveTools())
            {
                tool.ChangeDive(value);
            }
        }

        public void ChangeAccelarate(int value)
        {
            foreach (IAccelerate tool in GetAccelarateTools())
            {
                tool.ChangeAccelarate(value);
            }
        }

        public void AddTool(Tool tool)
        {
            ToolsSizeIncreased();

            int size = tools.Count;
            if (size > PREFERED_SIZE)
            {
                DetectedLimitOfToolsExceeded(size);
            }
            tools.Add(tool);
        }

        public Bike CreateBike(String name)
        {
            Bike bike = new Bike(name);
            AddTool(bike);
            return bike;
        }

        public Airplane CreateAirplane(String name)
        {
            Airplane airplane = new Airplane(name);
            AddTool(airplane);
            return airplane;
        }

        public Submarine CreateSubmarine(String name)
        {
            Submarine submarine = new Submarine(name);
            AddTool(submarine);
            return submarine;
        }
    }
}
