namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Miscellaneous.Contracts;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Parts.Contracts;
    using TheTankGame.Entities.Vehicles;

    [TestFixture]
    public class BaseVehicleTests
    {
        private BaseVehicle baseVehicle;
        private IAssembler assembler;

        [SetUp]
        public void Setup()
        {
            string model = "Rhino-CE";
            double weight = 3000;
            decimal price = 85000;
            int attack = 2000;
            int defense = 4000;
            int hitPoints = 20000;
            this.assembler = new VehicleAssembler();

            baseVehicle = new Vanguard(model, weight, price, attack, defense, hitPoints, this.assembler);
        }

        [Test]
        public void Constructor_CreatesNewObject()
        {
            Assert.IsNotNull(this.baseVehicle);
        }


        [Test]
        public void Model_ThrowsExceptinWhenInvalidValueIsPassed()
        {
            Assert.Throws<ArgumentException>(() => baseVehicle = new Vanguard(" ", 10, 10, 10, 10, 10, this.assembler));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void Weight_ThrowsExceptinWhenInvalidValueIsPassed(double weight)
        {
            Assert.Throws<ArgumentException>(() => baseVehicle = new Vanguard("a", weight, 10, 10, 10, 10, this.assembler));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void Price_ThrowsExceptinWhenInvalidValueIsPassed(decimal price)
        {
            Assert.Throws<ArgumentException>(() => baseVehicle = new Vanguard("a", 10, price, 10, 10, 10, this.assembler));
        }

        [Test]
        public void Attack_ThrowsExceptinWhenInvalidValueIsPassed()
        {
            Assert.Throws<ArgumentException>(() => baseVehicle = new Vanguard("a", 10, 10, -1, 10, 10, this.assembler));
        }

        [Test]
        public void Defense_ThrowsExceptinWhenInvalidValueIsPassed()
        {
            Assert.Throws<ArgumentException>(() => baseVehicle = new Vanguard("a", 10, 10, 10, -1, 10, this.assembler));
        }

        [Test]
        public void HitPoints_ThrowsExceptinWhenInvalidValueIsPassed()
        {
            Assert.Throws<ArgumentException>(() => baseVehicle = new Vanguard("a", 10, 10, 10, 10, -1, this.assembler));
        }

        [Test]
        public void AddArsenalPart_AddsPartCorrectly()
        {
            IPart arsenalPart
                = new ArsenalPart(model:"Destroyer-2U", weight: 1000, price: 50000, attackModifier: 5000);

            this.baseVehicle.AddArsenalPart(arsenalPart);

            Assert.Contains(arsenalPart, (ICollection)this.baseVehicle.Parts);
        }

        [Test]
        public void AddEndurancePart_AddsPartCorrectly()
        {
            IPart arsenalPart
                = new EndurancePart(model: "Destroyer-2U", weight: 1000, price: 50000, hitPointsModifier: 5000);

            this.baseVehicle.AddEndurancePart(arsenalPart);

            Assert.Contains(arsenalPart, (ICollection)this.baseVehicle.Parts);
        }

        [Test]
        public void AddShellPart_AddsPartCorrectly()
        {
            IPart arsenalPart
                = new ShellPart(model: "Destroyer-2U", weight: 1000, price: 50000, defenseModifier: 5000);

            this.baseVehicle.AddShellPart(arsenalPart);

            Assert.Contains(arsenalPart, (ICollection)this.baseVehicle.Parts);
        }

        [Test]
        public void TotalWeight_ReturnsCorrectValue()
        {
            IPart arsenalPart
               = new ShellPart(model: "Destroyer-2U", weight: 1000, price: 50000, defenseModifier: 5000);

            this.baseVehicle.AddShellPart(arsenalPart);

            var expected = 4000;

            Assert.AreEqual(expected, this.baseVehicle.TotalWeight);
        }

        [Test]
        public void TotalPrice_ReturnsCorrectValue()
        {
            IPart arsenalPart
               = new ShellPart(model: "Destroyer-2U", weight: 1000, price: 50000, defenseModifier: 5000);

            this.baseVehicle.AddShellPart(arsenalPart);

            var expected = 135000;

            Assert.AreEqual(expected, this.baseVehicle.TotalPrice);
        }

        [Test]
        public void TotalAttack_ReturnsCorrectValue()
        {
            IPart arsenalPart
               = new ShellPart(model: "Destroyer-2U", weight: 1000, price: 50000, defenseModifier: 5000);

            this.baseVehicle.AddShellPart(arsenalPart);

            var expected = 2000;

            Assert.AreEqual(expected, this.baseVehicle.TotalAttack);
        }

        [Test]
        public void TotalDefens_ReturnsCorrectValue()
        {
            IPart arsenalPart
               = new ShellPart(model: "Destroyer-2U", weight: 1000, price: 50000, defenseModifier: 5000);

            this.baseVehicle.AddShellPart(arsenalPart);

            var expected = 9000;

            Assert.AreEqual(expected, this.baseVehicle.TotalDefense);
        }

        [Test]
        public void TotalHitPoints_ReturnsCorrectValue()
        {
            IPart arsenalPart
               = new ShellPart(model: "Destroyer-2U", weight: 1000, price: 50000, defenseModifier: 5000);

            this.baseVehicle.AddShellPart(arsenalPart);

            var expected = 20000;

            Assert.AreEqual(expected, this.baseVehicle.TotalHitPoints);
        }

        [Test]
        public void Parts_ReturnsCorrectCollection()
        {
            IPart arsenalPart
                = new ArsenalPart(model: "Destroyer-2U", weight: 1000, price: 50000, attackModifier: 5000);

            this.baseVehicle.AddArsenalPart(arsenalPart);

            IPart shellPart
               = new ShellPart(model: "Destroyer-2U", weight: 1000, price: 50000, defenseModifier: 5000);

            this.baseVehicle.AddShellPart(shellPart);

            IPart endurancePart
             = new EndurancePart(model: "Destroyer-2U", weight: 1000, price: 50000, hitPointsModifier: 5000);

            this.baseVehicle.AddEndurancePart(endurancePart);

            List<IPart> parts = new List<IPart>()
            {
                arsenalPart,
                shellPart,
                endurancePart
            };

            CollectionAssert.AreEqual(parts, this.baseVehicle.Parts);
        }

        [Test]
        public void ToStringReturnsRightMessage()
        {
            //string model = "";
            //double weight = ;
            //decimal price = 85000;
            //int attack = 2000;
            //int defense = 4000;
            //int hitPoints = 20000;
            //this.assembler = new VehicleAssembler();

            //baseVehicle = new Vanguard(model, weight, price, attack, defense, hitPoints, this.assembler);
            StringBuilder  sb = new StringBuilder();

            sb.AppendLine($"Vanguard - Rhino-CE");
            sb.AppendLine($"Total Weight: {this.baseVehicle.Weight:F3}");
            sb.AppendLine($"Total Price: {this.baseVehicle.Price:F3}");
            sb.AppendLine($"Attack: {this.baseVehicle.Attack}");
            sb.AppendLine($"Defense: {this.baseVehicle.Defense}");
            sb.AppendLine($"HitPoints: {this.baseVehicle.HitPoints}");
            sb.Append("Parts: None");

            var expectedResult = sb.ToString();
            var result = this.baseVehicle.ToString();

            Assert.AreEqual(expectedResult, result);
        }
    }
}