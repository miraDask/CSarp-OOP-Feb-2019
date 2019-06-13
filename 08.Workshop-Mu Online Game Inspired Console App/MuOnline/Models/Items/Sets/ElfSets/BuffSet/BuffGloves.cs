namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffGloves : Item
    {
        private const int strengthPoints = 0;
        private const int agilityPoints = 15;
        private const int energyPoints = 40;
        private const int staminaPoints = 43;

        public BuffGloves()
            : base(strengthPoints, agilityPoints, energyPoints, staminaPoints)
        {
        }
    }
}
