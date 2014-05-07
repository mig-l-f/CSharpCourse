using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubHuntCS
{
    class Program
    {
        static void Main(string[] args)
        {
            //    ' Make a 3 x 3 grid
            Boolean[,] subGrid = new Boolean[3, 3];
            // I am hiding my sub in the centre. Shhhh.
            subGrid[1, 1] = true;

            bool shouldContinuePlaying = true;
            do
            {
                Console.Clear();
                Console.Write("X co-ord? ");
                int guessX = Convert.ToInt32(Console.ReadLine());
                Console.Write("Y co-ord? ");
                int guessY = Convert.ToInt32(Console.ReadLine());
                // If is looking for true or false, which is what is in our
                //  grid. Booleans are default false, so we didn't need
                //  to explicitly set the remainder to false.

                try
                {
                    if (subGrid[guessX, guessY])
                    {
                        Console.Beep();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("You found it!");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    else
                    {
                        Console.WriteLine("Not there, sorry.");
                    }
                }
                catch (IndexOutOfRangeException indexOutOfRangeException)
                {
                    Console.WriteLine("ERROR: the provided indexes are out of range. Max 2");
                }

                
                // Now, how could we improve this? Where does it fall down
                // in usability terms? Also, what about a loop? Or randomly
                // positioned submarines?
                Console.WriteLine("Do you want to play again? (y/n)");
                if (String.Compare(Console.ReadLine(), "y") == 0)
                    shouldContinuePlaying = true;
                else
                    shouldContinuePlaying = false;
            } while (shouldContinuePlaying);
        }
    }
}