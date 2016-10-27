using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataBowlingUnitTest
{
    class Game
    {

        private List<int> rollslist = new List<int>();

        public Game() 
        {
            for (int i = 0; i < 21; i++)
                rollslist.Add(0);
        }
        public void Run(String test) 
        {
            Char[] rollchars = test.ToCharArray();
            int len = rollchars.Length;

            for (int i = 0; i < len; i++) 
            {
                Char c = rollchars[i];
                switch (c) 
                {
                    case 'X':
                        rollslist[i] = 10;
                        break;
                    case '/':
                        rollslist[i] = 10 - rollslist[i - 1];
                        break;
                    case '-':
                        break;
                    default:
                        rollslist[i] = (int)Char.GetNumericValue(c);
                        break;
                }
            }

            int totalrolls = rollslist.Count();

        }

        internal object GetScore()
        {
            int score = 0;
            int index = 0;
            for (int i = 0; i < 10; i++) 
            {
                if (rollslist.ElementAt(index) == 10) //strike
                {
                    score += 10 + rollslist.ElementAt(index + 1) + rollslist.ElementAt(index + 2);
                    index++;
                }
                else
                if (rollslist.ElementAt(index) + rollslist.ElementAt(index + 1) == 10) //spare
                {
                    score += 10 + rollslist.ElementAt(index + 2);
                    index += 2;
                }
                else //miss
                {
                    score += rollslist.ElementAt(index) + rollslist.ElementAt(index + 1);
                    index += 2;
                }
            }
            
            return score;
        }
    }
}
