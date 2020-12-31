using System;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace client.Apartments
{
    public class ApartmentEvents : BaseScript
    {
        public ApartmentEvents()
        {
            EventHandlers["Freedom:EnterHouseComplete"] += new Action<int>(EnteredHouse);
            EventHandlers["Freedom:ExitHouseComplete"] += new Action<int>(ExitedHouse);
        }

        private static void EnteredHouse(int playerID)
        {
            
        }

        private static void ExitedHouse(int playerID)
        {
            
        }
    }
}
