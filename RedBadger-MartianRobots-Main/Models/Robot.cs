using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadger_MartianRobots_Main.Models
{
    public class Robot
    {
        private readonly int _xPosition;
        private readonly int _yPosition;
        private readonly Direction _direction;

        public Robot(int xPosition, int yPosition, Direction direction)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
            _direction = direction;
        }

        public void ProcessInstructions(List<string> instructions, Grid grid)
        {
            foreach (var instruction in instructions)
            {
                // Check if the instruction is an direction change first as the robot won't move any spaces and won't fall off. 

            }
        }
    }
}
