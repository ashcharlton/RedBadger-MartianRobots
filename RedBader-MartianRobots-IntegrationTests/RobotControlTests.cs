using NUnit.Framework;
using RedBadger_MartianRobots_Main;
using RedBadger_MartianRobots_Main.Models;
using System.IO;

namespace RedBadger_MartianRobots_IntegrationTests;

[TestFixture]
public class RobotControlTests
{
    private string _testFilePath;

    [SetUp]
    public void Setup()
    {
        _testFilePath = Path.Combine(Path.GetTempPath(), "InputData.txt");
    }

    [TearDown]
    public void Cleanup()
    {
        if (File.Exists(_testFilePath))
        {
            File.Delete(_testFilePath);
        }
    }

    [Test]
    public void MissionControl_ShouldMatchSampleOutput_FromChallenge()
    {
        // Arrange
        var sampleInput =
            @"5 3
            1 1 E
            RFRFRFRF

            3 2 N
            FRRFLLFFRRFLL

            0 3 W
            LLFFFLFLFL";

        File.WriteAllText(_testFilePath, sampleInput);
        var mission = new RobotControl();

        using var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        mission.ExecuteInstructionsFromFile(_testFilePath);

        // Assert
        var result = sw.ToString().Trim().Replace("\r\n", "\n");
        var expectedOutput = "1 1 E\n3 3 N LOST\n2 3 S";

        Assert.That(result, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void MissionControl_ShouldEnforceScentLogic_BetweenRobots()
    {
        var scentInput =
            @"5 3
            5 3 N
            F

            5 3 N
            F";
        File.WriteAllText(_testFilePath, scentInput);
        var mission = new RobotControl();

        using var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        mission.ExecuteInstructionsFromFile(_testFilePath);
        var lines = sw.ToString().Trim().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        // Assert
        Assert.That(lines[0], Does.Contain("LOST"), "First robot should be lost");
        Assert.That(lines[1], Does.Not.Contain("LOST"), "Second robot should be saved by the scent left at (5,3)");
        Assert.That(lines[1], Is.EqualTo("5 3 N"), "Second robot should remain at the edge");
    }

    [Test]
    public void MissionControl_ShouldRejectGrid_ExceedingMaximumCoordinates()
    {
        // Arrange
        var invalidInput = "51 3\n1 1 E\nF";
        File.WriteAllText(_testFilePath, invalidInput);
        var mission = new RobotControl();

        using var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        mission.ExecuteInstructionsFromFile(_testFilePath);

        // Assert
        Assert.That(sw.ToString(), Does.Contain("Error"), "Should report error for coordinates > 50 ");
    }
}