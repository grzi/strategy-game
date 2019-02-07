using NUnit.Framework;

namespace Tests
{
    class TimeTickableTest
    {
        [Test]
        public void OnTick_Should_Update_Date_When_TickNbPerDay_Is_Reached()
        {
            Game game = new Game();
            // Call the private initSingleton To init the instance for the tests
            game.GetType().GetMethod("InitSingleton", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Invoke(game, null);
            game.GetType().GetMethod("SetConfig", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Invoke(game, new object[] { new GameConfig() });

            TimeTickable timeTickable = new TimeTickable();
            Assert.AreEqual(0, Game.Instance.Data.GameDate.Day);
            for (int i = 0; i < Game.Instance.Config.TickNbPerDay; i++)
            {
                timeTickable.onTick();
            }
            Assert.AreEqual(1, Game.Instance.Data.GameDate.Day);
        }
    }
}
