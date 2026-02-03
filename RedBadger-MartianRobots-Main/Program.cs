using RedBadger_MartianRobots_Main;
using RedBadger_MartianRobots_Main.Models;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Error: No input text file supplied in args.");
            return;
        }

        var filePath = args[0];
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Error: File {filePath} was not found.");
            return;
        }

        try
        {
            // The logic is now encapsulated in a dedicated Mission class
            var robotControl = new RobotControl();
            robotControl.ExecuteInstructionsFromFile(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}