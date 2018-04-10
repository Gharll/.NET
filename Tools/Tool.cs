using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studia_dn
{

    abstract class Tool
    {

        private Worth _currentWorth;
        private Worth _baseWorth;
        public String Name { get; set; }


        public void InitEvent()
        {
            ToolWorthIncreasedEvent += ToolWorthIncreasedHandler;
        }

        public delegate void ToolWorthIncreased(decimal previousWorth, decimal currentWorth);
        public event ToolWorthIncreased ToolWorthIncreasedEvent;

        public void ToolWorthIncreasedHandler(decimal previousWorth, decimal currentWorth)
        {
            Console.WriteLine("Tools worth has been increased!");
            Console.WriteLine("The previous worth: " + previousWorth);
            Console.WriteLine("The current worth: " + currentWorth);
        }



        public Worth CurrentWorth
        {
            get { return _currentWorth; }
        }

        public Worth BaseWorth
        {
            get { return _baseWorth; }
            set
            {
                _baseWorth = value;
                CalculateCurrentWorth();
            }
        }

        public decimal Age { get; set; }

        public Tool(String name)
        {
            Name = name;
            Age = 0;
            BaseWorth = new Worth(0, 0);
            InitEvent();
        }

        public Tool(String name, decimal age, Worth baseWorth)
        {
            Name = name;
            Age = age;
            BaseWorth = baseWorth;
            InitEvent();
        }

        private void CalculateCurrentWorth()
        {

            if (Age != 0)
            {
                decimal tmp = _currentWorth.Price;
                _currentWorth.Price = _baseWorth.Price * _baseWorth.SentimentalValue * Age/2;

                if(_currentWorth.Price > tmp && tmp != 0)
                {
                    ToolWorthIncreasedEvent(tmp, _currentWorth.Price);
                }
                _currentWorth.SentimentalValue = _baseWorth.SentimentalValue;
            } else
            {
                _currentWorth = BaseWorth;
            }
            
        }

        public void Birthday()
        {
            Age += 1;
            CalculateCurrentWorth();
        }

    }


}
