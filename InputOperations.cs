using System;

namespace MarsPathFinder
{
    class InputOperations
    {
        public bool CommandValidate(string commandString)
        {
            if (commandString is null)
                return false;
            CommandType commandType;

            foreach (char commandChar in commandString )
            {
                if(!Enum.TryParse(commandChar.ToString(),out commandType) )
                
                    return false;
                
            }
            return true;
        }

        public void RunCommand(string commandString, Robot robot)
        {
            if (string.IsNullOrEmpty(commandString))
            {
                throw new ArgumentException("message", nameof(commandString));
            }

            foreach (char commandChar in commandString)
            {
                CommandType commandType;

                Enum.TryParse(commandChar.ToString(), out commandType);

                if (commandType == CommandType.L)
                    robot.RotateCounterClockwise();
                else if (commandType == CommandType.R)
                    robot.RotateClockwise();
                //yeni komut eklenebilmesi için else yerine else if konuldu
                else if (commandType == CommandType.M)
                    robot.Move();
                
            }

            robot.PositionControl();
        }

        public bool TryCreateNortheastPoint(string input, out Point northeastPoint)
        {

            Point tempPoint = new Point(0, 0);
            int[] coordinateValues=new int[2];

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input must be not empty");
                northeastPoint = tempPoint;
                return false;
            }

            string[] tokens = input.Split(' ');

            if (tokens.Length != 2)
            {
                Console.WriteLine("Please use two parameters");
                northeastPoint = tempPoint;
                return false;
            }

            for(int i=0;i<2;i++)
            {
                if (!int.TryParse(tokens[i], out coordinateValues[i]))
                {
                    Console.WriteLine("Coordinate value must be numeric");
                    northeastPoint = tempPoint;
                    return false;
                }
                else if (coordinateValues[i] < 0)
                {
                    Console.WriteLine("Coordinate values of northeast point must be bigger than 0 ");
                    northeastPoint = tempPoint;
                    return false;
                }
            }
            northeastPoint = new Point(coordinateValues[0], coordinateValues[1]);
            return true;
        }

        public bool TryCreateRobot(string input, out Robot robot, Point northeastPoint)
        {
            Robot tempRobot = new Robot();
            CardinalDirection direction;
            int[] coordinateValues=new int[2];

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input must be not empty");
                robot = tempRobot;
                return false;
            }

            string[] tokens = input.Split(' ');


            if (tokens.Length != 3)
            {
                Console.WriteLine("Please use three parameters");
                robot = tempRobot;
                return false;
            }

            for (int i = 0; i < 2; i++)
            {
                if (!int.TryParse(tokens[i], out coordinateValues[i]))
                {
                    Console.WriteLine("Coordinate value must be numeric");
                    robot = tempRobot;
                    return false;
                }
                else if (coordinateValues[i] < 0 || coordinateValues[i] > (i == 0 ? northeastPoint.X : northeastPoint.Y))
                {
                    Console.WriteLine("Robot position must be between 0,0 and {0},{1}",northeastPoint.X,northeastPoint.Y);
                    robot = tempRobot;
                    return false;
                }
            }

            if(!Enum.TryParse(tokens[2], out direction))
            {
                Console.WriteLine("Wrong direction data");
                robot = tempRobot;
                return false;
            }


            robot = new Robot(new Point(coordinateValues[0], coordinateValues[1]), direction,northeastPoint);
            return true;
        }
    }
}
