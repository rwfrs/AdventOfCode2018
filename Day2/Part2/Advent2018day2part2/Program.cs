using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2018day2part2
{
    class Program
    {
        static void Main(string[] args)
        {


            string[] text = System.IO.File.ReadAllLines(@"C:\Users\rwfrs\Documents\Visual Studio 2015\Projects\Advent2018input\input2.txt");

            List<string> BoxIDList = new List<string>();

            string box1 = "";
            string box2 = "";
            int rightCharsCntr = 0;
            int bestBoxCntr = 0;
            string mostRight1 = "";
            string mostRight2 = "";
            string buildString = "";
            string theAnswerString = "";

            foreach (var line in text)
            {
                BoxIDList.Add(line);
            }

            BoxIDList.Sort();
            

            for (int i = 0; i < BoxIDList.Count-1; i++)
            {
                box1 = BoxIDList[i];
                box2 = BoxIDList[i + 1];

                for (int x = 0; x < box1.Length; x++)
                {
                    char char1 = box1[x];
                    char char2 = box2[x];

                    if (char1 == char2)
                    {
                        rightCharsCntr++;
                        buildString = buildString + char1;
                    }
                }
                
                if(rightCharsCntr > bestBoxCntr)
                {
                    bestBoxCntr = rightCharsCntr;
                    mostRight1 = box1;
                    mostRight2 = box2;
                    theAnswerString = buildString;
                }

                buildString = "";
                rightCharsCntr = 0;
            }

            Console.WriteLine("Box1 ID: " + mostRight1);
            Console.WriteLine("Box2 ID: " + mostRight2);
            Console.WriteLine("Answer:  " + theAnswerString);
            Console.ReadLine();
            
        }
    }
}
