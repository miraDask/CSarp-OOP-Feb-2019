﻿using MortalEngines.Core;
using MortalEngines.Core.Contracts;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}