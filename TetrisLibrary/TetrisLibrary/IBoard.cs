using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary
{
    public delegate void LinesClearedHandler(int lines);
    public delegate void GameOverHandler();

    public interface IBoard
    {
        /// <summary>
        /// Shape constructor with 
        /// a get parameter.
        /// </summary>
        IShape Shape
        {
            get;
        }

        /// <summary>
        /// Color indexer.
        /// </summary>
        /// <param name="i">Row</param>
        /// <param name="j">Column</param>
        /// <returns></returns>
        Color this[int i, int j]
        {
            get;
        }

        int GetLength(int rank);

        //Event handlers
        event LinesClearedHandler LinesCleared;
        event GameOverHandler GameOver;
        
    }
}
