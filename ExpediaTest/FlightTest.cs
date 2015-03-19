using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly DateTime startDate = new DateTime(2011, 6, 11);
        private readonly DateTime endDate= new DateTime(2011, 6, 12);
        private readonly int miles = 1567;

        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(startDate, endDate, miles);
            Assert.IsNotNull(target);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightDoesNotAllowEndsBeforeStarts()
        {
            var target = new Flight(endDate, startDate, miles);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightDoesNotAllowNegativeMiles()
        {
            var target = new Flight(startDate, endDate, -4);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForSameDayFlight()
        {
            var target = new Flight(startDate, startDate, miles);
            Assert.AreEqual(200, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDayFlight()
        {
            var target = new Flight(startDate, endDate, miles);
            Assert.AreEqual(220, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTwoDayFlight()
        {
            var target = new Flight(startDate, new DateTime(2011, 6, 13), miles);
            Assert.AreEqual(240, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceFor10DayFlight()
        {
            var target = new Flight(startDate, new DateTime(2011, 6, 21), miles);
            Assert.AreEqual(400, target.getBasePrice());
        }
	}
}
