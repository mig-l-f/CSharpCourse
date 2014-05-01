using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrtFixer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Jagged array to allow use of foreach below
            int[][] times = { new[] {3,16,45}, new[] {1,59,59}, new[] {9,38,0} };

            foreach(int[] time in times) {
                // Replace demo line below with a call to your method
                Console.WriteLine("Hour is: {0}", time[0]);
            }
        }

        // Write your time incrementing & printing method here
		

    }
}
