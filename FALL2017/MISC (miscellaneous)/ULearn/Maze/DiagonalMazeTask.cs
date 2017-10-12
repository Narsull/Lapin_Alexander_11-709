// Прошу прощения за костыли.
// В данный момент не мыслей о том, как от них избавиться.

using System;

namespace Mazes
{
    public static class DiagonalMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            height -= 2;
            width -= 2;
            int i;

            if (height / width == 1 && width / height == 0 || height / width == 0 && width / height == 1)
            {
                i = 1;

                for (int c = 1; c <= width; c++)
                {
                    MoveDown(robot, width, height, i, c);
                }
            }
            else if (height > width)
            {
                i = (height + width + 4) / (width + 2);

                for (int c = 1; c <= width; c++)
                {
                    MoveDown(robot, width, height, i, c);
                }
            }
            else
            {
                i = (height + width + 4) / (height + 2);

                for (int c = 1; c <= height; c++)
                {
                    MoveRight(robot, width, height, i, c);
                }
            }
        }

        public static void MoveRight(Robot robot, int width, int height, int i, int c)
        {
            for (int a = 0; a < i; a++)
                robot.MoveTo(Direction.Right);
            if (c < height)
                robot.MoveTo(Direction.Down);
        }

        public static void MoveDown(Robot robot, int width, int height, int i, int c)
        {
            for (int a = 0; a < i; a++)
                robot.MoveTo(Direction.Down);
            if (c < width)
                robot.MoveTo(Direction.Right);
        }
    }
}
