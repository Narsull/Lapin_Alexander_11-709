using System;

namespace Mazes
{
    public static class DiagonalMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            if (height > width)
                MoveDown(robot, width, height);
            else
                MoveRight(robot, width, height);
        }

        public static void MoveRight(Robot robot, int width, int height)
        {
            double i = 1;
            if (width > height)
            {
                i = (double)(height + width) / height;
                i = Math.Round(i);
            }
            else
            {
                i = (double)(height + width) / width;
                i = Math.Round(i);
            }
            for (int a = 1; a <= i; a++)
            {
                robot.MoveTo(Direction.Right);
                {

                    i = 1;
                    if (height > width)
                    {
                        i = (double)(height + width) / width;
                        i = Math.Round(i);
                    }
                    else
                    {
                        i = (double)(height + width) / height;
                        i = Math.Round(i);
                    }
                    for (a = 1; a <= i; a++)
                    {
                        robot.MoveTo(Direction.Down);
                    }
                }
            }
        }

        public static void MoveDown(Robot robot, int width, int height)
        {

            double i = 1;
            if (height > width)
            {
                i = (double)(height + width - 4) / width;
                i = Math.Round(i);
            }
            else
            {
                i = (double)(height + width - 4) / height;
                i = Math.Round(i);
            }
            for (int a = 1; a <= i; a++)
            {
                robot.MoveTo(Direction.Down);
                {
                    i = 1;
                    if (width > height)
                    {
                        i = (double)(height + width - 4) / height;
                        i = Math.Round(i);
                    }
                    else
                    {
                        i = (double)(height + width - 4) / width;
                        i = Math.Round(i);
                    }
                    for (a = 1; a <= i; a++)
                    {
                        robot.MoveTo(Direction.Right);
                    }
                }
            }

        }
    }
}