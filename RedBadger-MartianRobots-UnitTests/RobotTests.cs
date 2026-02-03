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

        [TestCase("R", Direction.E)]
        [TestCase("RR", Direction.S)]
        [TestCase("RRR", Direction.W)]
        [TestCase("RRRR", Direction.N)]
        public void InstructionIsRight_RobotRotatesClockwise(string instructions, Direction finalDirection)
        {
            // Arrange
            var robot = new Robot(0, 0, Direction.N);
            var grid = new Grid(1, 1);

            // Act
            robot.ProcessInstructions(instructions, grid);

            // Assert
            Assert.That(robot.Direction, Is.EqualTo(finalDirection));
        }

        [Test]
        public void RobotFallsOffGrid_RobotIsLostAndScentIsAdded()
        {
            // Arrange
            var robot = new Robot(0, 0, Direction.N);
            var grid = new Grid(1,1);

            // Act
            robot.ProcessInstructions("FF", grid);

            // Assert
            Assert.That(robot.IsRobotLost, Is.True);
            Assert.That(grid.HasScent(0, 1), Is.True);
            Assert.That(robot.XPosition, Is.EqualTo(0));
            Assert.That(robot.YPosition, Is.EqualTo(1));
        }

        [Test]
        public void RobotIsOnScent_InstructionWillCauseRobotToGoOffGrid_IgnoreInstruction()
        {
            // Arrange
            var robot1 = new Robot(0, 0, Direction.N);
            var robot2 = new Robot(0, 0, Direction.N);
            var grid = new Grid(1, 1);

            // Act
            robot1.ProcessInstructions("FF", grid);
            robot2.ProcessInstructions("FF", grid);

            // Assert
            Assert.That(robot1.IsRobotLost, Is.True);
            Assert.That(robot2.IsRobotLost, Is.False);
            Assert.That(grid.HasScent(0, 1), Is.True);
            Assert.That(robot1.XPosition, Is.EqualTo(0));
            Assert.That(robot1.YPosition, Is.EqualTo(2));

            Assert.That(robot2.XPosition, Is.EqualTo(0));
            Assert.That(robot2.YPosition, Is.EqualTo(1));
        }
    }
}