using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadger_MartianRobots_Main.Models
{
    public class Robot
    {
        public Robot(int xPosition, int yPosition, Direction direction)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Direction = direction;
        }

        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public Direction Direction { get; set; }
        public bool IsRobotLost { get; set; }

        public void ProcessInstructions(List<string> instructions, Grid grid)
        {
            foreach (var instruction in instructions)
            {
                // Check if the robot is lost, if so then don't continue processing

                
                
                
            }
        }
    }
}
