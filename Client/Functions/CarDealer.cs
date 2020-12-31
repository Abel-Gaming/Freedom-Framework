using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace client.Functions
{
    public class CarDealer : BaseScript
    {
        private static List<Vector3> purchaselocationList;
        private static List<Vector3> selllocationList;
        public CarDealer()
        {
            //Create List
            purchaselocationList = new List<Vector3>();
            selllocationList = new List<Vector3>();

            //Add Coords to Purchase List
            purchaselocationList.Add(new Vector3(-57.54f, -1096.47f, 26.42f));

            //Add Coords to Sell List
            selllocationList.Add(new Vector3(-47.84f, -1116.63f, 26.07f));

            //Tick
            Tick += DrawMarkers;
            Tick += CheckMarkers;

            //Draw Blips
            foreach (Vector3 location in purchaselocationList)
            {
                int Blip = API.AddBlipForCoord(location.X, location.Y, location.Z);
                API.SetBlipSprite(Blip, 225);
                API.BeginTextCommandSetBlipName("STRING");
                API.AddTextComponentSubstringPlayerName("Car Dealer");
                API.EndTextCommandSetBlipName(Blip);
            }
        }

        private static async Task CheckMarkers()
        {
            foreach (Vector3 location in purchaselocationList)
            {
                float Distance = World.GetDistance(Game.Player.Character.Position, location);
                if (Distance <= 0.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to open vehicle menu");
                    if (API.IsControlJustPressed(0, 38))
                    {
                        Menus.VehicleMenu.vehicleMenu.Visible = true;  
                    }
                }
                else
                {
                    
                }
            }

            foreach (Vector3 location in selllocationList)
            {
                float SellDistance = World.GetDistance(Game.Player.Character.Position, location);
                if (SellDistance <= 1.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to sell current vehicle");
                    if (API.IsControlJustPressed(0, 38))
                    {
                        if (Game.Player.Character.IsInVehicle())
                        {
                            Screen.ShowNotification("~g~Vehicle Sold");
                            API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney + 1500);
                            Game.Player.Character.CurrentVehicle.Delete();
                        }
                        else
                        {
                            Screen.ShowNotification("~r~You are not in a vehicle");
                        }
                    }
                }
                else
                {

                }
            }
        }

        private static async Task DrawMarkers()
        {
            foreach (Vector3 location in purchaselocationList)
            {
                API.DrawMarker(1, location.X, location.Y, location.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            }

            foreach (Vector3 location in selllocationList)
            {
                API.DrawMarker(1, location.X, location.Y, location.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 3.0f, 3.0f, 3.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            }
        }
    }
}
