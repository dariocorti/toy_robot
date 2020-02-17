using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    public class RobotExceptions
    {
        public string CommandNotRecognized   { get; set; } = "Not recognized command. Allowed commands:\nPLACE X,Y,F - MOVE - LEFT - RIGHT - REPORT";
        public string RobotNotPlaced         { get; set; } = "Robot is not placed yet";
        public string ExecutionCommandError  { get; set; } = "An error has occurred during command execution - Please retry";
        public string RobotOutOfTable        { get; set;  } = "Command ignored - robot out of tabletop";
        public string DirectionNotRecognized { get; set; } = "Command ignored - Not recognized direction\nAllowed directions: NORTH - EAST - SOUTH - WEST";
    }
}
