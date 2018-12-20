using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2018day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] frequencys = System.IO.File.ReadAllLines(@"C:\Users\rwfrs\Documents\Projects\Advent2018input\input1.txt");

            int currentFrequency = 0;
            bool partTwo= false;
            bool partOne = true;
            List<int> frequencyList = new List<int>();
            frequencyList.Add(0);

            while(partTwo == false)
            { 
                foreach (string inputFrequency in frequencys)
                {
                    int frequency = Convert.ToInt32(inputFrequency);
                    currentFrequency += frequency;

                    foreach (var number in frequencyList)
                    {
                        if (number == currentFrequency && partTwo == false)
                        {
                            Console.WriteLine("--- Part Two --- puzzle answer is: " + currentFrequency);
                            Console.ReadLine();
                            partTwo = true;
                        }

                    }
                    frequencyList.Add(currentFrequency);
                }

                if (partOne == true)
                {
                    Console.WriteLine("--- Part One --- puzzle answer is: " + currentFrequency);
                    Console.ReadLine();
                    Console.WriteLine("Looping frequencys...");
                    partOne = false;
                }
                
            }



        }

    }
}
