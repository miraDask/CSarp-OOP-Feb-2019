namespace _06.FootballTeamGenerator
{
    using System;

    public class SkillStatus
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public SkillStatus(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get => this.endurance;
            set
            {
                string name = "Endurance";
                ValidateCurrentSkillStatus(value, name);
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;
            set
            {
                string name = "Sprint";
                ValidateCurrentSkillStatus(value, name);
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            set
            {
                string name = "Dribble";
                ValidateCurrentSkillStatus(value, name);
                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            set
            {
                string name = "Passing";
                ValidateCurrentSkillStatus(value, name);
                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            set
            {
                string name = "Shooting";
                ValidateCurrentSkillStatus(value, name);
                this.shooting = value;
            }
        }

        private void ValidateCurrentSkillStatus(int value, string name)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{name} should be between 0 and 100.");
            }
        }
    }
}
