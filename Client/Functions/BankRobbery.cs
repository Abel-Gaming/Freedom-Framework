using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace client.Functions
{
    public class BankRobbery : BaseScript
    {
        private static List<Vector3> SmallBankLocations;
        private static List<Vector3> LargeBankLocations;
        private static int LargeBankPayout = 50000;
        private static int SmallBankPayout = 20000;

        public BankRobbery()
        {
            //Create Lists
            SmallBankLocations = new List<Vector3>();
            LargeBankLocations = new List<Vector3>();

            //Add Small Banks
            SmallBankLocations.Add(new Vector3(146.67f, -1044.86f, 29.38f)); // Vespucci Blvd / Elgin Ave
            SmallBankLocations.Add(new Vector3(311.08f, -283.23f, 54.17f)); // Meteor Street / Hawick Ave
            SmallBankLocations.Add(new Vector3(-2957.58f, 480.9f, 15.71f)); // Great Ocean Highway
            SmallBankLocations.Add(new Vector3(-106.85f, 6474.46f, 31.63f)); // Paleto Blvd
            SmallBankLocations.Add(new Vector3(1176.94f, 2711.73f, 38.1f)); // Route 68 [Harmony]

            //Add Large Banks
            LargeBankLocations.Add(new Vector3(254.2f, 225.79f, 101.88f)); // Downtown Vinewood / Alta Street

            //Tick
            Tick += DrawMarkers;
            Tick += CheckMarkers;

            //Draw Blips
            foreach (Vector3 location in SmallBankLocations)
            {
                int Blip = API.AddBlipForCoord(location.X, location.Y, location.Z);
                API.SetBlipSprite(Blip, 272);
                API.SetBlipColour(Blip, 2);
                API.BeginTextCommandSetBlipName("STRING");
                API.AddTextComponentSubstringPlayerName("Bank");
                API.EndTextCommandSetBlipName(Blip);
            }

            foreach (Vector3 location in LargeBankLocations)
            {
                int Blip = API.AddBlipForCoord(location.X, location.Y, location.Z);
                API.SetBlipSprite(Blip, 272);
                API.SetBlipColour(Blip, 2);
                API.BeginTextCommandSetBlipName("STRING");
                API.AddTextComponentSubstringPlayerName("Bank");
                API.EndTextCommandSetBlipName(Blip);
            }
        }

        private static async Task CheckMarkers()
        {
            foreach (Vector3 location in SmallBankLocations)
            {
                float Distance = World.GetDistance(Game.Player.Character.Position, location);
                if (Distance <= 0.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to begin robbery");
                    if (API.IsControlJustPressed(0, 38))
                    {
                        SmallBankRobbery(location);
                    }
                }
            }

            foreach (Vector3 location in LargeBankLocations)
            {
                float Distance = World.GetDistance(Game.Player.Character.Position, location);
                if (Distance <= 0.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to begin robbery");
                    if (API.IsControlJustPressed(0, 38))
                    {
                        LargeBankRobbery(location);
                    }
                }
            }
        }

        private static async Task DrawMarkers()
        {
            foreach (Vector3 location in SmallBankLocations)
            {
                API.DrawMarker(1, location.X, location.Y, location.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 255, 0, 0, 100, false, true, 2, false, null, null, false);
            }

            foreach (Vector3 location in LargeBankLocations)
            {
                API.DrawMarker(1, location.X, location.Y, location.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 255, 0, 0, 100, false, true, 2, false, null, null, false);
            }
        }

        private static async void SmallBankRobbery(Vector3 location)
        {
            //Get Street Name
            string street = World.GetStreetName(location);

            //Trigger Global Notification
            TriggerServerEvent("Freedom:BankRobberyStarting", street);

            //Show Help Message
            Screen.DisplayHelpTextThisFrame("Robbery has begun. This robbery will take ~r~45~w~ seconds");

            //Wait 45 seconds
            await Delay(45000);

            //Execute Completion Code
            SmallBankRobberyComplete(street);
        }

        private static async void LargeBankRobbery(Vector3 location)
        {
            //Get Street Name
            string street = World.GetStreetName(location);

            //Trigger Global Notification
            TriggerServerEvent("Freedom:BankRobberyStarting", street);

            //Show Help Message
            Screen.DisplayHelpTextThisFrame("Robbery has begun. This robbery will take ~r~90~w~ seconds");

            //Wait 90 seconds
            await Delay(90000);

            //Execute Completion Code
            LargeBankRobberyComplete(street);
        }

        private static void SmallBankRobberyComplete(string street)
        {
            //Trigger Global Notification
            TriggerServerEvent("Freedom:BankRobberyComplete", street);

            //Show Notification
            Screen.DisplayHelpTextThisFrame("Robbery Complete");
            Screen.ShowNotification($"~g~+${SmallBankPayout.ToString()}");

            //Add Money to Player Bank
            Utilities.Constructors.playerBank = Utilities.Constructors.playerBank + SmallBankPayout;
        }

        private static void LargeBankRobberyComplete(string street)
        {
            //Trigger Global Notification
            TriggerServerEvent("Freedom:BankRobberyComplete", street);

            //Show Notification
            Screen.DisplayHelpTextThisFrame("Robbery Complete. ~o~RUN!");

            //Add Money to Player Bank
            Utilities.Constructors.playerBank = Utilities.Constructors.playerBank + LargeBankPayout;
        }
    }
}
