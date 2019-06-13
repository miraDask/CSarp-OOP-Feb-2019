namespace _06.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Player
    {
        private string name;
        //private SkillStatus stats;

        public Player(string name, SkillStatus stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public SkillStatus Stats { get; set; }

        public double GetAverageStatus()
        {
            var stats = new List<int>() { this.Stats.Endurance
                , this.Stats.Sprint
                , this.Stats.Dribble
                , this.Stats.Passing
                , this.Stats.Shooting };

            var avarage = stats.Average();

            return avarage;
        }
    }
}
