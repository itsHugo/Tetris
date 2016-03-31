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
    class BoardTest
    {
        [TestMethod]
        public void clear1LineDown()
        {
            FakeBoard2 fBoard = new FakeBoard2();
            FakeBoard2 fB = new FakeBoard2();

            for(int i=0;i< 10;i++)
            {
                fBoard[0, i] = Color.Fuchsia;
            }

            int numOfRows = fB.checkFullRows(fBoard);

            Assert.AreEqual(numOfRows, 1);

        }

        public void clear2LineDown()
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

        public void clear3LineDown()
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

        public void clear4LineDown()
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

            Assert.AreEqual(numOfRows, 3);

        }
    }
}
