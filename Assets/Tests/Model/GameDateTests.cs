using NUnit.Framework;
using System;

namespace Tests
{
    class GameDateTests
    {
        [Test]
        public void Init_ShouldRegister_Values()
        {
            GameDate date = new GameDate(1, 2, 3);
            Assert.AreEqual(1, date.Year);
            Assert.AreEqual(2, date.Week);
            Assert.AreEqual(3, date.Day);
        }

        [Test]
        public void Init_withNegativeYear_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(delegate { new GameDate(-1, 1, 1); });
        }

        [Test]
        public void Init_withNegativeWeek_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(delegate { new GameDate(1, -1, 1); });
        }

        [Test]
        public void Init_withTooBigWeek_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(delegate { new GameDate(1, 13, 1); });
        }

        [Test]
        public void Init_withTooBigDay_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(delegate { new GameDate(1, 6, -1); });
        }

        [Test]
        public void NextDay_ShouldAddADayIfWeekIsNotOver()
        {
            GameDate date = new GameDate(0, 0, 0);
            date.NextDay();
            Assert.AreEqual(1, date.Day);
        }

        [Test]
        public void NextDay_ShouldResetDayAndUpdateWeekIfWeekIsOver()
        {
            GameDate date = new GameDate(0, 0, 4);
            date.NextDay();
            Assert.AreEqual(0, date.Day);
            Assert.AreEqual(1, date.Week);
        }

        [Test]
        public void NextDay_Should_ResetDay_AndResetWeek_AndUpdateYear_IfWeekIsOverAndYearIsOver()
        {
            GameDate date = new GameDate(0, 11, 4);
            date.NextDay();
            Assert.AreEqual(0, date.Day);
            Assert.AreEqual(0, date.Week);
            Assert.AreEqual(1, date.Year);
        }
    }
}
