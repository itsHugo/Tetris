﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary
{
    public class ShapeZ : Shape
    {
        public ShapeZ(IBoard board) : base(board)
        {
            this.blocks[0] = new Block(board, Color.Red, new Point(4, 0));
            this.blocks[1] = new Block(board, Color.Red, new Point(5, 0));//origin
            this.blocks[2] = new Block(board, Color.Red, new Point(5, 1));
            this.blocks[3] = new Block(board, Color.Red, new Point(6, 1));

            rotationOffset = new Point[2][];
            rotationOffset[0] = new Point[] { new Point(-1, 0), new Point(0, 0), new Point(0, -1), new Point(1, -1) };
            //rotationOffset[1] = new Point[] { new Point(0, -1), new Point(0, 0), new Point(1, 0), new Point(1, 1) };
            rotationOffset[1] = new Point[] { new Point(1, 0), new Point(0, 0), new Point(0, 1), new Point(-1, 1) };
        }
        public override void Rotate()
        {
            if (currentRotation > 1)
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
