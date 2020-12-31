using System;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace client.CEO
{
    public class CEOEvents : BaseScript
    {
        public CEOEvents()
        {
            EventHandlers["Freedom:OrganizationCreated"] += new Action<string, string>(OrganizationCreated);
        }

        private static void OrganizationCreated(string displayString, string playername)
        {
            API.SetNotificationTextEntry("STRING");
            API.SetNotificationColorNext(4);
            API.AddTextComponentString($"~b~{displayString}~w~ has just been created by ~b~{playername}~w~.");
            API.SetTextScale(0.5f, 0.5f);
            API.SetNotificationMessage("CHAR_LIFEINVADER", "CHAR_LIFEINVADER", false, 0, "New Organization", $"{displayString}");
            API.DrawNotification(true, false);
        }
    }
}
