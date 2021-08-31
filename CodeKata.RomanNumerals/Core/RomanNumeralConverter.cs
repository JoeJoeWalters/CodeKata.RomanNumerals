using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class RomanNumeralConverter
    {
        private Dictionary<char, int> numerals = new Dictionary<char, int>()
        { 
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        public RomanNumeralConverter()
        {
        }

        public string FromDigit(int digit)
            => GetNumeral(digit);

        private string GetNumeral(int digit)
        {
            if (numerals.ContainsValue(digit))
                return numerals.Where(x => x.Value == digit).Select(x => x.Key).FirstOrDefault().ToString();
            else
                return string.Empty;
        }

        public int FromNumerals(string numerals)
        {
            int rollingValue = 0;
            int lastValue = 0;
            for (int position = 0; position < numerals.Length; position ++)
            {
                int value = GetDigit(numerals[position]);
                rollingValue += value;
                lastValue = value;
            }

            return rollingValue;
        }

        private int GetDigit(char numeral)
        {
            if (numerals.ContainsKey(numeral))
                return numerals[numeral];
            else
                return 0;
        }
    }
}
