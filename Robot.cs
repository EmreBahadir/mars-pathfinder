namespace MarsPathFinder
{
    class Robot
    {
        Point currentPoint;
        CardinalDirection currentDirection;
        readonly Point maxPoint;

        public Robot(Point startPoint,CardinalDirection startDirection, Point maxPoint)
        {
            currentPoint = startPoint;
            currentDirection = startDirection;
            this.maxPoint = maxPoint;
        }
        public Robot() { }

        public void Move()
        {
            if (currentDirection == CardinalDirection.N)
                currentPoint.Y++;
            else if (currentDirection == CardinalDirection.E)
                currentPoint.X++;
            else if (currentDirection == CardinalDirection.S)
                currentPoint.Y--;
            else
                currentPoint.X--;

            ControlCurrentpoint();
        }

        //if device cross the border, adjust device point   
        private void ControlCurrentpoint()
        {
            if (currentPoint.X > maxPoint.X)
                currentPoint.X = maxPoint.X;
            else if (currentPoint.X < 0)
                currentPoint.X = 0;

            if (currentPoint.Y > maxPoint.Y)
                currentPoint.Y = maxPoint.Y;
            else if (currentPoint.Y < 0)
                currentPoint.Y = 0;

        }


        //Turn right
        public void RotateClockwise()
        {
            if (currentDirection == CardinalDirection.W)
                currentDirection = CardinalDirection.N;
            else
                currentDirection++;
        }

        //turn left 
        public void RotateCounterClockwise()
        {
            if (currentDirection == CardinalDirection.N)
                currentDirection = CardinalDirection.W;
            else
                currentDirection--;
        }

        public void ShowCoordinate()
        {
            string result = string.Format("{0} {1} {2}",currentPoint.X.ToString(),currentPoint.Y.ToString(),currentDirection.ToString());
            System.Console.WriteLine(result);
        }
    }
}
