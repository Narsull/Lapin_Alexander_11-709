namespace Mazes
{
    public static class DiagonalMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {

        }

        public static void MoveRight(Robot robot, int width, int height)
        {
            int i = 1;
            if (width > height)
            {
                i = (height + width - 4) / height;
            }
            else
            {
                i = (height + width - 4) / width;
            }
            for (int a = 1; a <= i; i++)
            {
                robot.MoveTo(Direction.Right);
            }
        }

        public static void MoveDown(Robot robot, int width, int height)
        {
            {
                int i = 1;
                if (width > height)
                {
                    i = (height + width - 4) / height;
                }
                else
                {
                    i = (height + width - 4) / width;
                }
                for (int a = 1; a <= i; i++)
                {
                    robot.MoveTo(Direction.Right);
                }
            }
        }
    }
}