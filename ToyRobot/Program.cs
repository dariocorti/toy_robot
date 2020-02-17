using System;

namespace ToyRobot
{
    class Program
    {
        private static void Main(string[] args)
        {
            string command = string.Empty;
            Robot robot = new Robot();

            Console.WriteLine("Toy robot game");
            Console.WriteLine("Enter commands to move the robot.");
            Console.WriteLine("(Type ESC to exit)");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Enter command:");
                command = Console.ReadLine();

                if (command.ToUpper() == "ESC")
                {
                    Console.WriteLine();
                    break;
                }

                Console.WriteLine(robot.ExecuteCommand(command));
                Console.WriteLine();
            }

            Console.WriteLine("Game over - press any key to close");
            Console.ReadLine();
        }
    }
}
