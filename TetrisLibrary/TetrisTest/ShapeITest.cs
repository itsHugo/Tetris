using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisLibrary;
using Microsoft.Xna.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TetrisTest
{
    [TestClass]
    public class ShapeITest
    {
        [TestMethod]
        public void Rotate1()
        {
            Shape shapeI = new ShapeI(new FakeBoard());
            Point pos1 = new Point(3, 0);
            Point pos2 = new Point(4, 0);
            Point pos3 = new Point(5, 0);//origin
            Point pos4 = new Point(6, 0);

            shapeI.Rotate();
            //should not be able to rotate
            Assert.AreEqual(pos1 , shapeI[0].Position);
            Assert.AreEqual(pos2, shapeI[1].Position);
            Assert.AreEqual(pos3, shapeI[2].Position);
            Assert.AreEqual(pos4, shapeI[3].Position);
        }

        [TestMethod]
        public void Rotate2()
        {
            Shape shapeI = new ShapeI(new FakeBoard());
            Point pos1 = new Point(0, 0);
            Point pos2 = new Point(1, 0);
            Point pos3 = new Point(2, 0);//origin
            Point pos4 = new Point(3, 0);

            //move to the left border
            for (int i = 0; i < 5; i++)
                shapeI.MoveLeft();

            shapeI.Rotate();
            //should not be able to rotate
            Assert.AreEqual(pos1, shapeI[0].Position);
            Assert.AreEqual(pos2, shapeI[1].Position);
            Assert.AreEqual(pos3, shapeI[2].Position);
            Assert.AreEqual(pos4, shapeI[3].Position);
        }

        [TestMethod]
        public void Rotate_EnoughRoom1()
        {
            Shape shapeI = new ShapeI(new FakeBoard());
            Point pos1 = new Point(5, 3);
            Point pos2 = new Point(5, 2);
            Point pos3 = new Point(5, 1);//origin
            Point pos4 = new Point(5, 0);

            shapeI.MoveDown();
            shapeI.Rotate();
            //should be able to rotate
            Assert.AreEqual(pos1, shapeI[0].Position);
            Assert.AreEqual(pos2, shapeI[1].Position);
            Assert.AreEqual(pos3, shapeI[2].Position);
            Assert.AreEqual(pos4, shapeI[3].Position);
        }

        [TestMethod]
        public void Rotate_EnoughRoom2()
        {
            Shape shapeI = new ShapeI(new FakeBoard());
            Point pos1 = new Point(3, 1);
            Point pos2 = new Point(4, 1);
            Point pos3 = new Point(5, 1);//origin
            Point pos4 = new Point(6, 1);

            shapeI.MoveDown();
            //rotate 2 times
            for (int i = 0; i < 2; i++)
                shapeI.Rotate();

            //should be able to rotate and return to initial position
            Assert.AreEqual(pos1, shapeI[0].Position);
            Assert.AreEqual(pos2, shapeI[1].Position);
            Assert.AreEqual(pos3, shapeI[2].Position);
            Assert.AreEqual(pos4, shapeI[3].Position);
        }
    }
}
