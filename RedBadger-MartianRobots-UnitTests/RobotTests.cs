using RedBadger_MartianRobots_Main.Models;

namespace RedBadger_MartianRobots_UnitTests
{
    public class RobotTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IfRobotIsLost_StopProcessingInstructions()
        {
            // Arrange
            var robot = new Robot(0, 0, Direction.N);
            var grid = new Grid(1, 1);
            robot.IsRobotLost = true;

            // Act
            robot.ProcessInstructions("FFFLL", grid);

            // Assert
            Assert.That(robot.XPosition, Is.EqualTo(0));
            Assert.That(robot.YPosition, Is.EqualTo(0));
            Assert.That(robot.Direction, Is.EqualTo(Direction.N));
        }

        [TestCase("L", Direction.W)]
        [TestCase("LL", Direction.S)]
        [TestCase("LLL", Direction.E)]
        [TestCase("LLLL", Direction.N)]

        public void InstructionIsLeft_RobotRotatesAntiClockwise(string instructions, Direction finalDirection)
        {
            // Arrange
            var robot = new Robot(0, 0, Direction.N);
            var grid = new Grid(1, 1);

            // Act
            robot.ProcessInstructions(instructions, grid);

            // Assert
            Assert.That(robot.Direction, Is.EqualTo(finalDirection));
        }
    }
}