namespace P07.InfernoInfinity.Models.Stats
{
    using P07.InfernoInfinity.Models.Contracts;

    public class MagicStats 
    {
        public int Strength { get; private set; } = 0;

        public int Agility { get; private set; } = 0;

        public int Vitality { get; private set; } = 0;

        public void IncreaseValues(params int[] args)
        {
            this.Strength += args[0];
            this.Agility += args[1];
            this.Vitality += args[2];
        }

        public void DecreaseValues(params int[] args)
        {
            this.Strength -= args[0];
            this.Agility -= args[1];
            this.Vitality -= args[2];
        }
    }
}
