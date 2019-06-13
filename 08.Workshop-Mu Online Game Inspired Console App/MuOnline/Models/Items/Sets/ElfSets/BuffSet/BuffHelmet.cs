namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffHelmet : Item
    {
        private const int strengthPoints = 0;
        private const int agilityPoints = 25;
        private const int energyPoints = 15;
        private const int staminaPoints = 30;

        public BuffHelmet()
            : base(strengthPoints, agilityPoints, energyPoints, staminaPoints)
        {
        }
    }
}
