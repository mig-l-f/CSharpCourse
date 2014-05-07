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
            SubGrid subGrid = new SubGrid(3, 3);


            bool shouldContinuePlaying = true;
            do
            {
                Console.Clear();
                int guessX = 0;
                do
                {
                    Console.Write("X co-ord? ");
                    guessX = Convert.ToInt32(Console.ReadLine());
                } while (guessX > subGrid.GetUpperBound(0) | guessX < subGrid.GetLowerBound(0));
                int guessY = 0;
                do
                {
                    Console.Write("Y co-ord? ");
                    guessY = Convert.ToInt32(Console.ReadLine());
                } while (guessY > subGrid.GetUpperBound(1) | guessY < subGrid.GetLowerBound(1));
                // If is looking for true or false, which is what is in our
                //  grid. Booleans are default false, so we didn't need
                //  to explicitly set the remainder to false.

                try
                {
                    if (subGrid.hasSubmarineInPosition(guessX, guessY))
                    {
                        Console.Beep();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("You found it!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(subGrid);
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