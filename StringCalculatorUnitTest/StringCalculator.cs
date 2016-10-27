using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculatorUnitTest
{
    public class StringCalculator
    {
        private bool hasDelimiter(String inputstring, out String delimiter)
        {
            Match match = null;
            delimiter = null;
            if (inputstring.StartsWith("//"))
            {
                string patternstart = Regex.Escape("//");
                string patternend = Regex.Escape("\n");
                string regexexpr = patternstart + @"(.*?)" + patternend;
                match = Regex.Match(inputstring, regexexpr);
                delimiter = match.Value;
                inputstring = inputstring.Replace(delimiter, String.Empty);
            }

            return !String.IsNullOrEmpty(delimiter);
        }
        public int add(String inputstring) 
        {
            int result = 0;
            string[] numbers = null;
            string delimiter = null;
            if (inputstring.Trim().Length > 0)
            {
                if (hasDelimiter(inputstring, out delimiter)) 
                {
                    Console.Write(delimiter);
                    inputstring = inputstring.Replace(delimiter, String.Empty);
                    numbers = inputstring.Split(delimiter.Trim().ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                }
                else
                {
                    numbers = inputstring.Split(',', '\n');
                }

                foreach (String s in numbers)
                {
                    int currentnumber = Int32.Parse(s);
                    if (currentnumber < 0)
                    {
                        throw new Exception("Negative numbers are not allowed");
                    }
                    if (currentnumber > 1000) 
                    {
                        currentnumber = 0;
                    }

                    result += currentnumber;
                }
            }

            return result;
        }
    }
}
