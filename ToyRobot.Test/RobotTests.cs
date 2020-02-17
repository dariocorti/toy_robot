using NUnit.Framework;

namespace ToyRobot.Test
{
    [TestFixture]
    public class RobotTests
    {
        public Robot robot;
        public RobotExceptions exceptions = new RobotExceptions();

        [SetUp]
        public void Setup()
        {
            robot = new Robot();
        }

        #region exceptions
        [Test]
        public void CommandNotRecognized()
        {
            Assert.AreEqual(exceptions.CommandNotRecognized, robot.ExecuteCommand("GOAHEAD"));
        }

        [Test]
        public void RobotNotPlaced()
        {
            Assert.AreEqual(exceptions.RobotNotPlaced, robot.ExecuteCommand("MOVE"));
        }

        [Test]
        public void RobotOutOfTable()
        {
            robot.ExecuteCommand("PLACE 0,0,WEST");
            Assert.AreEqual(exceptions.RobotOutOfTable, robot.ExecuteCommand("MOVE"));
        }

        [Test]
        public void DirectionNotRecognized()
        {
            Assert.AreEqual(exceptions.DirectionNotRecognized, robot.ExecuteCommand("PLACE 0,0,NORTH-EAST"));
        }
        #endregion

        #region commands
        [Test]
        public void RobotCommand_Place()
        {
            Assert.AreEqual(string.Empty, robot.ExecuteCommand("PLACE 0,0,NORTH"));
        }

        [Test]
        public void RobotCommand_Report()
        {
            robot.ExecuteCommand("PLACE 0,0,NORTH");
            Assert.AreEqual("0,0,NORTH", robot.ExecuteCommand("REPORT"));
        }

        [Test]
        public void RobotCommand_Move_North()
        {
            robot.ExecuteCommand("PLACE 0,0,NORTH");
            robot.ExecuteCommand("MOVE");
            Assert.AreEqual("0,1,NORTH", robot.ExecuteCommand("REPORT"));
        }

        [Test]
        public void RobotCommand_Move_East()
        {
            robot.ExecuteCommand("PLACE 0,0,EAST");
            robot.ExecuteCommand("MOVE");
            Assert.AreEqual("1,0,EAST", robot.ExecuteCommand("REPORT"));
        }

        [Test]
        public void RobotCommand_Move_South()
        {
            robot.ExecuteCommand("PLACE 0,1,SOUTH");
            robot.ExecuteCommand("MOVE");
            Assert.AreEqual("0,0,SOUTH", robot.ExecuteCommand("REPORT"));
        }

        [Test]
        public void RobotCommand_Move_West()
        {
            robot.ExecuteCommand("PLACE 1,0,WEST");
            robot.ExecuteCommand("MOVE");
            Assert.AreEqual("0,0,WEST", robot.ExecuteCommand("REPORT"));
        }

        [Test]
        public void RobotCommand_Left_North()
        {
            robot.ExecuteCommand("PLACE 0,0,NORTH");
            robot.ExecuteCommand("LEFT");
            Assert.AreEqual("0,0,WEST", robot.ExecuteCommand("REPORT"));
        }

        [Test]
        public void RobotCommand_Left_West()
        {
            robot.ExecuteCommand("PLACE 0,0,WEST");
            robot.ExecuteCommand("LEFT");
            Assert.AreEqual("0,0,SOUTH", robot.ExecuteCommand("REPORT"));
        }

        [Test]
        public void RobotCommand_Left_South()
        {
            robot.ExecuteCommand("PLACE 0,0,SOUTH");
            robot.ExecuteCommand("LEFT");
            Assert.AreEqual("0,0,EAST", robot.ExecuteCommand("REPORT"));
        }

        [Test]
        public void RobotCommand_Left_East()
        {
            robot.ExecuteCommand("PLACE 0,0,EAST");
            robot.ExecuteCommand("LEFT");
            Assert.AreEqual("0,0,NORTH", robot.ExecuteCommand("REPORT"));
        }

        [Test]
        public void RobotCommand_Right_North()
        {
            robot.ExecuteCommand("PLACE 0,0,NORTH");
            robot.ExecuteCommand("RIGHT");
            Assert.AreEqual("0,0,EAST", robot.ExecuteCommand("REPORT"));
        }

