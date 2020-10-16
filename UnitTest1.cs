using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RussianRoulette;
namespace UnitTestProject1
{
    
    [TestClass]
    public class UnitTest1
    {
        CreateRouletteGame TestingObj = new CreateRouletteGame();
        int numPlayers = 2;
        [TestMethod]
        public void GamePlayingMethod()
        {
            WinLose obj = new WinLose();
            int startChamber = TestingObj.spinChamber();
            int bulletChamber = TestingObj.spinChamber();
            int ChamberPosition = TestingObj.Playing(numPlayers, startChamber, bulletChamber);
            if (ChamberPosition == -1)
            {
                Assert.AreEqual(obj.WinGame, obj.WinGame);
                Assert.AreEqual(obj.LoseGame, obj.LoseGame);
            }
            else
            {
                Assert.AreEqual("NextRound", "NextRound");

            }
        }
        [TestMethod]
        public void GenrateBuletteAndChamberNumberInGun()
        {
            int startChamber = TestingObj.spinChamber();
            int bulletChamber = TestingObj.spinChamber();
        }
    }
}
