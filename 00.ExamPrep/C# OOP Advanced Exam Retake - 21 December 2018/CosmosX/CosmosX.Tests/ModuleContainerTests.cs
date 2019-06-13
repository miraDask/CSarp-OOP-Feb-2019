namespace CosmosX.Tests
{
    using CosmosX.Entities.Containers;
    using CosmosX.Entities.Containers.Contracts;
    using CosmosX.Entities.Modules.Absorbing;
    using CosmosX.Entities.Modules.Absorbing.Contracts;
    using CosmosX.Entities.Modules.Energy;
    using CosmosX.Entities.Modules.Energy.Contracts;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ModuleContainerTests
    {
        private IContainer moduleContainer;
        
        [SetUp]
        public void SetUp()
        {
            this.moduleContainer = new ModuleContainer(3);
        }

        [Test]
        public void Constructor_CreatesNewObject_Successfully()
        {
            Assert.IsNotNull(this.moduleContainer);
            Assert.AreEqual(0, this.moduleContainer.ModulesByInput.Count);
        }

        [Test]
        public void AddEnergyModule_ThrowsArgumentException_WhenNullModuleIsPassed()
        {
            Assert.Throws<ArgumentException>(() => this.moduleContainer.AddEnergyModule(null));
        }

        [Test]
        public void AddEnergyModule_AddsSuccsessfully_NewEnergyModule()
        {
            IEnergyModule module = new CryogenRod(1, 2);
            this.moduleContainer.AddEnergyModule(module);

            Assert.AreEqual(1, this.moduleContainer.ModulesByInput.Count);
        }


        [Test]
        public void AddEnergyModule_AddsSuccsessfully_RemoveOldestModule()
        {
            IEnergyModule module = new CryogenRod(1, 2);
            IEnergyModule module2 = new CryogenRod(2, 2);
            IEnergyModule module3 = new CryogenRod(3, 2);
            IEnergyModule module4 = new CryogenRod(4, 2);

            this.moduleContainer.AddEnergyModule(module);
            this.moduleContainer.AddEnergyModule(module2);
            this.moduleContainer.AddEnergyModule(module3);
            this.moduleContainer.AddEnergyModule(module4);

            Assert.AreEqual(3, this.moduleContainer.ModulesByInput.Count);
        }

        [Test]
        public void AddAbsorbingModule_ThrowsArgumentException_WhenNullModuleIsPassed()
        {
            Assert.Throws<ArgumentException>(() => this.moduleContainer.AddAbsorbingModule(null));
        }


        [Test]
        public void AddAbsorbingModule_AddsSuccsessfully_NewEnergyModule()
        {
            IAbsorbingModule module = new HeatProcessor(1, 2);
            this.moduleContainer.AddAbsorbingModule(module);

            Assert.AreEqual(1, this.moduleContainer.ModulesByInput.Count);
        }

        [Test]
        public void AddAbsorbingModule_AddsSuccsessfully_RemoveOldestModule()
        {
            IAbsorbingModule module = new HeatProcessor(1, 2);
            IAbsorbingModule module2 = new HeatProcessor(2, 2);
            IAbsorbingModule module3 = new HeatProcessor(3, 2);
            IAbsorbingModule module4 = new HeatProcessor(4, 2);
            IAbsorbingModule module5 = new HeatProcessor(5, 2);
            IAbsorbingModule module6 = new HeatProcessor(6, 2);
           

            this.moduleContainer.AddAbsorbingModule(module);
            this.moduleContainer.AddAbsorbingModule(module2);
            this.moduleContainer.AddAbsorbingModule(module3);
            this.moduleContainer.AddAbsorbingModule(module4);
            this.moduleContainer.AddAbsorbingModule(module5);
            this.moduleContainer.AddAbsorbingModule(module6);

            Assert.AreEqual(3, this.moduleContainer.ModulesByInput.Count);
        }

        [Test]
        public void TotalEnergyOutput_Returns_CorrectValue()
        {
            IEnergyModule module = new CryogenRod(1, 2);
            IEnergyModule module2 = new CryogenRod(2, 2);
            IEnergyModule module3 = new CryogenRod(3, 2);

            this.moduleContainer.AddEnergyModule(module);
            this.moduleContainer.AddEnergyModule(module2);
            this.moduleContainer.AddEnergyModule(module3);

            Assert.AreEqual(6, this.moduleContainer.TotalEnergyOutput);
        }

        [Test]
        public void TotalHeatAbsorbing_Returns_CorrectValue()
        {
            IAbsorbingModule module = new HeatProcessor(1, 2);
            IAbsorbingModule module2 = new HeatProcessor(2, 3);
            IAbsorbingModule module3 = new HeatProcessor(3, 4);

            this.moduleContainer.AddAbsorbingModule(module);
            this.moduleContainer.AddAbsorbingModule(module2);
            this.moduleContainer.AddAbsorbingModule(module3);

            Assert.AreEqual(9, this.moduleContainer.TotalHeatAbsorbing);
        }
    }
}