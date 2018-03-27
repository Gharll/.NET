using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studia_dn
{
    struct Worth
    {
        private decimal _price;
        private decimal _sentimentalValue;

        public Worth(decimal Price, decimal SentimentalValue)
        {
            _price = Price;
            _sentimentalValue = SentimentalValue;
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value >= 0)
                    _price = value;
                else
                    throw new Exception();
            }
        }

        public decimal SentimentalValue
        {
            get { return _sentimentalValue; }
            set
            {
                if (value >= 0)
                    _sentimentalValue = value;
                else
                    throw new Exception();
            }
        }

        public override string ToString()
        {
            return "Worth: [Price= "+ _price+ " SentimentalValue= " + _sentimentalValue + "]";
        }
    }
}
