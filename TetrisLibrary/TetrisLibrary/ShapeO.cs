using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary
{

    public class ShapeO : Shape
    {
        public ShapeO(IBoard board) : base(board)
        {
            this.blocks[0] = new Block(board, Color.Yellow, new Point(4, 0));
            this.blocks[1] = new Block(board, Color.Yellow, new Point(5, 0));//origin
            this.blocks[2] = new Block(board, Color.Yellow, new Point(4, 1));
            this.blocks[3] = new Block(board, Color.Yellow, new Point(5, 1));

        }

        /// <summary>
        /// ShapeO doesn't rotate so there is no implementation.
        /// </summary>
        public override void Rotate()
        {
            //do nothing
        }
    }
}
