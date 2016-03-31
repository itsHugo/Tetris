using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary
{
    /// <summary>
    /// The Shape Object implements the IShape interface.
    /// This is an abstract class that will be extended by 
    /// a more concrete class.  
    /// </summary>
    public abstract class Shape : IShape
    {   
        public event JoinPileHandler JoinPile;
        
        private IBoard board;
        protected Block[] blocks;
        protected Point[][] rotationOffset;
        protected int currentRotation;

        /// <summary>
        /// Constructor for Shape Object.
        /// Iniitializes the blocks array to a length of
        /// 4 blocks(Contains 4 block objects).
        /// </summary>
        /// <param name="board">Game board</param>
        public Shape(IBoard board)
        {
            this.board = board;
            blocks = new Block[4];
            currentRotation = 0;
        }

        /// <summary>
        /// Gets the number of blocks in the Shape.
        /// </summary>
        public int Length
        {
            get { return blocks.Length; }
        }

        /// <summary>
        /// Indexer for the Shape.
        /// </summary>
        /// <param name="i">Position of a Block in the Shape</param>
        /// <returns>Block Object</returns>
        public Block this[int i]
        {
            get { return blocks[i]; }
        }

        
        /// <summary>
        /// Moves every block in the Shape to the left.
        /// </summary>
        public void MoveLeft()
        {
            bool canMove = true;

            foreach (Block block in blocks)
            {
                if (block.TryMoveLeft() == false)
                    canMove = false;
            }

            if (canMove)
                foreach (Block block in blocks)
                    block.MoveLeft();
        }

        /// <summary>
        /// Moves every block in the Shape to the left.
        /// </summary>
        public void MoveRight()
        {
            bool canMove = true;

            foreach (Block block in blocks)
            {
                if (block.TryMoveRight() == false)
                    canMove = false;
            }

            if (canMove)
                foreach (Block block in blocks)
                    block.MoveRight();
        }

        /// <summary>
        /// Moves every block in the Shape down.
        /// </summary>
        public void MoveDown()
        {
            bool canMove = true;

            foreach (Block block in blocks)
            {
                if (block.TryMoveDown() == false)
                    canMove = false;
            }

            if (canMove)
                foreach (Block block in blocks)
                    block.MoveDown();
            else
                OnJoinPile();
        }

        /// <summary>
        /// Drops every block in the Shape until it hits 
        /// the bottom of the game board or on top 
        /// of an existing Shape in the game board.
        /// </summary>
        public void Drop()
        {
            bool canDrop = true;

            while(canDrop)
            {
                foreach (Block block in blocks)
                {
                    if (block.TryMoveDown() == false)
                        canDrop = false;
                }

                if (canDrop)
                    foreach (Block block in blocks)
                        block.MoveDown();
                else
                    OnJoinPile();
            }
        }

        abstract public void Rotate();

        /// <summary>
        /// Resets the current Shape's Block array to an empty array.
        /// </summary>
        public void Reset()
        {
            blocks = new Block[4];
        }

        protected void OnJoinPile()
        {
            if (JoinPile != null)
                JoinPile(this);
        }

    }
}
