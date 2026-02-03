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

        public void ProcessInstructions(string instructions, Grid grid)
        {
            foreach (var instruction in instructions)
            {
                // Check if the robot is lost, if so then don't continue processing
                if(IsRobotLost)
                {
                    break;
                }
                
                // check the instructions
                if(instruction.ToString() == Action.L.ToString())
                {
                    // Change direction to the next left e.g. N -> W, S -> E
                    // Adding 3 to the direct, overflows the upper limit of base4 and ends at the previous number.
                    // Mod 4 makes sure it's always in the base4 range
                    Direction = (Direction)((int)(Direction + 3)%4);
                }else if(instruction.ToString() == Action.R.ToString())
                {
                    // Change direction to the next right e.g. N -> E, S -> W
                    // We will do the same as turning left but instead increment by 1, but still mod 4 as we could have more than 4 right turns in the instructions
                    Direction = (Direction)((int)(Direction + 1)%4);
                }
                else if(instruction.ToString() == Action.F.ToString())
                {
                    // Move the robot
                }
            }
        }
    }
}
