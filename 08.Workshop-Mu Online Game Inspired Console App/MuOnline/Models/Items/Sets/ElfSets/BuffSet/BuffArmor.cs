namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffArmor : Item
    {
        private const int strengthPoints = 0;
        private const int agilityPoints = 32;
        private const int energyPoints = 34;
        private const int staminaPoints = 58;

        public BuffArmor()
            : base(strengthPoints, agilityPoints, energyPoints, staminaPoints)
        {
        }
    }
}
