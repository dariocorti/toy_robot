using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    public class Robot
    {
        Table tableTop;
        RobotExceptions exceptions;

        public Robot()
        {
            tableTop = new Table();
            exceptions = new RobotExceptions();
        }

        //Table is 5x5, but index start from 0
        private class Table
        {
            public int xBoundary = 4;
            public int yBoundary = 4;
        }

        private bool isPlaced = false;
        private int x = -1;
        private int y = -1;
        private string direction = string.Empty;

        public string ExecuteCommand(string command)
        {
            command = command.ToUpper();
            string commandResult = string.Empty;

            try
            {
                if (!ValidateCommand(command))
                {
                    commandResult = exceptions.CommandNotRecognized;
                }
                else 
                { 
                    if (command.Contains("PLACE"))
                    {
                        commandResult = Place(command);
                    }
                    else
                    {
                        if(isPlaced)
                        {
                            switch (command)
                            {
                                case "MOVE":
                                    commandResult = Move();
                                    break;
                                case "RIGHT":
                                    Right();
                                    break;
                                case "LEFT":
                                    Left();
                                    break;
                                case "REPORT":
                                    commandResult = Report();
                                    break;
                                default:
                                    break;

                            }
                        }
                        else
                        {
                            commandResult = exceptions.RobotNotPlaced;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                commandResult = exceptions.ExecutionCommandError;
            }

            return commandResult;
        }

        #region commands
        private string Place(string command)
        {
            string result = string.Empty;
            string[] coordinates = command.Replace("PLACE ", "").Split(',');

            x = int.Parse(coordinates[0]);
            y = int.Parse(coordinates[1]);
            direction = coordinates[2].ToUpper();

            if (!ValidatePosition())
            {
                result = exceptions.RobotOutOfTable; 
            }    
            else
            {
                if(!ValidateDirection())
                {
                    result = exceptions.DirectionNotRecognized;
                }
                else
                {
                    isPlaced = true;
                }
            }

            return result;
        }

        private string Move()
        {
            string result = string.Empty;
            int originalX = x;
            int originalY = y;

            switch (direction)
            {
                case "NORTH":
                    y++; break;
                case "WEST":
                    x--; break;
                case "SOUTH":
                    y--; break;
                case "EAST":
                    x++; break;
            }

            if (!ValidatePosition())
            {
                x = originalX;
                y = originalY;
                result = exceptions.RobotOutOfTable;
            }
            return result;
        }

        private void Left()
        {
            switch (direction.ToUpper())
            {
                case "NORTH":
                    direction = "WEST"; 
                    break;
                case "WEST":
                    direction = "SOUTH"; 
                    break;
                case "SOUTH":
                    direction = "EAST"; 
                    break;
                case "EAST":
                    direction = "NORTH"; 
                    break;
            }
        }

        private void Right()
        {
            switch (direction.ToUpper())
            {
                case "NORTH":
                    direction = "EAST"; 
                    break;
                case "EAST":
                    direction = "SOUTH"; 
                    break;
                case "SOUTH":
                    direction = "WEST"; 
                    break;
                case "WEST":
                    direction = "NORTH"; 
                    break;
            }
        }

        private string Report()
        {
            return x + "," + y + "," + direction;
        }
        #endregion

        #region validations
        private bool ValidateCommand(string command)
        {
            return (command.Contains("PLACE") || command == "MOVE" || command == "LEFT" || command == "RIGHT" || command == "REPORT");
        }

        private bool ValidatePosition()
        {
            if ((x < 0) || (y < 0))
                return false;
            else if ((x > tableTop.xBoundary) || (y > tableTop.yBoundary))
                return false;
            else
                return true;
        }

        private bool ValidateDirection()
        {
            return (direction == "NORTH" || direction == "EAST" || direction == "SOUTH" || direction == "WEST");
        }
        #endregion
    }
}
