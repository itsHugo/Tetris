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
    /// <summary>
    /// For this test class, the game board will be 
    /// an instance of FakeBoard. 
    /// </summary>
    [TestClass]
    public class BlockTest
    {
        [TestMethod]
        public void MoveRight_EnoughRoom()
        {
            Block block = new Block(new FakeBoard(), Color.Yellow, new Point(5, 0));

            Assert.AreEqual(true, block.TryMoveRight());
        }

        [TestMethod]
        public void MoveRight_NoRoom()
        {
            Block block = new Block(new FakeBoard(), Color.Yellow, new Point(9, 0));

            Assert.AreEqual(false, block.TryMoveRight());
        }

        [TestMethod]
        public void MoveRight_NextToBlock()
        {
            Block block = new Block(new FakeBoard(), Color.Yellow, new Point(4, 5));
            //obstructing block is at position (5, 5)

            Assert.AreEqual(false, block.TryMoveRight());
        }
        
        [TestMethod]
        public void MoveLeft_EnoughRoom()
        {
            Block block = new Block(new FakeBoard(), Color.Yellow, new Point(5, 0));

            Assert.AreEqual(true, block.TryMoveLeft());
        }

        [TestMethod]
        public void MoveLeft_NoRoom()
        {
            Block block = new Block(new FakeBoard(), Color.Yellow, new Point(0, 0));

            Assert.AreEqual(false, block.TryMoveLeft());
        }

        [TestMethod]
        public void MoveLeft_NextToBlock()
        {
            //new block at position (5, 6)
            Block block = new Block(new FakeBoard(), Color.Yellow, new Point(6, 5));
            //obstructing block is at position (5, 5)

            Assert.AreEqual(false, block.TryMoveLeft());
        }

        [TestMethod]
        public void MoveDown_EnoughRoom()
        {
            Block block = new Block(new FakeBoard(), Color.Yellow, new Point(5, 0));

            Assert.AreEqual(true, block.TryMoveDown());
        }

        [TestMethod]
        public void MoveDown_NoRoom()
        {
            Block block = new Block(new FakeBoard(), Color.Yellow, new Point(0, 19));

            Assert.AreEqual(false, block.TryMoveDown());
        }


        [TestMethod]
        public void MoveDown_BlockBelow()
        {
            //new block at position (5, 4)
            Block block = new Block(new FakeBoard(), Color.Yellow, new Point(5, 4));
            //obstructing block at position (5, 5)

            //block's Y coordinate should be the same
            Assert.AreEqual(false, block.TryMoveDown());

        }

        [TestMethod]
        public void Rotate_SamePosition()
        {
            Point offset = new Point(0, 0);
            Block block = new Block(new FakeBoard(), Color.Yellow, new Point(5, 10));

            block.Rotate(offset);

            Assert.AreEqual(true, (block.Position.X == 5 && block.Position.Y == 10));
        }

        [TestMethod]
        public void Rotate_DifferentOffset1()
        {
            Point offset = new Point(1, 0);
            Block block = new Block(new FakeBoard(), Color.Yellow, new Point(5, 10));

            block.Rotate(offset);

            Assert.AreEqual(true, (block.Position.X == 4 && block.Position.Y == 9));
        }

        

        [TestMethod]
        public void Rotate_DifferentOffset2()
        {
            Point offset = new Point(1, 1);
            Block block = new Block(new FakeBoard(), Color.Yellow, new Point(5, 10));

            block.Rotate(offset);

            Assert.AreEqual(true, (block.Position.X == 3 && block.Position.Y == 10));
        }

        [TestMethod]
        public void Rotate_OccupiedBlock()
        {
            Point offset = new Point(1, 0);
            Block block = new Block(new FakeBoard(), Color.Yellow, new Point(6, 6));

            //new block position should be at (5, 5)
            //at position (5, 5) there is already a black of color blue
            Assert.AreEqual(false, block.TryRotate(offset));
        }

        [TestMethod]
        public void Rotate_AtBorder()
        {
            Point offset = new Point(1, 1);
            Block block = new Block(new FakeBoard(), Color.Yellow, new Point(0, 0));


            //new block position should be at (-2, 0)
            //X position is < than 0 (the left border)
            Assert.AreEqual(false, block.TryRotate(offset));
        }
    }
}
