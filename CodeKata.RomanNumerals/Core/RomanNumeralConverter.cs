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

            return $"{new String(GetNumeral(1000)[0], thousands)}{HundredsConverter(hundreds)}{TensConverter(tens)}{OnesConverter(ones)}";
        }

        private string GetNumeral(int digit)
        {
            if (numerals.ContainsValue(digit))
                return numerals.Where(x => x.Value == digit).Select(x => x.Key).FirstOrDefault().ToString();
            else
                return string.Empty;
        }

        private string HundredsConverter(int hundreds)
        {
            char numeral100 = GetNumeral(100)[0];
            char numeral500 = GetNumeral(500)[0];
            char numeral1000 = GetNumeral(1000)[0];

            switch (hundreds)
            {
                case 1:
                case 2:
                case 3:
                    return new String(numeral100, hundreds);
                case 4:
                    return $"{numeral100}{numeral500}";
                case 5:
                    return $"{numeral500}";
                case 6:
                case 7:
                case 8:
                    return $"{numeral500}{new String(numeral100, hundreds - 5)}";
                case 9:
                    return $"{numeral100}{numeral1000}";
            }

            return String.Empty;
        }

        private string TensConverter(int tens)
        {
            char numeral10 = GetNumeral(10)[0];
            char numeral50 = GetNumeral(50)[0];
            char numeral100 = GetNumeral(100)[0];

            switch (tens)
            {
                case 1:
                case 2:
                case 3:
                    return new String(numeral10, tens);
                case 4:
                    return $"{numeral10}{numeral50}";
                case 5:
                    return $"{numeral50}";
                case 6:
                case 7:
                case 8:
                    return $"{numeral50}{new String(numeral10, tens - 5)}";
                case 9:
                    return $"{numeral10}{numeral100}";
            }

            return String.Empty;
        }

        private string OnesConverter(int tens)
        {
            char numeral1 = GetNumeral(1)[0];
            char numeral5 = GetNumeral(5)[0];
            char numeral10 = GetNumeral(10)[0];

            switch (tens)
            {
                case 1:
                case 2:
                case 3:
                    return new String(numeral1, tens);
                case 4:
                    return $"{numeral1}{numeral5}";
                case 5:
                    return $"{numeral5}";
                case 6:
                case 7:
                case 8:
                    return $"{numeral5}{new String(numeral10, tens - 5)}";
                case 9:
                    return $"{numeral1}{numeral10}";
            }

            return String.Empty;
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
