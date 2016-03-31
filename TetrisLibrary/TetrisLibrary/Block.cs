using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary
{
    /// <summary>
    /// A block is an element inside the game board.
    /// Each block in the game board can be empty or
    /// be occupied by a shape. A Tetris shape is also 
    /// composed of blocks. 
    /// </summary>
    public class Block
    {
        //private members
        private IBoard board;
        private Color color;
        private Point position;

        /// <summary>
        /// Block constructor.
        /// </summary>
        public Block(IBoard board, Color color, Point position)
        {
            this.board = board;
            this.color = color;
            this.position = position;
        }

        //Color property
        public Color Color
        { get { return color; } }

        //Point property
        public Point Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        /// <summary>
        /// This method tries to move a block
        /// to the left. It checks if the move
        /// is correct or not. If correct, moves the block.
        /// </summary>
        /// <returns>True if the move is possible
        /// False if the move is not possible</returns>
        public bool TryMoveLeft()
        {
            //checks if block is at the left border(X of 0)
            if(position.X > 0)
                //checks the color of the board next to the block
                if (board[position.Y, position.X - 1].Equals(Color.Black))
                {
                    //if black, return true
                    return true;
                }
            //cannot move; return false
            return false;
        }
        /// <summary>
        /// This method tries to move a block
        /// to the right. It checks if the move
        /// is correct or not. If correct, moves the block.
        /// </summary>
        /// <returns>True if the move is possible
        /// False if the move is not possible</returns>
        public bool TryMoveRight()
        {
            //checks if block is at the right border(X of 9)
            if(position.X < 9)
                //checks the color of the board next to the block
                if (board[position.Y, position.X + 1].Equals(Color.Black))
                {
                    //if black, return true
                    return true;
                }

            return false;
        }
        /// <summary>
        /// This method tries to move a block
        /// down. It checks if the move
        /// is correct or not. If correct, moves the block.
        /// </summary>
        /// <returns>True if the move is possible
        /// False if the move is not possible</returns>
        public bool TryMoveDown()
        {
            //checks if block is at the bottom border(Y of 19)
            if(position.Y < 19)
                //checks the color of the board next to the block
                if(board[position.Y + 1, position.X].Equals(Color.Black))
                {
                    //if black, return true
                    return true;
                }
                
            return false;
        }

        /// <summary>
        /// Tries to rotate a block 
        /// based on a offset.
        /// 
        /// </summary>
        /// <param name="offset">Offset of a block</param>
        public bool TryRotate(Point offset)
        {
            Point newPosition;
            newPosition.X = -(offset.X + offset.Y - this.position.X);
            newPosition.Y = -(offset.X - offset.Y + -(this.position.Y));
            
            //checks if new positions of the block is inside the board
            if(newPosition.X >= 0 && newPosition.X <= 9 && newPosition.Y >= 0 && newPosition.Y <= 19 )
                //checks the color of the board for the new positions
                if(board[newPosition.Y, newPosition.X].Equals(Color.Black))
                {
                    //if black, return true
                    return true;
                }
            //else false
            return false;
            
        }

        /// <summary>
        /// Moves a block to the left by a value of 1.
        /// </summary>
        public void MoveLeft()
        {
            position.X = MathHelper.Clamp(position.X - 1, 0, 9);
        }

        /// <summary>
        /// Moves a block to the right by a value of 1.
        /// </summary>
        public void MoveRight()
        {
            position.X = MathHelper.Clamp(position.X + 1, 0, 9);
        }

        /// <summary>
        /// Moves a block down by a value of 1.
        /// Checks on the board if the space below the block is free(Black).
        /// </summary>
        public void MoveDown()
        {
            position.Y = MathHelper.Clamp(position.Y + 1, 0, 19);
        }

        /// <summary>
        /// Rotates a block based on a offset.
        /// The offset represents the block based on
        /// the origin position, which is (0,0)
        /// </summary>
        /// <param name="offset">Offset of the block</param>
        public void Rotate(Point offset)
        {
            Point newPosition;
            newPosition.X = -(offset.X + offset.Y - this.position.X);
            newPosition.Y = -(offset.X - offset.Y + -(this.position.Y));
            
            this.Position = newPosition;
        }


    }
}
