using System;

namespace MarsPathFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Point northeastPoint = new Point();
            const int robotCount = 2;
            InputOperations operations = new InputOperations();
            Robot[] robots = new Robot[robotCount];
            bool programIsFail=false;

            Console.Write("Northeast point coordinate:");

            string northeastPointInput = Console.ReadLine();

            if(operations.TryCreateNortheastPoint(northeastPointInput, out northeastPoint))
            {
                for(int i=0;i<robotCount;i++)
                {
                    Console.Write("Robot{0} initial position:",i+1);
                    string robotCreationImput = Console.ReadLine().ToUpper();
                    if (operations.TryCreateRobot(robotCreationImput, out robots[i], northeastPoint))
                    {
                        Console.Write("Robot{0} command:", i + 1);
                        string command = Console.ReadLine().ToUpper();

                        if (operations.CommandValidate(command))
                        {
                            operations.RunCommand(command, robots[i]);
                        }
                        else
                        {
                            programIsFail = true;
                            break;
                        }

                    }
                    else
                    {
                        programIsFail = true;
                        break;
                    }
                        
                }
                if (!programIsFail)
                {
                    ShowResult(robots);
                }   
            }
            Console.ReadLine();
        }

        static void ShowResult(Robot[] robots)
        {

            foreach(Robot robot in robots)
            {
                robot.ShowCoordinate();
            }
        }
    }
}
