using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary
{
    public delegate void JoinPileHandler(IShape shape);
    public interface IShape
    {
        
        /// <summary>
        /// Length property for a shape.
        /// </summary>
        int Length
        {
            get;
        }

        /// <summary>
        /// Indexer for Block.
        /// </summary>
        /// <param name="i">Position of the Block</param>
        /// <returns>Block at position i.</returns>
        Block this[int i]
        {
            get;
        }

        event JoinPileHandler JoinPile;

        /// <summary>
        /// Move a Shape to the left.
        /// </summary>
        void MoveLeft();

        /// <summary>
        /// Move a Shape to the right.
        /// </summary>
        void MoveRight();

        /// <summary>
        /// Move a Shape down.
        /// </summary>
        void MoveDown();

        /// <summary>
        /// Drops a Shape to the bottom of the board
        /// or until it reaches another shape.
        /// </summary>
        void Drop();

        /// <summary>
        /// Rotates a shape by 90 degrees.
        /// </summary>
        void Rotate();

        /// <summary>
        /// Resets the shape to the initial position.
        /// </summary>
        void Reset();
        
        
    }
}
