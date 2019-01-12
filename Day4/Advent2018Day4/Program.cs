using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent2018Day4
{
    class Program
    {

        public class Guard
        {
            public int ID { get; set; }
            public int[] Hour { get; set; }
            public int TotalMinutesAsleep { get; set; }
            public int MinAsleepMost { get; set; }

            public Guard(int id, int[] hour)
            {
                ID = id;
                Hour = hour;
            }

            public Guard() { }
        }


        static void Main(string[] args)
        {
            string[] claimInput = System.IO.File.ReadAllLines(@"C:\Users\rwfrs\Documents\Projects\Advent2018input\input4.txt");

            List<string> EventLogg = new List<string>();
            List<Guard> GuardList = new List<Guard>();

            bool guardInList = false;
            int minuteFalls = 0;
            int minuteWakes = 0;
            int loggId = 0;
            int lastLoggId = 0;
            int[] currentHour = new int[59];

            int top_MinAsleepMost1 = 0;
            int top_MinAsleepMost2 = 0;
            int top_TotalMinutesAsleep = 0;
            int top_TimesAsleep = 0;

            int guard_MostMinsleep = 0;
            int guard_minAsleepMost = 0;

            foreach (string line in claimInput)
            {
                EventLogg.Add(line);
            }

            EventLogg.Sort();

            foreach (string timeStamp in EventLogg)
            {
                Guard guard = new Guard(0, new int[59]);

                if (timeStamp.Substring(19,5) == "Guard")
                {
                    guardInList = false;
                    loggId = Convert.ToInt32(timeStamp.Substring(26, 4));

                    foreach (Guard savedGuard in GuardList)
                    {                       
                        if (savedGuard.ID == loggId)
                        {
                            guardInList = true;
                            break;
                        }
                    }
                                  
                    if (guardInList == false)
                    {                     
                        guard.ID = loggId;
                        GuardList.Add(guard);
                    }

                    foreach (Guard savedGuard in GuardList)
                    {
                        if(lastLoggId == savedGuard.ID)
                        {

                            for (int i = 0; i < currentHour.Length; i++)
                            {
                                 savedGuard.Hour[i] += currentHour[i];
                            }
                            currentHour = new int[59];

                        }
                    }
                }             
                else if (timeStamp.Substring(19, 5) == "falls")
                {
                    minuteFalls = Convert.ToInt32(timeStamp.Substring(15, 2));

                }
                else if (timeStamp.Substring(19, 5) == "wakes")
                {
                    minuteWakes = Convert.ToInt32(timeStamp.Substring(15, 2));

                    for (int i = minuteFalls; i < minuteWakes; i++)
                    {
                        currentHour[i] ++; 
                    }
                }                
                lastLoggId = loggId;
            }
            
          

            foreach (Guard Guard in GuardList )
            {
                int timesAsleep = 0;
                int currentMin = 0;

                foreach (var minuteValue in Guard.Hour)
                {
                    Guard.TotalMinutesAsleep += minuteValue;
                    currentMin++;

                    if(minuteValue > timesAsleep)
                    {
                        timesAsleep = minuteValue; 
                        Guard.MinAsleepMost = currentMin; 
                    }
                }

                if (Guard.TotalMinutesAsleep > top_TotalMinutesAsleep)
                {
                    top_TotalMinutesAsleep = Guard.TotalMinutesAsleep;
                    guard_MostMinsleep = Guard.ID;
                    top_MinAsleepMost1 = Guard.MinAsleepMost - 1;
                }

                if (timesAsleep > top_TimesAsleep)
                {
                    top_TimesAsleep = timesAsleep;
                    guard_minAsleepMost = Guard.ID;
                    top_MinAsleepMost2 = Guard.MinAsleepMost - 1;

                }

            }

            int answer1 = guard_MostMinsleep * top_MinAsleepMost1;
            int answer2 = guard_minAsleepMost * top_MinAsleepMost2;

            Console.WriteLine("--- Part One --- \n GuardID: {0}\n Minutes Asleep: {1}\n What minute: {2}\n", guard_MostMinsleep, top_TotalMinutesAsleep, top_MinAsleepMost1);
            Console.WriteLine(" Puzzle Answer: {0} * {1} = {2} \n", guard_MostMinsleep, top_MinAsleepMost1, answer1);

            Console.WriteLine("--- Part Two --- \n GuardID: {0}\n What minute: {1}\n", guard_minAsleepMost, top_MinAsleepMost2);
            Console.WriteLine(" Puzzle Answer: {0} * {1} = {2} ", guard_minAsleepMost, top_MinAsleepMost2, answer2);
            Console.ReadLine();

        }
    }
}
