using RedBadger_MartianRobots_Main.Models;

class Program
{
    static void Main(string[] args)
    {
        if(args.Length == 0)
        {
            Console.WriteLine("Error: No input text file supplied in args.");
            return;
        }

        var filePath = args[0];
        if(!File.Exists(filePath))
        {
            Console.WriteLine($"Error: File ${filePath} was not found.");        
            return;
        }

        try
        {
            using var reader = new StreamReader(filePath);
            var gridSizeLine = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(gridSizeLine))
            {
                Console.WriteLine("No grid size was supplied.");
                return;
            }

            var gridCoords = gridSizeLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (!int.TryParse(gridCoords[0], out int maxWidth))
            {
                Console.WriteLine($"Error: Width {gridCoords[0]} is not a number");
                return;
            }

            if (maxWidth < 0 || maxWidth > 50)
            {
                Console.WriteLine("Error: Grid width is outside the bounds of the grid. 0 <= x <= 50");
                return;
            }

            if (!int.TryParse(gridCoords[1], out int maxHeight))
            {
                Console.WriteLine($"Error: Height {gridCoords} is not a number");
                return;
            }

            if (maxHeight < 0 || maxHeight > 50)
            {
                Console.WriteLine("Error: Grid height is outside the bounds of the grid. 0 <= x <= 50");
                return;
            }

            var grid = new Grid(maxWidth, maxHeight);

            while (!reader.EndOfStream)
            {
                var currentLine = reader.ReadLine();

                if (string.IsNullOrWhiteSpace(currentLine))
                {
                    // Skip blank lines as that should mean to move onto the next robot
                    continue;
                }

                var instructionLine = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(instructionLine))
                {
                    // If instruction line is null or empty, then break the loop, we have reached the end of the file.
                    break;
                }

                var positionParts = currentLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (!int.TryParse(positionParts[0], out var starPositionX))
                {
                    Console.Write($"Robot position {positionParts[0]} is not a valid number.");
                    return;
                }

                if (!int.TryParse(positionParts[1], out var starPositionY))
                {
                    Console.Write($"Robot position {positionParts[1]} is not a valid number.");
                    return;
                }

                if (!Enum.TryParse<Direction>(positionParts[2], out var direction))
                {
                    Console.Write($"Robot direction {positionParts[2]} is not a valid direction.");
                    return;
                }

                var robot = new Robot(starPositionX, starPositionY, direction);
                robot.ProcessInstructions(instructionLine.Trim(), grid);

                Console.WriteLine(robot.ToString());
            }

        }
        catch(Exception ex) { }
    }
}