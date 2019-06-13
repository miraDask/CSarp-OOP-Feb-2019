namespace SimpleSnake.Constants
{
    public static class GameConstants
    {
        //public static string SnakeSymbol = ">"; //"\u25CF"
        public static string SnakeRightSymbol = "\u2BC8"; 
        public static string SnakeLeftSymbol = "\u2BC7"; 
        public static string SnakeUpSymbol = "\u2BC5"; 
        public static string SnakeDownSymbol = "\u2BC6"; 
        public static int SnakeDefaultLength = 6;
        public static int SnakeDefaultCoordinateX = 5;
        public static int SnakeDefaultCoordinateY = 6;

        public static string FoodAsteriksSymbol = "*";
        public static int FoodAsteriksPoints = 1;
        public static string FoodDollarSymbol = "$";
        public static int FoodDollarPoints = 2;
        public static string FoodHashSymbol = "#";
        public static int FoodHashPoints = 3;
        public static int FoodDissapeareTime = 8000;

        public static int BoardDefaultWidth = 120;
        public static int BoardDefaultHeight = 40;
        public static string BoarderDafaultSymbol = "\u25A0";

        public static int SuspentionTimeUpDown = 150;
        public static int SuspentionTimeLeftRight = 100;

        public static int PlayerScoreOffsetX = 20;
        public static int PlayerScoreOffsetY = 5;
        public static string PlayerScoreMessage = "Game score: {0}";
        public static string PlayerLevelMessage = "Level : {0}";

        public static int RestartMessageCoordinateX = 45;
        public static int RestartMessageCoordinateY = 20;
        public static string RestartMessage = "Would you like to continue? ";
        public static string RestartAdditionalMessage = "Y/N";

        public static int ConfigDefaultWindowWidth = 200;
        public static int ConfigDefaultWindowHeight = 50;
        public static int ConfigDefaultFPS = 100;

        public static int LevelsOffset = 20;
        public static int Level_1StartingPoints = 0;
        public static int Level_2StartingPoints = 20;
    }
}
