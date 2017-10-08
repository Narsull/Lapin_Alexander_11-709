namespace Mazes
{
    public static class EmptyMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            int b = 1;
            int a = 1;
            while (a < height - 2 || b < width - 2)
            {
                if (a < height - 2)
                {
                    robot.MoveTo(Direction.Down);
                    a++;
                }
                if (b < width - 2)
                {
                    robot.MoveTo(Direction.Right);
                    b++;
                }
            }
        }
    }
}