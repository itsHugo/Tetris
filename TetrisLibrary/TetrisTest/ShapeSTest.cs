using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TetrisLibrary;
using Microsoft.Xna.Framework;

namespace TetrisTest
{
    [TestClass]
    public class ShapeSTest
    {
        [TestMethod]
        public void Rotate_EnoughRoom1()
        {
            Shape shape = new ShapeS(new FakeBoard());
            Point pos1 = new Point(5, 1);//origin
            Point pos2 = new Point(5, 0);
            Point pos3 = new Point(6, 2);
            Point pos4 = new Point(6, 1);

            shape.MoveDown();
            shape.Rotate();
            //should be able to rotate
            Assert.AreEqual(pos1, shape[0].Position);
            Assert.AreEqual(pos2, shape[1].Position);
            Assert.AreEqual(pos3, shape[2].Position);
            Assert.AreEqual(pos4, shape[3].Position);
        }

        [TestMethod]
        public void Rotate_EnoughRoom2()
        {
            Shape shape = new ShapeS(new FakeBoard());
            Point pos1 = new Point(5, 1);//origin
            Point pos2 = new Point(6, 1);
            Point pos3 = new Point(4, 2);
            Point pos4 = new Point(5, 2);

            shape.MoveDown();
            //rotate 2 times
            for (int i = 0; i < 2; i++)
                shape.Rotate();

            //should be able to rotate and return to initial position
            Assert.AreEqual(pos1, shape[0].Position);
            Assert.AreEqual(pos2, shape[1].Position);
            Assert.AreEqual(pos3, shape[2].Position);
            Assert.AreEqual(pos4, shape[3].Position);
        }


    }
}
