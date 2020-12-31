using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace client.Functions
{
    public class Ammunations : BaseScript
    {
        public static List<Vector3> ammunationlocationList;
        public static bool CanOpenWeaponMenu = false;
        public Ammunations()
        {
            //Create List
            ammunationlocationList = new List<Vector3>();

            //Add Coords
            ammunationlocationList.Add(new Vector3(21.91f, -1107.16f, 29.8f));
            ammunationlocationList.Add(new Vector3(252.09f, -49.84f, 69.94f));
            ammunationlocationList.Add(new Vector3(-662.32f, -935.08f, 21.83f));
            ammunationlocationList.Add(new Vector3(-1305.93f, -394.03f, 36.7f));
            ammunationlocationList.Add(new Vector3(-1117.65f, 2698.47f, 18.55f));
            ammunationlocationList.Add(new Vector3(1693.69f, 3759.67f, 34.71f));

            //Tick
            Tick += DrawMarkers;
            Tick += CheckMarkers;

            //Draw Blips
            foreach (Vector3 location in ammunationlocationList)
            {
                int Blip = API.AddBlipForCoord(location.X, location.Y, location.Z);
                API.SetBlipSprite(Blip, 110);
            }
        }

        private static async Task CheckMarkers()
        {
            foreach (Vector3 location in ammunationlocationList)
            {
                float Distance = World.GetDistance(Game.Player.Character.Position, location);
                if (Distance <= 0.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to open weapon menu");
                    if (API.IsControlJustPressed(0, 38))
                    {
                        Menus.WeaponMenu.weaponMenu.Visible = true;
                    }
                }
            }
        }

        private static async Task DrawMarkers()
        {
            foreach (Vector3 location in ammunationlocationList)
            {
                API.DrawMarker(1, location.X, location.Y, location.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            }
        }
    }
}
