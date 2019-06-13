namespace Skeleton.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class HeroTests
    {
        private const string HeroName = "Pesho";
        private ITarget fakeTarget;
        private IWeapon fakeWeapon;
        private Hero hero;

        [SetUp]
        public void HeroSetUp()
        {
            fakeTarget = new FakeTarget();
            fakeWeapon = new FakeWeapon();
            hero = new Hero(HeroName, fakeWeapon);
        }

        [Test]
        public void Hero_GainsXP_WhenTargetDies()
        {
            hero.Attack(fakeTarget);

            Assert.AreEqual(10, hero.Experience);
        }
    }
}
