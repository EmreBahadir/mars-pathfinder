using System;

namespace MarsPathFinder
{
    class InputOperations
    {
        public bool CommandValidate(string commandString)
        {
            if (commandString is null)
                return false;
            foreach (char commandChar in commandString )
            {
                if(!commandChar.Equals('R') && !commandChar.Equals('r') && 
                    !commandChar.Equals('L') && !commandChar.Equals('l') &&
                     !commandChar.Equals('M') && !commandChar.Equals('m') )
                
                    return false;
                
            }
            return true;
        }

        public void RunCommand(string commandString, Robot robot)
        {
            foreach(char commandChar in commandString)
            {
                if (commandChar.Equals('L') || commandChar.Equals('l'))
                    robot.Rotate('L');
                else if (commandChar.Equals('R') || commandChar.Equals('r'))
                    robot.Rotate('R');
                else
                    robot.Move();
            }
        }

        public bool tryCreateNortheastPoint(string commanString, out Point northeastPoint)
        {
            Point tempPoint = new Point(0, 0);
            int[] coordinateValues;
            string[] tokens = commanString.Split(' ');

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
    }
}
