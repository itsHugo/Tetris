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
    public class BoardyTest 
    {
        [TestMethod]
        public void check1LineDown()
        {
            FakeBoard2 fBoard = new FakeBoard2();
            FakeBoard2 fB = new FakeBoard2();

            for (int i = 0; i < 10; i++)
            {
                fBoard[0, i] = Color.Fuchsia;
            }

            int numOfRows = fB.checkFullRows(fBoard);

            Assert.AreEqual(numOfRows, 1);

        }
        [TestMethod]
        public void check2LineDown()
        {
            FakeBoard2 fBoard = new FakeBoard2();
            FakeBoard2 fB = new FakeBoard2();

            for (int i = 0; i < 10; i++)
            {
                fBoard[0, i] = Color.Fuchsia;
            }

            for (int i = 0; i < 10; i++)
            {
                fBoard[1, i] = Color.Fuchsia;
            }

            int numOfRows = fB.checkFullRows(fBoard);

            Assert.AreEqual(numOfRows, 2);

        }
        [TestMethod]
        public void check3LineDown()
        {
            FakeBoard2 fBoard = new FakeBoard2();
            FakeBoard2 fB = new FakeBoard2();

            for (int i = 0; i < 10; i++)
            {
                fBoard[0, i] = Color.Fuchsia;
            }

            for (int i = 0; i < 10; i++)
            {
                fBoard[1, i] = Color.Fuchsia;
            }

            for (int i = 0; i < 10; i++)
            {
                fBoard[2, i] = Color.Fuchsia;
            }

            int numOfRows = fB.checkFullRows(fBoard);

            Assert.AreEqual(numOfRows, 3);

        }
        [TestMethod]
        public void check4LineDown()
        {
            FakeBoard2 fBoard = new FakeBoard2();
            FakeBoard2 fB = new FakeBoard2();

            for (int i = 0; i < 10; i++)
            {
                fBoard[0, i] = Color.Fuchsia;
            }

            for (int i = 0; i < 10; i++)
            {
                fBoard[1, i] = Color.Fuchsia;
            }

            for (int i = 0; i < 10; i++)
            {
                fBoard[2, i] = Color.Fuchsia;
            }

            for (int i = 0; i < 10; i++)
            {
                fBoard[3, i] = Color.Fuchsia;
            }

            int numOfRows = fB.checkFullRows(fBoard);

            Assert.AreEqual(numOfRows, 4);

        }

        [TestMethod]
        public void check1LineUp()
        {
            FakeBoard2 fBoard = new FakeBoard2();
            FakeBoard2 fB = new FakeBoard2();

            for (int i = 0; i < 10; i++)
            {
                fBoard[6, i] = Color.Fuchsia;
            }

            int numOfRows = fB.checkFullRows(fBoard);

            Assert.AreEqual(numOfRows, 1);

        }

        [TestMethod]
        public void deployShapeTest()
        {
            FakeBoard2 fB = new FakeBoard2();

            IShape shape = fB.Shape;

            shape.GetType().ToString();
        }
    }
}
