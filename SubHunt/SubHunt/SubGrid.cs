using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubHuntCS
{
    public class SubGrid
    {
        private Location[,] _subGrid;
        private Random prng;

        private int randIndex(int rank)
        {
            return prng.Next(GetUpperBound(rank) + 1); ;
        }

        public SubGrid(int xmax, int ymax)
        {
            _subGrid = new Location[xmax, ymax];
            for (int i = 0; i < xmax; i++)
                for (int j = 0; j < ymax; j++)
                    _subGrid[i, j] = new Location();

            //Assign submarine position
            prng = new Random();
            _subGrid[randIndex(0), randIndex(1)].hasSubmarine = true;
            //_subGrid[1, 1].hasSubmarine = true;
        }
        public Boolean hasSubmarineInPosition(int xpos, int ypos) {
            if (!_subGrid[xpos, ypos].hasSubmarine)
                _subGrid[xpos, ypos].hasBeenFiredUpon = true;
            return _subGrid[xpos, ypos].hasSubmarine;
        }
        public Boolean hasPositionBeenFiredUpon(int xpos, int ypos)
        {
            return _subGrid[xpos, ypos].hasBeenFiredUpon;
        }
        public int GetUpperBound(int rank)
        {
            return _subGrid.GetUpperBound(rank);
        }
        public int GetLowerBound(int rank)
        {
            return _subGrid.GetLowerBound(rank);
        }
        public override string ToString()
        {
            String output = "";
            for (int j = 0; j <= GetUpperBound(1); j++)
            {
                for (int i = 0; i <= GetUpperBound(0); i++)
                {
                    if (_subGrid[i, j].hasSubmarine)
                        output += "o";
                    else if (_subGrid[i, j].hasBeenFiredUpon)
                        output += "x";
                    else
                        output += "-";
                }
                output += "\n";
            }
            return output;
        } 
    }
}
