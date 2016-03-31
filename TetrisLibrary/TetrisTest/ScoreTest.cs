using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisLibrary;
using Microsoft.Xna.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TetrisTest
{
    [TestClass]
    public class ScoreTest
    {
        [TestMethod]
        public void TestIncrementLines1()
        {
            Score score = new Score(new FakeBoard());


        }
    }
}
