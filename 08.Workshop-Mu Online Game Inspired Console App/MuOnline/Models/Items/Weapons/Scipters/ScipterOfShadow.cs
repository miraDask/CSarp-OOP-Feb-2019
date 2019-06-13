namespace MuOnline.Models.Items.Weapons.Scipters
{
    class ScipterOfShadow : Item
    {
        private const int strengthPoints = 5;
        private const int agilityPoints = 25;
        private const int energyPoints = 40;
        private const int staminaPoints = 10;

        public ScipterOfShadow() 
            : base(strengthPoints, agilityPoints, energyPoints, staminaPoints)
        {
        }
    }
}
