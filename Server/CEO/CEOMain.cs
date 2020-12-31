using System;
using System.Collections.Generic;
using System.Linq;
using MySqlConnector;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace server.CEO
{
    public class CEOMain : BaseScript
    {
        public CEOMain()
        {
            //Database
            Database.Initialize();

            //Events
            EventHandlers["Freedom:CreateOrganization"] += new Action<Player, string>(CreateOrganization);
        }

        private void CreateOrganization([FromSource] Player player, string displayString)
        {
            //Get Player Identifier
            var Identifier = player.Identifiers["license"];

            //Get Player Name
            string playername = player.Name;

            //Create New Organization
            Database.ExecuteInsertQuery($"INSERT INTO ceo (Identifier, IsCEO, OrganizationName) VALUE ('{Identifier}', 'true', '{displayString}')");

            //Trigger Client Event For All
            TriggerClientEvent("Freedom:OrganizationCreated", displayString, playername);
        }
    }
}
