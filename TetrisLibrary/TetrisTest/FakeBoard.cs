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
    /// Board stub
    /// Board at posititon (5, 5) has a block
    /// of color Blue instead of being blank(black)
    /// </summary>
    [TestClass]
    public class FakeBoard : IBoard
    {
        private Color[,] board;
        public FakeBoard()
        {
            //i
            board = new Color[20, 10];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = Color.Black;
                }
            }

            board[5, 5] = Color.Blue;
        }

        public IShape Shape
        {
            get { throw new NotImplementedException(); }
        }

        public Color this[int i, int j]
        {
            get { return board[i, j]; }
        }

        public int GetLength(int rank)
        {
            throw new NotImplementedException();
        }

        public event LinesClearedHandler LinesCleared;

        public event GameOverHandler GameOver;
    }
}
