using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2018day2
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] text = System.IO.File.ReadAllLines(@"C:\Users\rwfrs\Documents\Visual Studio 2015\Projects\Advent2018input\input2.txt");

            List<char> charList = new List<char>();
            List<int> charAmountList = new List<int>();

            int charCntr = 1;
            int twoCntr = 0;
            int threeCntr = 0;
            int checksum = 0;
        
            bool two = false;
            bool three = false;
            bool moreThanOne = false;

                foreach (var line in text)
                {
                    foreach (var chars in line)
                    {
                        charList.Add(chars);        
                    }

                charList.Sort();

                    for (int i = 0; i < charList.Count-1; i++)
                    {

                        if(charList[i] == charList[i+1])
                        {
                            moreThanOne = true;
                            charCntr++;
                        }

                        if (charList[i] != charList[i+1] && moreThanOne == true || charList[i] == charList[i + 1] && i == charList.Count - 2)
                        {
                            charAmountList.Add(charCntr);
                            moreThanOne = false;
                            charCntr = 1; // reset
                        }

                    }

                    foreach (var item in charAmountList)
                    {
                        if(item == 2)
                        {
                            two = true;
                        }

                        if(item == 3)
                        {
                            three = true;
                        }

                    }

                    if (three)
                    {
                        threeCntr++;
                    }

                    if(two)
                    {
                        twoCntr++;
                    }
                    
                charCntr = 1;
                charList.Clear();
                charAmountList.Clear();
                three = false;
                two = false;  
                                        
            }
           
            checksum = twoCntr * threeCntr;
            Console.WriteLine("Checksum: " + checksum);
            Console.ReadLine();
        }
    }
}
