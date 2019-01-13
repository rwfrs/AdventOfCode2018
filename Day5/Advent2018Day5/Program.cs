using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Test exec time
using System.Diagnostics;

namespace Advent2018Day5
{
    class Program
    {
        static void Main(string[] args)
        {

           string polymerInput = System.IO.File.ReadAllText(@"C:\Users\rwfrs\Documents\Projects\Advent2018input\input5.txt");
           polymerInput = polymerInput.Substring(0, polymerInput.Length - 1);


            bool firstLower = false;
            bool firstUpper = false;

            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            int topPoly = polymerInput.Length;
            int position = 0;
            char rightChar = ' ';

            foreach (var alphaChar in alpha)
            {
                int cntr = 0;
                int polyCntr = 0;

                foreach (var character in polymerInput)
                {
                    if(character == alpha[position] || character.ToString() == alpha[position].ToString().ToLower())
                    {
                        polymerInput = polymerInput.Remove(cntr, 1);
                        cntr--;
                    }
                    cntr++;
                }

                for (int i = 0; i < polymerInput.Length-1; i++)
                {
                    string firstChar = polymerInput[i].ToString();
                    string firstCharLower = firstChar.ToLower();
                    string firstCharUpper = firstChar.ToUpper();
                    string nextChar = polymerInput[i + 1].ToString();

                    if (firstChar == firstCharLower)
                    {
                        firstLower = true;
                    }
                    else if(firstChar == firstCharUpper)
                    {
                        firstUpper = true;
                    }

                    if (firstLower == true && nextChar == firstCharUpper || firstUpper == true && nextChar == firstCharLower)
                    {
                        polymerInput = polymerInput.Remove(i, 2);
                        i =-1;
                    }

                    firstLower = false;
                    firstUpper = false;
                }

                foreach (var item2 in polymerInput)
                {
                    polyCntr++;                
                }

                if (polyCntr < topPoly)
                {
                    topPoly = polyCntr;
                    rightChar = alpha[position];
                }

                position++;
                polymerInput = System.IO.File.ReadAllText(@"C:\Users\rwfrs\Documents\Projects\Advent2018input\input5.txt").Substring(0,polymerInput.Length -1);
                polymerInput = polymerInput.Substring(0, polymerInput.Length - 1);
            }

            Console.WriteLine(topPoly);
            Console.WriteLine(rightChar);             
            Console.ReadLine();

        }
    }
}
