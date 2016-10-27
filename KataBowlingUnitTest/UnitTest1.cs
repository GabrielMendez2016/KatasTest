using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataBowlingUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SimpleGameStrikes()
        {
            String test = "XXXXXXXXXXXX";

            Game game = new Game();
            game.Run(test);
            Assert.AreEqual(300, game.GetScore());
        }

        [TestMethod]
        public void SimpleGameSpares()
        {
            String test = "5/5/5/5/5/5/5/5/5/5/5";

            Game game = new Game();
            game.Run(test);
            Assert.AreEqual(150, game.GetScore());
        }

        [TestMethod]
        public void SimpleGameMiss()
        {

            String test = "9-9-9-9-9-9-9-9-9-9-";

            Game game = new Game();
            game.Run(test);
            Assert.AreEqual(90, game.GetScore());
        }

        [TestMethod]
        public void SimpleGameMixed()
        {
            
            String test = "9-X6/X4-6/XX4-3/";
            //F1=9,f2=10+10+
            Game game = new Game();
            game.Run(test);
            Assert.AreEqual(139, game.GetScore());
        }
    }
}
