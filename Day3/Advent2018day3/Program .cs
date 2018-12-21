using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent2018day3
{
    class Program
    {
  
        public class Claim
        {

            public int ClaimID { get; set; }
            public int Rec_leftInches { get; set; }
            public int Rec_topInches { get; set; }
            public int Rec_width { get; set; }
            public int Rec_height { get; set; }

            int rec_rowEnd;
            int rec_colEnd;

            public int FindOverlappingClaims(int[,] fabricArea, List<Claim> ClaimList)
            {
                int overlappingInches = 0;
                foreach (Claim claim in ClaimList)
                {
                   
                    rec_rowEnd = claim.Rec_leftInches + claim.Rec_width;
                    rec_colEnd = claim.Rec_topInches + claim.Rec_height;

                    for (int x = claim.Rec_leftInches; x < rec_rowEnd; x++)
                    {

                        for (int y = claim.Rec_topInches; y < rec_colEnd; y++)
                        {

                            if (fabricArea[x, y] == 0)
                            {
                                fabricArea[x, y] = 1;
                            }

                            else if (fabricArea[x, y] == 1)
                            {
                                fabricArea[x, y] = 2;
                            }

                        }
                    }

                }

                foreach (var item in fabricArea)
                {
                    if (item == 2)
                    {
                        overlappingInches++;
                    }

                }

                return overlappingInches;
            }

            public int FindOnlyClaimNotOverlapping(List<Claim> ClaimList, int[,] fabricArea)
            {
                foreach (Claim claim in ClaimList)
                {
                    bool wrongClaim = false;
                    rec_rowEnd = claim.Rec_leftInches + claim.Rec_width;
                    rec_colEnd = claim.Rec_topInches + claim.Rec_height;

                    for (int x = claim.Rec_leftInches; x < rec_rowEnd; x++)
                    {

                        for (int y = claim.Rec_topInches; y < rec_colEnd; y++)
                        {

                            if (fabricArea[x, y] != 1)
                            {
                                wrongClaim = true;
                            }

                        }
                    }

                    if (wrongClaim == false)
                    {
                        return claim.ClaimID;
                    }

                    wrongClaim = false;
                }

               return 0;
                
            }
        }
      

        static void Main(string[] args)
        {

            string[] claimInput = System.IO.File.ReadAllLines(@"C:\Users\rwfrs\Documents\Projects\Advent2018input\input3.txt");

            int[,] fabricArea = new int[1500, 1500];
            Claim claim = new Claim();
            List<Claim> ClaimList = new List<Claim>();

            foreach (string claimString in claimInput)
            {
                Claim claimConverted = new Claim();
                Match regex = Regex.Match(claimString, @"\d+");

                claimConverted.ClaimID = Convert.ToInt32(regex.Value);
                regex = regex.NextMatch();
                claimConverted.Rec_leftInches = Convert.ToInt32(regex.Value);
                regex = regex.NextMatch();
                claimConverted.Rec_topInches = Convert.ToInt32(regex.Value);
                regex = regex.NextMatch();
                claimConverted.Rec_width = Convert.ToInt32(regex.Value);
                regex = regex.NextMatch();
                claimConverted.Rec_height = Convert.ToInt32(regex.Value);

                ClaimList.Add(claimConverted);
            }

            int overlappingInches = claim.FindOverlappingClaims(fabricArea, ClaimList);
            int rightClaim = claim.FindOnlyClaimNotOverlapping(ClaimList, fabricArea);
                                       
            Console.WriteLine("--- Part One --- How many square inches of fabric are within two or more claims?");
            Console.WriteLine("Puzzle answer: " + overlappingInches + Environment.NewLine);
            Console.WriteLine("--- Part Two --- What is the ID of the only claim that doesn't overlap?");
            Console.WriteLine("Puzzle answer: " + rightClaim);
            Console.ReadLine();

        }

    }
}
