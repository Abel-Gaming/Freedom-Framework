using System;
using CitizenFX.Core;
using CitizenFX.Core.UI;

namespace client.Modules
{
    public class Identification : BaseScript
    {
        public Identification()
        {
            EventHandlers["Freedom:GetID"] += new Action<string, Vector3>(GetID);
        }

        private static void GetID(string displayString, Vector3 personlocation)
        {
            //Get distance
            float distance = World.GetDistance(Game.Player.Character.Position, personlocation);

            //Get Zone
            string street = World.GetStreetName(personlocation);
            string zone = World.GetZoneLocalizedName(personlocation);

            if (distance <= 7f)
            {
                Screen.ShowNotification($"Identification: ~y~{displayString}~w~~n~Location: ~y~{street}, {zone}");
            }
        }
    }
}
