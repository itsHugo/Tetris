using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary
{
    public interface IShapeFactory
    {
        IShape Shape
        {
            get;
        }

        /// <summary>
        /// Creates a new Tetris shape randomly.
        /// </summary>
        void DeployNewShape();
    }
}
