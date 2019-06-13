namespace _06.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private int rating;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public int Rating => CalculateRating();

        private int CalculateRating()
        {
            if (this.players.Count == 0)
            {
                return 0;
            }

            var rating = players.Select(x => x.GetAverageStatus()).Sum(); 

            return (int)Math.Round(rating) ;
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            if (!this.players.Any(x => x.Name == name))
            {
                throw new ArgumentException($"Player {name} is not in {this.Name} team.");
            }

            var player = this.players.Find(x => x.Name == name);
            this.players.Remove(player);
        }
    }
}
