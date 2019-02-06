using NUnit.Framework;
using System.Threading;

namespace Tests {
    public class TickEngineTests {

        [Test]
        public void RegisterTickable_ShouldRegisterTickable() {

            TickEngine tickEngine = new TickEngine();
            TimeTickable timeTickable = new TimeTickable();
            tickEngine.RegisterTickable(timeTickable);
            Assert.Contains(timeTickable, tickEngine.RegisteredTickables());
        }

        [Test]
        public void Start_ShouldNotBlockMainThread() {
            TickEngine tickEngine = new TickEngine();
            Thread tickThread = tickEngine.Start();
            tickEngine.Dispose();
        }

        [Test]
        public void Start_ShouldStartToCallOnTickOnEachTickable() {
            TickEngine tickEngine = new TickEngine();
            TestTickable test = new TestTickable();
            tickEngine.RegisterTickable(test);
            tickEngine.Start();
            Thread.Sleep(TickEngine.TICK_MILLISECONDS * 3);
            Assert.GreaterOrEqual(test.tickCalled, 2);
            tickEngine.Dispose();
        }

        [Test]
        public void PauseAndResume_ShouldStopCallingOnTick() {
            TickEngine tickEngine = new TickEngine();
            TestTickable test = new TestTickable();
            tickEngine.RegisterTickable(test);

            tickEngine.Start();

            Thread.Sleep(TickEngine.TICK_MILLISECONDS * 3);
            tickEngine.Pause();
            Assert.GreaterOrEqual(test.tickCalled, 2);
            var currentTickNb = test.tickCalled;
            Thread.Sleep(TickEngine.TICK_MILLISECONDS * 3);
            Assert.AreEqual(test.tickCalled, currentTickNb);
            tickEngine.Resume();
            Thread.Sleep(TickEngine.TICK_MILLISECONDS * 3);

            Assert.GreaterOrEqual(test.tickCalled, 4);
            tickEngine.Dispose();
        }


    }


    class TestTickable : ITickable {
        public int tickCalled = 0;
        public void Dispose() {
            throw new System.NotImplementedException();
        }

        public void onTick() {
            tickCalled += 1;
        }
    }
}
