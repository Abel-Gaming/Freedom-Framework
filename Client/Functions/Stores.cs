using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace client.Functions
{
    public class Stores : BaseScript
    {
        private static List<Vector3> storelocationList;
        public Stores()
        {
            //Create List
            storelocationList = new List<Vector3>();

            //Add Locations
            storelocationList.Add(new Vector3(26.45f, -1347.14f, 29.5f)); // STRAWBERRY / INNOCENCE BLVD
            storelocationList.Add(new Vector3(-1820.6f, 792.18f, 138.12f)); // BY UNIVERSITY
            storelocationList.Add(new Vector3(2557.16f, 382.62f, 108.62f)); // 15 SOUTH BOUND (CENTER)
            storelocationList.Add(new Vector3(2678.95f, 3280.76f, 55.24f)); // 13 SOUTH BOUND
            storelocationList.Add(new Vector3(1698.14f, 4924.79f, 42.06f)); // GRAPE SEED
            storelocationList.Add(new Vector3(1961.48f, 3740.93f, 32.34f)); // SANDY SHORES
            storelocationList.Add(new Vector3(1392.96f, 3604.36f, 34.98f)); // ACE LIQIOR
            storelocationList.Add(new Vector3(547.3f, 2671.41f, 42.16f)); // HARMONY 24/7
            storelocationList.Add(new Vector3(374.11f, 326.01f, 103.57f)); // CLINTON AVE
            storelocationList.Add(new Vector3(1163.4f, -324.03f, 69.21f)); // MIRROR PARK
            storelocationList.Add(new Vector3(-1223.51f, -907.01f, 12.33f)); // VESPUCCI CANALS SAN ANDREAS AVE
            storelocationList.Add(new Vector3(-707.91f, -914.6f, 19.22f)); // LITTLE SEOUL
            storelocationList.Add(new Vector3(-48.85f, -1757.57f, 29.42f)); // GROVE STREET

            //Tick
            Tick += DrawMarkers;
            Tick += CheckMarkers;

            //Draw Blips
            foreach (Vector3 location in storelocationList)
            {
                int Blip = API.AddBlipForCoord(location.X, location.Y, location.Z);
                API.SetBlipSprite(Blip, 52);
                API.BeginTextCommandSetBlipName("STRING");
                API.AddTextComponentSubstringPlayerName("Store");
                API.EndTextCommandSetBlipName(Blip);
            }
        }

        private static async Task CheckMarkers()
        {
            foreach (Vector3 location in storelocationList)
            {
                float Distance = World.GetDistance(Game.Player.Character.Position, location);
                if (Distance <= 0.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to open store menu");
                    if (API.IsControlJustPressed(0, 38))
                    {
                        Menus.StoreMenu.storeMenu.Visible = true;
                    }
                }
            }
        }

        private static async Task DrawMarkers()
        {
            foreach (Vector3 location in storelocationList)
            {
                API.DrawMarker(1, location.X, location.Y, location.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            }
        }
    }
}
