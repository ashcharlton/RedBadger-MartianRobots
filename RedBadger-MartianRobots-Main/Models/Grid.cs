using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadger_MartianRobots_Main.Models
{
    public class Grid
    {
        private readonly int _maxXCoord;
        private readonly int _maxYCoord;
        private readonly HashSet<(int xPosition, int yPosition)> _scents = new HashSet<(int xPosition, int yPosition)>();

        public Grid(int maxXCoord, int maxYCoord)
        {
            if(maxXCoord > 50 || maxYCoord > 50)
            {
                throw new Exception("The grid cannot be greater than 50 high or wide.");
            }

            if(maxXCoord < 0 || maxYCoord < 0)
            {
                throw new Exception("The grid cannot have a negative height or width.");
            }

            _maxXCoord = maxXCoord;
            _maxYCoord = maxYCoord;
        }

        public void AddScent(int xPosition, int yPosition) => _scents.Add((xPosition, yPosition));

        public void HasScent(int xPosition, int yPosition) => _scents.Contains((xPosition, yPosition));

        public bool IsOffGrid(int xPosition, int yPosition) => xPosition < 0 || yPosition < 0 || xPosition > _maxXCoord || yPosition > _maxYCoord;
    }
}
