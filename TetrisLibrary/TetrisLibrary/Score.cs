using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLibrary
{
    /// <summary>
    /// Score class observes IBoard
    /// 
    /// Keeps track of the level, lines and score
    /// of the ongoing game.
    /// </summary>
    public class Score
    {
        private int level;
        private int lines;
        private int points;

        //Properties
        public int Level
        {
            get
            {
                return level;
            }

        }

        public int Lines
        {
            get { return lines; }

        }

        public int Points
        {
            get { return points; }
        }


        public Score(IBoard aBoard)
        {
            level = 1;
            lines = 0;
            points = 0;
            aBoard.LinesCleared += new LinesClearedHandler(incrementLinesCleared);
        }

        /// <summary>
        /// Score class observes IBoard
        /// 
        /// Keeps track of the level, lines and score
        /// of the ongoing game.
        /// </summary>
        private void incrementLinesCleared(int lines)
        {
            this.lines += lines;

            level = Math.Min((this.lines / 10 + 1), 10);

            if (lines == 4)
                this.points = this.points + 800;
            else
                this.points = points + (lines * 100);
        }

    }

}