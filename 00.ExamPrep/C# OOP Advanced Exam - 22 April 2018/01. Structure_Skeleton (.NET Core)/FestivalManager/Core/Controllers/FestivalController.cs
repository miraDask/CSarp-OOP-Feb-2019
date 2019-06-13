namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        private const string TimeFormatLong = "{0:2D}:{1:2D}";
        private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        private readonly IStage stage;
        private ISetFactory setFactory;
        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;
        private ISongFactory songFactory;

        public FestivalController(IStage stage)
        {
            this.stage = stage;
            this.setFactory = new SetFactory();
            this.instrumentFactory = new InstrumentFactory();
            this.performerFactory = new PerformerFactory();
            this.songFactory = new SongFactory();
        }

        public FestivalController()
        {
        }

        public string RegisterSet(string[] args)
        {
            // Creates a set of the specified type with the specified name and adds it to the stage’s sets.
            //Upon a successful set registration, the command returns "Registered {type} set".
            var setName = args[0];
            var setType = args[1];
            var set = this.setFactory.CreateSet(setName, setType);
            this.stage.AddSet(set);

            return $"Registered {setType} set";
        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var instrumentTypes = args.Skip(2).ToArray();

            var instruments = instrumentTypes
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            var performer = this.performerFactory.CreatePerformer(name, age);

            foreach (var instrument in instruments.Where(x => x != null))
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {song} to {set.Name}";
        }

        // TODO timespan parse - not sure
        public string RegisterSong(string[] args)
        {
            // Creates a song with the specified name and duration and adds it to the stage’s songs
            // . Upon successful creation, the command returns 
            //"Registered song {songName} ({duration:mm\\:ss})".
            var songName = args[0];
            var splitedTime = args[1].Split(':');
            var songMinutes = int.Parse(splitedTime[0]);
            var songSeconds = int.Parse(splitedTime[1]);
            var duration = new TimeSpan(0, songMinutes, songSeconds);
            var song = this.songFactory.CreateSong(songName, duration);
            this.stage.AddSong(song);
            return $"Registered song {song.ToString()}";
        }

        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }

        public string ProduceReport()
        {
            var result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));
            var minutes = totalFestivalLength.Minutes;

            if (totalFestivalLength.Hours > 0)
            {
                minutes += totalFestivalLength.Hours * 60;
            }

            var lenthResult = $"{minutes:d2}:{totalFestivalLength.Seconds:d2}";
            result += ($"Festival length: {lenthResult}") + "\n";


            foreach (var set in this.stage.Sets)
            {
                var setMinutes = set.ActualDuration.Minutes;

                if (set.ActualDuration.Hours > 0)
                {
                    setMinutes += set.ActualDuration.Hours * 60;
                }

               var setLengthResult = $"{setMinutes:d2}:{set.ActualDuration.Seconds:d2}";
                result += ($"--{set.Name} ({setLengthResult}):") + "\n";


                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + "\n";
                }

                if (!set.Songs.Any())
                    result += ("--No songs played") + "\n";
                else
                {
                    result += ("--Songs played:") + "\n";
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
                    }
                }
            }

            return result.ToString();
        }
    }
}