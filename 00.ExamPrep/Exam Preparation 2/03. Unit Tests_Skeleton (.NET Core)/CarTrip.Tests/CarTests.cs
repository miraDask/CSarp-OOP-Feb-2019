using CarTrip;
using NUnit.Framework;
using System;

namespace CarTrip.Tests
{
    
    public class Tests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("BMV", 50, 20, 6);
        }

        [Test]
        public void TankCapacity_Setter_SetsCorrectValue()
        {
            Assert.AreEqual(50, this.car.TankCapacity);
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void ModelSetter_ThrowsExceptionWhenInvalidValueIsPassed(string model)
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car(model, 50, 20, 6));
        }

        [Test]
        public void Model_Setter_SetsCorrectValue()
        {
            Assert.AreEqual("BMV", this.car.Model);
        }

        [Test]
        public void FuelAmount_ThrowsExceptionWhenInvalidValueIsPassed()
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car("Model", 50, 51, 6));
        }

        [Test]
        public void FuelAmount_Setter_SetsCorrectValue()
        {
            Assert.AreEqual(20, this.car.FuelAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelConsumptionPerKm_ThrowsExceptionWhenInvalidValueIsPassed(double fuelConsumptionPerKm)
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car("Model", 50, 20, fuelConsumptionPerKm));
        }

        [Test]
        public void FuelConsumptionPerKm_Setter_SetsCorrectValue()
        {
            Assert.AreEqual(6, this.car.FuelConsumptionPerKm);
        }

        [Test]
        public void Drive_ThrowsExceptionWhenInvalidValueIsPassed()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(100));
        }

        [Test]
        public void Drive_DecreaseFuelAmount()
        {
            this.car.Drive(1);
            Assert.AreEqual(14, this.car.FuelAmount);
        }

        [Test]
        public void Drive_ReturnsCorrectMessage()
        {
            string result = this.car.Drive(1);

            Assert.AreEqual("Have a nice trip", result);
        }

        [Test]
        public void Refuel_ThrowsExceptionWhenInvalidValueIsPassed()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Refuel(100));
        }

        [Test]
        public void Refuel_IncreaseFuelAmount()
        {
            this.car.Refuel(10);
            Assert.AreEqual(30, this.car.FuelAmount);
        }
    }
}