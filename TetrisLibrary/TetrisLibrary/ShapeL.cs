﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary
{
    public class ShapeL : Shape
    {
        public ShapeL(IBoard board) : base(board)
        {
            this.blocks[0] = new Block(board, Color.Orange, new Point(4, 0));
            this.blocks[1] = new Block(board, Color.Orange, new Point(5, 0));//origin
            this.blocks[2] = new Block(board, Color.Orange, new Point(6, 0));
            this.blocks[3] = new Block(board, Color.Orange, new Point(4, 1));

            rotationOffset = new Point[4][];
            rotationOffset[0] = new Point[] { new Point(-1, 0), new Point(0, 0), new Point(1, 0), new Point(-1, -1) };
            rotationOffset[1] = new Point[] { new Point(0, -1), new Point(0, 0), new Point(0, 1), new Point(1, -1) };
            rotationOffset[2] = new Point[] { new Point(1, 0), new Point(0, 0), new Point(-1, 0), new Point(1, 1) };
            rotationOffset[3] = new Point[] { new Point(0, 1), new Point(0, 0), new Point(0, -1), new Point(-1, 1) };
        }
        public override void Rotate()
        {
            if (currentRotation > 3)
                currentRotation = 0;

            bool canRotate = true;
            int cntr = 0;
            foreach (Block block in blocks)
            {
                if (block.TryRotate(rotationOffset[currentRotation][cntr]) == false)
                    canRotate = false;
                cntr++;
            }

            if (canRotate)
            {
                cntr = 0;
                foreach (Block block in blocks)
                {
                    block.Rotate(rotationOffset[currentRotation][cntr]);
                    cntr++;
                }
                currentRotation++;
            }
        }
    }
}
