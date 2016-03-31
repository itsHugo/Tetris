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
    public class ShapeTTest
    {
        [TestMethod]
        public void MoveDown_EnoughRoom()
        {
            Shape shapeT = new ShapeT(new FakeBoard());
            Point pos1 = new Point(4, 1);
            Point pos2 = new Point(5, 1);//origin
            Point pos3 = new Point(6, 1);
            Point pos4 = new Point(5, 2);

            //move to the left border
            shapeT.MoveDown();

            //should be able to move
            Assert.AreEqual(pos1, shapeT[0].Position);
            Assert.AreEqual(pos2, shapeT[1].Position);
            Assert.AreEqual(pos3, shapeT[2].Position);
            Assert.AreEqual(pos4, shapeT[3].Position);
        }

        [TestMethod]
        public void MoveDown_BlockBelow()
        {
            Shape shapeT = new ShapeT(new FakeBoard());
            Point pos1 = new Point(4, 3);
            Point pos2 = new Point(5, 3);//origin
            Point pos3 = new Point(6, 3);
            Point pos4 = new Point(5, 4);

            //move to the left border
            for (int i = 0; i < 5; i++)
                shapeT.MoveDown();

            //should not be able to move
            Assert.AreEqual(pos1, shapeT[0].Position);
            Assert.AreEqual(pos2, shapeT[1].Position);
            Assert.AreEqual(pos3, shapeT[2].Position);
            Assert.AreEqual(pos4, shapeT[3].Position);
        }

        [TestMethod]
        public void Rotate1()
        {
            Shape shapeT = new ShapeT(new FakeBoard());
            Point pos1 = new Point(4, 0);
            Point pos2 = new Point(5, 0);//origin
            Point pos3 = new Point(6, 0);
            Point pos4 = new Point(5, 1);

            shapeT.Rotate();
            //should not be able to rotate
            Assert.AreEqual(pos1 , shapeT[0].Position);
            Assert.AreEqual(pos2, shapeT[1].Position);
            Assert.AreEqual(pos3, shapeT[2].Position);
            Assert.AreEqual(pos4, shapeT[3].Position);
        }

        [TestMethod]
        public void Rotate2()
        {
            Shape shapeT = new ShapeT(new FakeBoard());
            Point pos1 = new Point(0, 0);
            Point pos2 = new Point(1, 0);//origin
            Point pos3 = new Point(2, 0);
            Point pos4 = new Point(1, 1);

            //move to the left border
            for (int i = 0; i < 5; i++)
                shapeT.MoveLeft();

            shapeT.Rotate();
            //should not be able to rotate
            Assert.AreEqual(pos1, shapeT[0].Position);
            Assert.AreEqual(pos2, shapeT[1].Position);
            Assert.AreEqual(pos3, shapeT[2].Position);
            Assert.AreEqual(pos4, shapeT[3].Position);
        }

        [TestMethod]
        public void Rotate_EnoughRoom1()
        {
            Shape shapeT = new ShapeT(new FakeBoard());
            Point pos1 = new Point(5, 2);
            Point pos2 = new Point(5, 1);//origin
            Point pos3 = new Point(5, 0);
            Point pos4 = new Point(6, 1);

            shapeT.MoveDown();
            shapeT.Rotate();

            //should be able to rotate
            Assert.AreEqual(pos1, shapeT[0].Position);
            Assert.AreEqual(pos2, shapeT[1].Position);
            Assert.AreEqual(pos3, shapeT[2].Position);
            Assert.AreEqual(pos4, shapeT[3].Position);
        }

        [TestMethod]
        public void Rotate_EnoughRoom2()
        {
            Shape shapeT = new ShapeT(new FakeBoard());
            Point pos1 = new Point(4, 1);
            Point pos2 = new Point(5, 1);//origin
            Point pos3 = new Point(6, 1);
            Point pos4 = new Point(5, 2);

            shapeT.MoveDown();
            //rotate 4 times
            for (int i = 0; i < 4; i++)
                shapeT.Rotate();

            //should be able to rotate and return to initial position
            Assert.AreEqual(pos1, shapeT[0].Position);
            Assert.AreEqual(pos2, shapeT[1].Position);
            Assert.AreEqual(pos3, shapeT[2].Position);
            Assert.AreEqual(pos4, shapeT[3].Position);
        }

        [TestMethod]
        public void Drop_ToBlock()
        {
            Shape shapeT = new ShapeT(new FakeBoard());

            shapeT.Drop();

            //lowest block of the Shape should be at position(5, 4) 
            //There is a block at position(5,5) that will block it
            Assert.AreEqual(4, shapeT[3].Position.Y);
        }

        [TestMethod]
        public void Drop_ToBottom()
        {
            Shape shapeT = new ShapeT(new FakeBoard());

            //Moves the shape as far to the right as possible before dropping
            for (int i = 0; i < 5; i++)
                shapeT.MoveRight();

            shapeT.Drop();

            //shape should reach the bottom(X, 19)
            Assert.AreEqual(19, shapeT[3].Position.Y);
        }
    }
}
