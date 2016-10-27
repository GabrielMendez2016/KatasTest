using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbers
{
    public class RomanConverter
    {
        private enum ROMANS {M = 1000, D = 500, C = 100, L = 50, X = 10, V = 5, I = 1};
        private static string romanstring = "";
        private static String romanize(ROMANS digit) 
        {
            String realroman = "";
            int len = romanstring.Length;
            int modroman = len % 5;

            if (len <= 3) 
            {
                realroman = romanstring;
            }
            else
            if (len < 5) 
            {
                realroman = digit.ToString();
                realroman += Enum.GetName(typeof(ROMANS), (int) digit * 5);
            }
            else
            if (len == 5) 
            {
                realroman = Enum.GetName(typeof(ROMANS), (int) digit * 5);
            }
            else
            if (len < 9)
            {
                realroman = Enum.GetName(typeof(ROMANS), (int) digit * 5);
                for (int i = 0; i < modroman; i++)
                {
                    realroman += digit.ToString();
                }
            }
            else
            if (len == 9)
            {
                realroman = digit.ToString() + Enum.GetName(typeof(ROMANS), (int) digit * 10);
            }

            romanstring = "";
            return realroman;
        }
        public static String convertToRoman(int number) 
        {
            string romanresult = "";

            int thuosands = number /1000 % 10;
            int hundreds = number / 100 % 10;
            int dozens = number / 10 % 10;
            int units = number % 10;

            for (int i = 0; i < thuosands; i++) 
            {
                romanresult += Enum.GetName(typeof(ROMANS), 1000);
            }

            for (int i = 0; i < hundreds; i++)
            {
                romanstring += Enum.GetName(typeof(ROMANS), 100);
            }

            romanresult += romanize(ROMANS.C);

            for (int i = 0; i < dozens; i++)
            {
                romanstring += Enum.GetName(typeof(ROMANS), 10);
            }

            romanresult += romanize(ROMANS.X);

            for (int i = 0; i < units; i++)
            {
                romanstring += Enum.GetName(typeof(ROMANS), 1);
            }

            romanresult += romanize(ROMANS.I);
            
            return romanresult;

        }
        public static int convertToDigit(string roman)
        {
            int number = 0;
            char previousChar = roman[0];
            foreach (char currentChar in roman)
            {

                int currentnum = (int)Enum.Parse(typeof(ROMANS), currentChar.ToString());
                int previousnum = (int)Enum.Parse(typeof(ROMANS), previousChar.ToString());

                number += currentnum;
                if (previousnum < currentnum)
                {
                    number -= previousnum * 2;
                }

                previousChar = currentChar;
            }
            return number;
        }

    }
}
