namespace MuOnline.Models.Items.Sets.DarkKnightSets.DoomSet
{
    public class DoomArmor : Item
    {
        private const int strengthPoints = 12;
        private const int agilityPoints = 32;
        private const int energyPoints = 0;
        private const int staminaPoints = 27;

        public DoomArmor()
            : base(strengthPoints, agilityPoints, energyPoints, staminaPoints)
        {
        }
    }
}
