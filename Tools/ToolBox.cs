using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studia_dn
{
    class ToolBox
    {

        private decimal _worthLimit = 1000;
        private decimal _currentWorth = 0;

        public delegate void ShowMessage();
        public event ShowMessage ToolBoxSizeIncreasedEvent;
        public event ShowMessage ToolBoxWorthReachedLimitEvent;

        public void ToolsSizeIncreasedHandler()
        {
            Console.WriteLine("Tools size has been increased!\n");
        }

        public void ToolBoxWorthReachedLimitHandler()
        {
            Console.WriteLine("The toolbox has reached worth " + _worthLimit + " limit!");
        }

        public void InitEvent()
        {
            ToolBoxSizeIncreasedEvent += ToolsSizeIncreasedHandler;
            ToolBoxWorthReachedLimitEvent += ToolBoxWorthReachedLimitHandler;
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
            ToolBoxSizeIncreasedEvent();
            _currentWorth += tool.CurrentWorth.Price;
            if(_currentWorth > _worthLimit)
            {
                ToolBoxWorthReachedLimitEvent();
            }
            tools.Add(tool);
        }

        public void DeleteTool(Tool tool)
        {
            tools.Remove(tool);
        }

        public void Clear()
        {
            tools.Clear();
        }
    }
}
