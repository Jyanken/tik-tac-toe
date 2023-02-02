using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardLogic
{
    public class Board
    {
        public int[] Grid
        {
            get; set;
        }

        public Board()
        {
            Grid = new int[9];

            // initialize the Grid
            // set all squares to empty
            for (int i = 0; i < 9; i++)
            {
                Grid [i] = 0;
            }
        }

        public bool isBoardFull()
        {
            bool isFull = true;
            // assume the board is full. if an exception is found, change the varaible.
            for (int i = 0; i < Grid.Length; i++)
            {
                if (Grid[i] == 0)
                {
                    isFull = false;
                }
            }
            return isFull;

        }
        public int checkForWinner()
        {
            if (Grid[0] == Grid[1] && Grid[1] == Grid[2])
            {
                // top row match
                return Grid[0];
            }
            if (Grid[3] == Grid[4] && Grid[4] == Grid[5])
            {
                // middle row match
                return Grid[3];
            }
            if (Grid[6] == Grid[7] && Grid[7] == Grid[8])
            {
                // bottom row match
                return Grid[6];
            }
            if (Grid[0] == Grid[3] && Grid[3] == Grid[6])
            {
                // first col match
                return Grid[0];
            }
            if (Grid[1] == Grid[4] && Grid[4] == Grid[7])
            {
                // middle col match
                return Grid[1];
            }
            if (Grid[2] == Grid[5] && Grid[5] == Grid[8])
            {
                // third col match
                return Grid[2];
            }
            if (Grid[0] == Grid[4] && Grid[4] == Grid[8])
            {
                // first diagonal
                return Grid[0];
            }
            if (Grid[2] == Grid[4] && Grid[4] == Grid[6])
            {
                // second diagonal
                return Grid[2];
            }

            return 0;
        }
    }
}
