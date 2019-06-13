// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    //using FestivalManager.Core.Controllers;
    //using FestivalManager.Core.Controllers.Contracts;
    //using FestivalManager.Entities;
    //using FestivalManager.Entities.Contracts;
    //using FestivalManager.Entities.Instruments;
    //using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class SetControllerTests
    {
        private IStage stage;
        private ISetController setController;
        private ISong song;
        private IInstrument instrument;
        private IPerformer performer;
        private ISet set;

        [SetUp]
        public void SetUp()
        {
            this.song = new Song("Song2", new TimeSpan(0, 3, 0));
            this.instrument = new Microphone();
            this.performer = new Performer("Lili", 32);
            this.performer.AddInstrument(this.instrument);
            this.set = new Long("LongSet");
            this.stage = new Stage();
            this.setController = new SetController(this.stage);
        }

		[Test]
	    public void Constructore_CreatesObject()
	    {
            Assert.IsNotNull(this.setController);
		}

        [Test]
        public void ReturnsCorrectMessage_WhenEmtySetIsAdded()
        {
            this.stage.AddSet(this.set);
            var message = this.setController.PerformSets();
            var expectedResult = "1. LongSet:\r\n-- Did not perform";

            Assert.AreEqual(expectedResult, message);
        }

        [Test]
        public void ReturnsCorrectMessage_WhenSetIsAdded()
        {
            this.set.AddSong(this.song);
            this.set.AddPerformer(this.performer);
            var secondPerformer = new Performer("Mimi", 16);
            var secondInstument = new Guitar();
            secondPerformer.AddInstrument(secondInstument);
            var newSong = new Song("MimiSong", new TimeSpan(0, 4, 0));
            var newSet = new Medium("Set2");
            newSet.AddPerformer(secondPerformer);
            newSet.AddSong(newSong);
            this.stage.AddPerformer(this.performer);
            this.stage.AddPerformer(secondPerformer);
            this.stage.AddSong(this.song);
            this.stage.AddSong(newSong);
            this.stage.AddSet(this.set);
            this.stage.AddSet(newSet);


            var message = this.setController.PerformSets();
            var expectedResult =
                "1. Set2:\r\n-- 1. MimiSong (04:00)\r\n-- Set Successful\r\n" +
                "2. LongSet:\r\n-- 1. Song2 (03:00)\r\n-- Set Successful";

            Assert.AreEqual(expectedResult, message);
        }

        [Test]
        public void InstrumentsWearingDown()
        {
            this.set.AddSong(this.song);
            this.set.AddPerformer(this.performer);
            this.stage.AddSet(this.set);
            this.setController.PerformSets();

            var expectedInstrumentWear = 20;
            var result = this.instrument.Wear;

            Assert.AreEqual(expectedInstrumentWear, result);
        }
    }
}