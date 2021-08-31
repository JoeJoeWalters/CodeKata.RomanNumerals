using System;
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
        {
            decimal decimalDigit = (decimal)digit; // Hack to allo division without compiler warning

            // How many of each major grouping?
            int thousands = (int)(Math.Floor(decimalDigit / 1000) % 10);
            int hundreds = (int)(Math.Floor(decimalDigit / 100) % 10);
            int tens = (int)(Math.Floor(decimalDigit / 10) % 10);
            int ones = digit % 10;

            return $"{new String(GetNumeral(1000)[0], thousands)}{new String(GetNumeral(100)[0], hundreds)}{new String(GetNumeral(10)[0], tens)}{new String(GetNumeral(1)[0], ones)}";
        }

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
