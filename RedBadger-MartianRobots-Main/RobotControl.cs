using RedBadger_MartianRobots_Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadger_MartianRobots_Main
{
    public class RobotControl
    {
        private Grid _grid;

        public void ExecuteInstructionsFromFile(string filePath)
        {
            using var reader = new StreamReader(filePath);
            var gridSizeLine = reader.ReadLine();
            if (!TryParseGrid(gridSizeLine)) return;

            while (!reader.EndOfStream)
            {
                var positionLine = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(positionLine)) continue;

                var instructionLine = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(instructionLine)) break;

                if (TryParseRobot(positionLine, out Robot? robot))
                {
                    robot!.ProcessInstructions(instructionLine.Trim(), _grid);
                    Console.WriteLine(robot.ToString());
                }
            }
        }

        private bool TryParseGrid(string? line)
        {
            if (string.IsNullOrWhiteSpace(line)) return false;

            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2 ||
                !int.TryParse(parts[0], out int x) ||
                !int.TryParse(parts[1], out int y))
            {
                Console.WriteLine("Error: Invalid grid format.");
                return false;
            }

            if (x > 50 || y > 50 || x < 0 || y < 0)
            {
                Console.WriteLine("Error: Grid coordinates must be between 0 and 50.");
                return false;
            }

            _grid = new Grid(x, y);
            return true;
        }

        private bool TryParseRobot(string line, out Robot? robot)
        {
            robot = null;
            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 3 ||
                !int.TryParse(parts[0], out int x) ||
                !int.TryParse(parts[1], out int y) ||
                !Enum.TryParse<Direction>(parts[2], out var dir))
            {
                Console.WriteLine($"Error: Invalid robot data: {line}");
                return false;
            }

            robot = new Robot(x, y, dir);
            return true;
        }
    }
}
