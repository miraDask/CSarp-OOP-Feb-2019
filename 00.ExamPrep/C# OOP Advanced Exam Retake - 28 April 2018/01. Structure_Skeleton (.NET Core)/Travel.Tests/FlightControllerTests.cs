// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
	using NUnit.Framework;
    using System.Collections.Generic;
    using Travel.Core.Controllers;
    using Travel.Core.Controllers.Contracts;
    using Travel.Entities;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Airplanes.Contracts;
    using Travel.Entities.Contracts;
    using Travel.Entities.Items;
    using Travel.Entities.Items.Contracts;

    [TestFixture]
    public class FlightControllerTests
    {
        private IAirplane airplane;
        private IAirport airport;
        private ITrip trip;
        private IItem item;
        private IBag bag;
        private IPassenger passenger;
        private IFlightController flightController;

        [SetUp]
        public void Setup()
        {
            this.airplane = new LightAirplane();
            this.airport = new Airport();
            this.trip = new Trip("Sofia", "London", this.airplane);
            this.item = new Colombian();
            this.passenger = new Passenger("Lili");
            this.bag = new Bag(this.passenger ,new List<IItem> { this.item });
            this.flightController = new FlightController(airport);
        }

	    [Test]
	    public void TakeOff_SkippsWhenTripIsCompleted()
	    {
            this.airport.AddPassenger(this.passenger);
            this.airport.AddTrip(this.trip);
            this.trip.Complete();

            var actualResult = this.flightController.TakeOff();
            var expectedResult  = "Confiscated bags: 0 (0 items) => $0";

            Assert.AreEqual(expectedResult, actualResult);
	    }

        [Test]
        public void TakeOff_LoadsBaggage()
        {
            this.airport.AddPassenger(this.passenger);
            this.airport.AddTrip(this.trip);

            var actualResult = this.flightController.TakeOff();
            var expectedResult = "SofiaLondon3:" +
                "\r\nSuccessfully transported 0 passengers from Sofia to London." +
                "\r\nConfiscated bags: 0 (0 items) => $0";

            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test]
        public void TakeOff_CompletesTrip()
        {
            this.airport.AddPassenger(this.passenger);
            this.airport.AddTrip(this.trip);

            var actualResult = this.flightController.TakeOff();

            var tripIsCompletedAfterTaceOff = true;

            Assert.AreEqual(tripIsCompletedAfterTaceOff, this.trip.IsCompleted);
        }

        [Test]
        public void TakeOff_EjectOverbookedPassengers()
        {
            var passengers = new IPassenger[10];

            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = new Passenger($"Lili+{i + 1}");
                this.airplane.AddPassenger(passengers[i]);

                if (i < 5)
                {
                    passengers[i].Bags.Add(new Bag(passengers[i], new List<IItem> { this.item }));
                }
            }

            this.airport.AddTrip(this.trip);

            var actualResult = this.flightController.TakeOff();
            var expectedResult = "SofiaLondon2:" +
                "\r\nOverbooked! Ejected Lili+2, Lili+1, Lili+4, Lili+8, Lili+9" +
                "\r\nConfiscated 3 bags ($150000)" +
                "\r\nSuccessfully transported 5 passengers from Sofia to London." +
                "\r\nConfiscated bags: 3 (3 items) => $150000";

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
