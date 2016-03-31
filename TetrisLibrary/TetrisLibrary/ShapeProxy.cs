using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary
{
    /// <summary>
    /// Proxy for creating various new Shapes for the 
    /// game board. 
    /// </summary>
    public class ShapeProxy : IShapeFactory, IShape
    {
        public event JoinPileHandler JoinPile;
        private Random random;
        private IShape current;
        private IBoard board;

        public IShape Shape
        {
            get { return current; }
        }

        public ShapeProxy(IBoard board)
        {
            this.board = board;
            random = new Random();
            JoinPile += OnJoinPile;
        }

        public void DeployNewShape()
        {
            int randomNumber = random.Next(1, 8);
            
            switch(randomNumber)
            {
                case 1:
                    current = new ShapeI(board);
                    break;
                case 2:
                    current = new ShapeL(board);
                    break;
                case 3:
                    current = new ShapeO(board);
                    break;
                case 4:
                    current = new ShapeS(board);
                    break;
                case 5:
                    current = new ShapeT(board);
                    break;
                case 6:
                    current = new ShapeZ(board);
                    break;
                case 7:
                    current = new ShapeJ(board);
                    break;
            }

            
        }

        public int Length
        {
            get { return current.Length; }
        }

        public Block this[int i]
        {
            get { return current[i]; }
        }

        protected void OnJoinPile(IShape shape)
        {
            if (JoinPile != null)
            {
                JoinPile(this);
            }
                
        }

        public void MoveLeft()
        {
            current.MoveLeft();
        }

        public void MoveRight()
        {
            current.MoveRight();
        }

        public void MoveDown()
        {
            current.MoveDown();
        }

        public void Drop()
        {
            current.Drop();
        }

        public void Rotate()
        {
            current.Rotate();
        }

        public void Reset()
        {
            current.Reset();
        }
    }
}
