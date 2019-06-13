namespace Travel.Entities.Airplanes
{
    using Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Travel.Entities.Airplanes.Contracts;

    public abstract class Airplane : IAirplane
    {
        private List<IBag> baggageCompartment;
        private List<IPassenger> passengers;

        public Airplane(int seats, int baggageCompartments)
        {
            this.Seats = seats;
            this.BaggageCompartments = baggageCompartments;
            this.baggageCompartment = new List<IBag>();
            this.passengers = new List<IPassenger>();
		}

		public int Seats { get; }
		public int BaggageCompartments { get; }

		public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();

		public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();

		public bool IsOverbooked => this.Passengers.Count() > this.Seats;

        public void AddPassenger(IPassenger passenger)
        {
			this.passengers.Add(passenger);
		}

		public IPassenger RemovePassenger(int seat) {

            var passenger = this.passengers[seat];
            this.passengers.RemoveAt(seat);

			return passenger;
		}

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
			var passengerBags = this.baggageCompartment
				.Where(b => b.Owner == passenger)
				.ToArray();

			foreach (var bag in passengerBags)
            {
                this.baggageCompartment.Remove(bag);
            }
				
			return passengerBags;
		}

		public void LoadBag(IBag bag)
        {
            var isBaggageCompartmentFull = this.BaggageCompartment.Count > this.BaggageCompartments; // ?=

            if (isBaggageCompartmentFull)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().ToString()}!");

            }

            this.baggageCompartment.Add(bag);
		}
	}
}