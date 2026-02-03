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
                    // As we are using an enum that has numerical values we can subtract 1 from the value to go anti-clockwise around the compass.
                    Direction = Direction + 3;
                }else if(instruction.ToString() == Action.R.ToString())
                {
                    // Change direction to the next right e.g. N -> E, S -> W
                    // As we are using an enum that has numerical values we can subtract 1 from the value to go anti-clockwise around the compass.
                    Direction = Direction + 1;
                }
                else if(instruction.ToString() == Action.F.ToString())
                {
                    // Move the robot
                }
            }
        }
    }
}
