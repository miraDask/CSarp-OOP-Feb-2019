using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Pilots
{
    public class PilotFactory
    {
        public IPilot GetPilot(string name)
        {
            IPilot pilot = new Pilot(name);
            return pilot;
        }
    }
}
