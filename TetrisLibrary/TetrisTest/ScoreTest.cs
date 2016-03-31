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
    public class ScoreTest
    {
        [TestMethod]
        public void TestIncrementLines1()
        {
            FakeBoard2 board = new FakeBoard2();
            FakeBoard2 fB = new FakeBoard2();

            ScoryTest score = new ScoryTest();
            
            for (int i = 0; i < 10; i++)
            {
                
                board[2, i] = Color.Fuchsia;
            }


            int numOfRows = fB.checkFullRows(board);

            score.incrementLinesCleared(numOfRows);

            Assert.AreEqual(1, score.Lines);
            

        }

        [TestMethod]
        public void TestIncrementLines2()
        {
            FakeBoard2 board = new FakeBoard2();
            FakeBoard2 fB = new FakeBoard2();

            ScoryTest score = new ScoryTest();

            for (int i = 0; i < 10; i++)
            {
                board[0, i] = Color.Fuchsia;
            }

            for (int i = 0; i < 10; i++)
            {
                board[1, i] = Color.Fuchsia;
            }


            int numOfRows = fB.checkFullRows(board);

            score.incrementLinesCleared(numOfRows);

            Assert.AreEqual(2, score.Lines);
             

        }

        public void TestIncrementLines3()
        {
            FakeBoard2 board = new FakeBoard2();
            FakeBoard2 fB = new FakeBoard2();

            ScoryTest score = new ScoryTest();

            for (int i = 0; i < 10; i++)
            {
                board[0, i] = Color.Fuchsia;
            }

            for (int i = 0; i < 10; i++)
            {
                board[1, i] = Color.Fuchsia;
            }

            for (int i = 0; i < 10; i++)
            {
                board[2, i] = Color.Fuchsia;
            }


            int numOfRows = fB.checkFullRows(board);

            score.incrementLinesCleared(numOfRows);

            Assert.AreEqual(3, score.Lines);


        }

        public void TestIncrementLines4()
        {
            FakeBoard2 board = new FakeBoard2();
            FakeBoard2 fB = new FakeBoard2();

            ScoryTest score = new ScoryTest();

            for (int i = 0; i < 10; i++)
            {
                board[0, i] = Color.Fuchsia;
            }

            for (int i = 0; i < 10; i++)
            {
                board[1, i] = Color.Fuchsia;
            }

            for (int i = 0; i < 10; i++)
            {
                board[2, i] = Color.Fuchsia;
            }

            for (int i = 0; i < 10; i++)
            {
                board[3, i] = Color.Fuchsia;
            }


            int numOfRows = fB.checkFullRows(board);

            score.incrementLinesCleared(numOfRows);

            Assert.AreEqual(4, score.Lines);


        }

        [TestMethod]
        public void TestPoints1()
        {
            FakeBoard2 board = new FakeBoard2();
            FakeBoard2 fB = new FakeBoard2();

            ScoryTest score = new ScoryTest();

            for (int i = 0; i < 10; i++)
            {

                board[2, i] = Color.Fuchsia;
            }


            int numOfRows = fB.checkFullRows(board);

            score.incrementLinesCleared(numOfRows);

            Assert.AreEqual(100, score.Points);


        }
        [TestMethod]
        public void TestPoints2()
        {
            FakeBoard2 board = new FakeBoard2();
            FakeBoard2 fB = new FakeBoard2();

            ScoryTest score = new ScoryTest();

            for (int i = 0; i < 10; i++)
            {

                board[0, i] = Color.Fuchsia;
            }

            for (int i = 0; i < 10; i++)
            {

                board[1, i] = Color.Fuchsia;
            }


            int numOfRows = fB.checkFullRows(board);

            score.incrementLinesCleared(numOfRows);

            Assert.AreEqual(200, score.Points);


        }
        [TestMethod]
        public void TestPoints3()
        {
            FakeBoard2 board = new FakeBoard2();
            FakeBoard2 fB = new FakeBoard2();

            ScoryTest score = new ScoryTest();

            for (int i = 0; i < 10; i++)
            {

                board[0, i] = Color.Fuchsia;
            }

            for (int i = 0; i < 10; i++)
            {

                board[1, i] = Color.Fuchsia;
            }

            for (int i = 0; i < 10; i++)
            {

                board[2, i] = Color.Fuchsia;
            }

            int numOfRows = fB.checkFullRows(board);

            score.incrementLinesCleared(numOfRows);

            Assert.AreEqual(300, score.Points);


        }

        [TestMethod]
        public void TestPoints4()
        {
            FakeBoard2 board = new FakeBoard2();
            FakeBoard2 fB = new FakeBoard2();

            ScoryTest score = new ScoryTest();

            for (int i = 0; i < 10; i++)
            {

                board[0, i] = Color.Fuchsia;
            }

            for (int i = 0; i < 10; i++)
            {

                board[1, i] = Color.Fuchsia;
            }

            for (int i = 0; i < 10; i++)
            {

                board[2, i] = Color.Fuchsia;
            }

            for (int i = 0; i < 10; i++)
            {

                board[3, i] = Color.Fuchsia;
            }

            int numOfRows = fB.checkFullRows(board);

            score.incrementLinesCleared(numOfRows);

            Assert.AreEqual(800, score.Points);


        }

        [TestMethod]
        public void TestLevel1()
        {
            FakeBoard2 board = new FakeBoard2();
            FakeBoard2 fB = new FakeBoard2();

            ScoryTest score = new ScoryTest();

            for (int i = 0; i < 10; i++)
            {

                board[2, i] = Color.Fuchsia;
            }


            int numOfRows = fB.checkFullRows(board);

            score.incrementLinesCleared(numOfRows);

            Assert.AreEqual(1, score.Level);


        }

        public void TestLevel2()
        {
            FakeBoard2 board = new FakeBoard2();
            FakeBoard2 fB = new FakeBoard2();

            ScoryTest score = new ScoryTest();

            
            score.Lines = 10;

            Assert.AreEqual(2, score.Level);


        }

        public void TestLevel5()
        {
            FakeBoard2 board = new FakeBoard2();
            FakeBoard2 fB = new FakeBoard2();

            ScoryTest score = new ScoryTest();


            score.Lines = 50;

            Assert.AreEqual(5, score.Level);


        }

        public void TestLevel9()
        {
            FakeBoard2 board = new FakeBoard2();
            FakeBoard2 fB = new FakeBoard2();

            ScoryTest score = new ScoryTest();


            score.Lines = 90;

            Assert.AreEqual(9, score.Level);


        }
       

    }
}
