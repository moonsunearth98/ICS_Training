/*1 Write a program to find the Sum and the Average points scored by the teams in the IPL.
 Create a Class called Cricket that has a function called Pointscalculation(int no_of_matches)
  that takes no.of matches as input and accepts that many scores from the user.
  The function should then display the Average and Sum of the scores.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_3
{
    class Que1_IPLAveragePoints_Calculator
    {
        class Cricket
        {
            public void Pointscalculation(int no_of_matches)
            {
                int[] scores = new int[no_of_matches];
                int sum = 0;
                for (int i = 0; i < no_of_matches; i++)
                {
                    Console.Write($"Enter score for match {i + 1}: ");
                    if (int.TryParse(Console.ReadLine(), out int score))
                    {
                        scores[i] = score;
                        sum += score;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid score.");
                        i--;
                    }
                }
                double average = (double)sum / no_of_matches;
                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"Sum of scores: {sum}");
                Console.WriteLine($"Average score: {average:F2}");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Enter the number of IPL matches: ");
                if (int.TryParse(Console.ReadLine(), out int no_of_matches) && no_of_matches > 0)
                {
                    Cricket cricket = new Cricket();
                    cricket.Pointscalculation(no_of_matches);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number of matches :-)");
                }
                Console.ReadLine();
            }

        }
    }
}
