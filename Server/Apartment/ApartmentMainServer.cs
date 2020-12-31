using System;
using System.Collections.Generic;
using System.Linq;
using MySqlConnector;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace server.Apartment
{
    public class ApartmentMainServer : BaseScript
    {
        public ApartmentMainServer()
        {
            //Events
            EventHandlers["Freedom:EnterHouse"] += new Action<Player>(EnterHouse);
            EventHandlers["Freedom:ExitHouse"] += new Action<Player>(ExitHouse);
        }

        private void ExitHouse([FromSource] Player player)
        {
            int playerID = int.Parse(player.Handle);
            TriggerClientEvent("Freedom:ExitHouseComplete", playerID);
        }

        private void EnterHouse([FromSource] Player player)
        {
            int playerID = int.Parse(player.Handle);
            TriggerClientEvent("Freedom:EnterHouseComplete", playerID);
        }
    }
}
