using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisTest
{
    class ScoryTest
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
            set { lines=value; }

        }

        public int Points
        {
            get { return points; }
            set { points = value; }
        }


        public ScoryTest()
        {
            level = 1;
            lines = 0;
            points = 0;
            
        }

        /// <summary>
        /// Score class observes IBoard
        /// 
        /// Keeps track of the level, lines and score
        /// of the ongoing game.
        /// </summary>
        public void incrementLinesCleared(int lines)
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
