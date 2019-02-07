using NUnit.Framework;

namespace Tests
{
    class GameTests
    {
        [Test]
        public void Instance_should_return_singleton()
        {
            Game game = Game.Instance;
            Assert.AreEqual(game, Game.Instance);
        }
    }
}
