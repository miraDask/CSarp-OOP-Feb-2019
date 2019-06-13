namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;

        [SetUp]
        public void SetUpAliveDummy()
        {
            this.dummy = new Dummy(10, 10);
        }

        [Test]
        [TestCase(6)]
        [TestCase(5)]
        public void Dummy_LosesHealth_AfterBeingAttacked(int attackPoints)
        {
            //Arrange  by SetUp
            
            //Act
            int updatedHealtPoints = dummy.Health - attackPoints;
            dummy.TakeAttack(attackPoints);

            //Assert
            Assert.AreEqual(dummy.Health, updatedHealtPoints);
        }

        [Test]
        [TestCase(10)]
        [TestCase(16)]
        public void AttackedDeadDummy_ThrowsException_AfterBeingAttacked(int attackPoints)
        {
            // Arrange
            this.dummy = new Dummy(0, 10);

            //Act + Assert
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(attackPoints));
        }

        [Test]
        public void DeadDummy_GivesXP()
        {
            //Arrange
            this.dummy = new Dummy(0, 10);

            //Act
            int experience = dummy.GiveExperience();

            //Assert
            Assert.AreEqual(10 , experience);
        }

        [Test]
        public void AliveDummy_DoNotGivesXP_AndThrowsExeption()
        {
            //Arrange  by SetUp

            //Act + Assert
            Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience());

        }
    }
}
