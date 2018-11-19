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

        public Point StartPoint(string commanString)
        {
            return null;
        }
    }
}