        [Test]
        public void RobotCommand_Right_East()
        {
            robot.ExecuteCommand("PLACE 0,0,EAST");
            robot.ExecuteCommand("RIGHT");
            Assert.AreEqual("0,0,SOUTH", robot.ExecuteCommand("REPORT"));
        }

        [Test]
        public void RobotCommand_Right_South()
        {
            robot.ExecuteCommand("PLACE 0,0,SOUTH");
            robot.ExecuteCommand("RIGHT");
            Assert.AreEqual("0,0,WEST", robot.ExecuteCommand("REPORT"));
        }

        [Test]
        public void RobotCommand_Right_West()
        {
            robot.ExecuteCommand("PLACE 0,0,WEST");
            robot.ExecuteCommand("RIGHT");
            Assert.AreEqual("0,0,NORTH", robot.ExecuteCommand("REPORT"));
        }
        #endregion

        #region coordinates
        [Test]
        public void Robot_Placed_NegativeX()
        {
            Assert.AreEqual(exceptions.RobotOutOfTable, robot.ExecuteCommand("PLACE -1,0,NORTH"));
        }

        [Test]
        public void Robot_Placed_NegativeY()
        {
            Assert.AreEqual(exceptions.RobotOutOfTable, robot.ExecuteCommand("PLACE 0,-1,NORTH"));
        }

        [Test]
        public void Robot_Placed_UpperBoundX()
        {
            Assert.AreEqual(exceptions.RobotOutOfTable, robot.ExecuteCommand("PLACE 10,0,NORTH"));
        }

        [Test]
        public void Robot_Placed_UpperBoundY()
        {
            Assert.AreEqual(exceptions.RobotOutOfTable, robot.ExecuteCommand("PLACE 0,10,NORTH"));
        }
        #endregion

        #region out_of_table
        [Test]
        public void RobotCommand_Move_OutOfTable_North()
        {
            robot.ExecuteCommand("PLACE 0,4,NORTH");
            Assert.AreEqual(exceptions.RobotOutOfTable, robot.ExecuteCommand("MOVE"));
        }

        [Test]
        public void RobotCommand_Move_OutOfTable_East()
        {
            robot.ExecuteCommand("PLACE 4,0,EAST");
            Assert.AreEqual(exceptions.RobotOutOfTable, robot.ExecuteCommand("MOVE"));
        }

        [Test]
        public void RobotCommand_Move_OutOfTable_South()
        {
            robot.ExecuteCommand("PLACE 0,0,SOUTH");
            Assert.AreEqual(exceptions.RobotOutOfTable, robot.ExecuteCommand("MOVE"));
        }

        [Test]
        public void RobotCommand_Move_OutOfTable_West()
        {
            robot.ExecuteCommand("PLACE 0,0,WEST");
            Assert.AreEqual(exceptions.RobotOutOfTable, robot.ExecuteCommand("MOVE"));
        }
        #endregion

        #region simple_tests
        [Test]
        public void RobotCommand_Test_1()
        {
            robot.ExecuteCommand("PLACE 0,0,NORTH");
            robot.ExecuteCommand("MOVE");
            robot.ExecuteCommand("MOVE");
            robot.ExecuteCommand("MOVE");
            robot.ExecuteCommand("RIGHT");
            robot.ExecuteCommand("MOVE");
            Assert.AreEqual("1,3,EAST", robot.ExecuteCommand("REPORT"));
        }

        [Test]
        public void RobotCommand_Test_2()
        {
            robot.ExecuteCommand("PLACE 2,3,SOUTH");
            robot.ExecuteCommand("MOVE");
            robot.ExecuteCommand("LEFT");
            robot.ExecuteCommand("MOVE");
            Assert.AreEqual("3,2,EAST", robot.ExecuteCommand("REPORT"));
        }

        [Test]
        public void RobotCommand_Test_3()
        {
            robot.ExecuteCommand("PLACE 1,2,EAST");
            robot.ExecuteCommand("MOVE");
            robot.ExecuteCommand("MOVE");
            robot.ExecuteCommand("LEFT");
            robot.ExecuteCommand("MOVE");
            Assert.AreEqual("3,3,NORTH", robot.ExecuteCommand("REPORT"));
        }
        #endregion
    }
}