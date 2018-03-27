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
        }

        public Tool(String name, decimal age, Worth baseWorth)
        {
            Name = name;
            Age = age;
            BaseWorth = baseWorth;
        }

        private void CalculateCurrentWorth()
        {
            if(Age != 0)
            {
                _currentWorth.Price = _baseWorth.Price / Age;
                _currentWorth.SentimentalValue = _baseWorth.SentimentalValue * Age * Age / 2;
            } else
            {
                _currentWorth = BaseWorth;
            }
            
        }

    }


}
