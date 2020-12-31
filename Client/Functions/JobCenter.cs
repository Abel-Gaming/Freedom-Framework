using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace client.Functions
{
    public class JobCenter : BaseScript
    {
        private static List<Vector3> JobCenterLocationList;
        public JobCenter()
        {
            //Create List
            JobCenterLocationList = new List<Vector3>();

            //Add Coords to List
            JobCenterLocationList.Add(new Vector3(-265.29f, -963.1f, 31.22f));
            JobCenterLocationList.Add(new Vector3(1863.88f, 3747.71f, 33.03f));

            //Tick
            Tick += DrawMarkers;
            Tick += CheckMarkers;
            Tick += SalaryPayment;

            //Draw Blips
            foreach (Vector3 location in JobCenterLocationList)
            {
                int Blip = API.AddBlipForCoord(location.X, location.Y, location.Z);
                API.SetBlipSprite(Blip, 304);
                API.SetBlipColour(Blip, 48);
                API.BeginTextCommandSetBlipName("STRING");
                API.AddTextComponentSubstringPlayerName("Job Center");
                API.EndTextCommandSetBlipName(Blip);
            }
        }

        private static async Task SalaryPayment()
        {
            await Delay(60000);
            Utilities.Constructors.playerBank = Utilities.Constructors.playerBank + Utilities.Constructors.playerSalary;
            API.SetNotificationTextEntry("STRING");
            API.SetNotificationColorNext(4);
            API.AddTextComponentString($"You have recieved your salary of ~g~${Utilities.Constructors.playerSalary.ToString()}");
            API.SetTextScale(0.5f, 0.5f);
            API.SetNotificationMessage("CHAR_BANK_MAZE", "CHAR_BANK_MAZE", false, 0, "ACCOUNT ALERT", "SALARY RECIEVED");
            API.DrawNotification(true, false);
            await Delay(900000);
        }

        private static async Task CheckMarkers()
        {
            foreach (Vector3 location in JobCenterLocationList)
            {
                float Distance = World.GetDistance(Game.Player.Character.Position, location);
                if (Distance <= 1.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to open job menu");
                    if (API.IsControlJustPressed(0, 38))
                    {
                        Menus.JobMenu.jobmainMenu.Visible = true;
                    }
                }
                else
                {

                }
            }
        }

        private static async Task DrawMarkers()
        {
            foreach (Vector3 location in JobCenterLocationList)
            {
                API.DrawMarker(1, location.X, location.Y, location.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 3.0f, 3.0f, 3.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            }
        }
    }
}
