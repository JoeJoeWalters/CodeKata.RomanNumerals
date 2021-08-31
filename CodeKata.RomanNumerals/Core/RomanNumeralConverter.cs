using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class RomanNumeralConverter
    {
        private Dictionary<string, int> numerals = new Dictionary<string, int>()
        { 
            { "I", 1 },
            { "V", 5 },
            { "X", 10 },
            { "L", 50 },
            { "C", 100 },
            { "D", 500 },
            { "M", 1000 }
        };

        public RomanNumeralConverter()
        {
        }

        public string FromDigit(int digit)
        {
            if (numerals.ContainsValue(digit))
                return numerals.Where(x => x.Value == digit).Select(x => x.Key).FirstOrDefault();
            else
                return string.Empty;
        }

        public int FromNumeral(string numeral)
        {
            if (numerals.ContainsKey(numeral))
                return numerals[numeral];
            else
                return 0;
        }
    }
}
