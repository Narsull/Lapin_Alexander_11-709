namespace Mazes
{
    public static class SnakeMazeTask
    {
        static int i = 1;

        public static void MoveOut(Robot robot, int width, int height)
        {
            for (int a = 1; a <= height / 2; a++)
            {
                MoveLeftOrRight(robot, width, height);

                if (a < height / 2)
                {
                    robot.MoveTo(Direction.Down);
                    robot.MoveTo(Direction.Down);
                }
            }
        }
        public static void MoveLeftOrRight(Robot robot, int width, int height)
        {
            i++;

            for (int a = 1; a < width - 2; a++)
            {
                if (i % 2 == 1)
                    robot.MoveTo(Direction.Left);
                else
                    robot.MoveTo(Direction.Right);
            }
        }
    }
}