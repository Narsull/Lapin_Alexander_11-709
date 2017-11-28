using System;
using System.Drawing;
using NUnit.Framework;

namespace Manipulation
{
    public static class AnglesToCoordinatesTask
    {
        public static PointF[] GetJointPositions(double shoulder, double elbow, double wrist)
        {
            float elbowPosX, elbowPosY, wristPosX, wristPosY, palmEndPosX, palmEndPosY;
            elbowPosX = (float)Math.Cos(shoulder) * Manipulator.UpperArm;
            elbowPosY = (float)Math.Sin(shoulder) * Manipulator.UpperArm;

            if (elbow <= 180)
            {
                wristPosX = (float)Math.Cos(elbow - (90 - shoulder)) * Manipulator.Forearm;
                wristPosY = (float)Math.Sin(elbow - (90 - shoulder)) * Manipulator.Forearm;

                if ()
                }
            else
            {
                wristPosX = (float)Math.Cos(elbow - (90 - shoulder)) * Manipulator.Forearm;
                wristPosY = (float)Math.Sin(elbow - (90 - shoulder)) * Manipulator.Forearm;
            }


            elbowPosX = -(float)Math.Cos(90 - (shoulder - 90)) * Manipulator.UpperArm;
            elbowPosY = (float)Math.Sin(90 - (shoulder - 90)) * Manipulator.UpperArm;

            if (elbow <= 180)
            {
                wristPosX = (float)Math.Cos(elbow - (90 - shoulder)) * Manipulator.Forearm;
                wristPosY = (float)Math.Sin(elbow - (90 - shoulder)) * Manipulator.Forearm;
            }
            else
            {
                wristPosX = (float)Math.Cos(elbow - (90 - shoulder)) * Manipulator.Forearm;
                wristPosY = (float)Math.Sin(elbow - (90 - shoulder)) * Manipulator.Forearm;
            }


            var elbowPos = new PointF(elbowPosX, elbowPosY);
            var wristPos = new PointF(wristPosX, wristPosY);
            var palmEndPos = new PointF(palmEndPosX, palmEndPosY);

            return new PointF[]
            {
                elbowPos,
                wristPos,
                palmEndPos
            };
        }
    }
    [TestFixture]
    public class AnglesToCoordinatesTask_Tests
    {
        // Доработайте эти тесты!
        // С помощью строчки TestCase можно добавлять новые тестовые данные. Аргументы TestCase превратятся в аргументы метода.
        [TestCase(Math.PI / 2, Math.PI / 2, Math.PI, Manipulator.Forearm + Manipulator.Palm, Manipulator.UpperArm)]
        public void TestGetJointPositions(double shoulder, double elbow, double wrist, double palmEndX, double palmEndY)
        {
            var joints = AnglesToCoordinatesTask.GetJointPositions(shoulder, elbow, wrist);
            Assert.AreEqual(palmEndX, joints[2].X, 1e-5, "palm endX");
            Assert.AreEqual(palmEndY, joints[2].Y, 1e-5, "palm endY");
            Assert.Fail("TODO: проверить, что расстояния между суставами равны длинам соответствующих сегментов манипулятора!");
        }

    }

}