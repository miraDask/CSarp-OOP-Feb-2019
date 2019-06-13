namespace Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AxeTests
    {
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            dummy = new Dummy(10,10);
        }

        [Test]
        [TestCase(10)]
        [TestCase(9)]
        public void Axe_LoosesDurability_AfterAttack(int initialDurability)
        {
            // Arrange
            Axe axe = new Axe(10, initialDurability);

            // Act
            axe.Attack(dummy);

            // Assert
            Assert.AreEqual(axe.DurabilityPoints, initialDurability - 1);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-32)]
        public void Throws_Exeption_WhenAttacs_WithBrockenAxe(int initialDurability)
        {
            // Arrange
            Axe axe = new Axe(10, initialDurability);

            // Act + Assert
            Assert.Throws<InvalidOperationException>(() => axe.Attack(this.dummy));
        }
    }
}