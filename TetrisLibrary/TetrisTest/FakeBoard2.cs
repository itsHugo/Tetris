using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisLibrary;
using Microsoft.Xna.Framework;

namespace TetrisTest
{
    class FakeBoard2 : IBoard
    {
         private Color[,] board;
        private IShape shape;
        private IShapeFactory shapeFactory;
        public event LinesClearedHandler LinesCleared;
        public event GameOverHandler GameOver;

        /// <summary>
        /// Creates the board and fills its elements with the color black,
        /// which represents empty spaces for the blocks.
        /// </summary>
        /// <param name="LinesCleared"></param>
        /// <param name="GameOver"></param>
        public FakeBoard2()
        {
            board = new Color[20, 10];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = Color.Black;
                }
            }

          shapeFactory = new ShapeProxy(this);
          shapeFactory.DeployNewShape();
          shape = shapeFactory.Shape;
            
          shape.JoinPile += addToPile;
        }

        public IShape Shape
        {
            get { return shape; }
            //manually set shape for testing purposes
            set { shape = value; }
        }

        /// <summary>
        /// Indexer for the Board. Retrieves the color at the specified position.
        /// </summary>
        /// <param name="i">Rows</param>
        /// <param name="j">Columns</param>
        /// <returns></returns>
        public Color this[int i, int j]
        {
            get { return board[i, j]; }
            set { board[i, j] = value; }
        }


        /// <summary>
        /// Returns the length of a row in the board
        /// </summary>
        /// <param name="rank">The row</param>
        /// <returns></returns>
        public int GetLength(int rank)
        {
            return board.GetLength(rank);
        }

        /// <summary>
        ///  Fires an event to clear lines.
        /// </summary>
        /// <param name="Lines">Number of lines that are cleared.</param>

        protected virtual void onLinesCleared(int lines)
        {
            if (LinesCleared != null)
            {
                LinesCleared(lines);
            }
        }

        /// <summary>
        ///  Fires an event to end the best game ever.
        /// </summary>
        protected virtual void onGameOver()
        {
            if (GameOver != null)
            {
                GameOver();
            }
        }
        /// <summary>
        ///  Add a shape to the pile.
        /// </summary>
        private void addToPile(IShape shape)
        {
            for (int i = 0; i < shape.Length; i++)
            {
                board[shape[i].Position.Y, shape[i].Position.X] = shape[i].Color;
            }

            shapeFactory.DeployNewShape();
            this.shape = shapeFactory.Shape;
            this.shape.JoinPile += addToPile;
            //checkFullRows();


            gameOver();
        }

        /// <summary>
        ///  Finish the game if there are no more place.
        /// </summary>
        private void gameOver()
        {
            bool placable = true;

            for (int i = 0; i < shape.Length; i++)
            {
                if (!board[shape[i].Position.Y, shape[i].Position.X].Equals(Color.Black))
                    placable = false;
            }

            if (!placable)
                onGameOver();
        }

        /// <summary>
        ///  Check if they're any lines to clear.
        /// </summary>
        public int checkFullRows(FakeBoard2 board)
        {
            int completeLines = 0;
            int rowNum = 20, colNum = 10, col, row;


            for (row = 0; row < rowNum; row++)
            {
                for (col = 0; col < colNum; col++)
                {
                    if (board[row, col] == Color.Black)
                        break;
                }

                if (col == 10)
                {
                    //clearLines(row);
                    completeLines++;
                }

            }
            if (completeLines != 0)
            {
                onLinesCleared(completeLines);
            }
            return completeLines;

        }

        /// <summary>
        ///  Clear the lines.
        /// </summary>
        private void clearLines(int row)
        {
            for (int i = row; i > 0; i--)
            {
                for (int j = 9; j >= 0; j--)
                {
                    board[i, j] = board[i - 1, j];
                }
            }

        }

    }
}
