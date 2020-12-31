using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.NaturalMotion;
using CitizenFX.Core.UI;

namespace client.Modules
{
    public class Activities : BaseScript
    {
        public static List<Vector3> MovieTheaterLocations;
        private static Vector3 ExitLocation = new Vector3(-1416.59f, -256.87f, 16.78f);
        public Activities()
        {
            MovieTheaters();

            //Tick
            Tick += DrawMarkers;
            Tick += CheckMarkers;

            //Draw Movie Theater Blips
            foreach (Vector3 location in MovieTheaterLocations)
            {
                int Blip = API.AddBlipForCoord(location.X, location.Y, location.Z);
                API.SetBlipSprite(Blip, 135);
                API.SetBlipColour(Blip, 46);
                API.BeginTextCommandSetBlipName("STRING");
                API.AddTextComponentSubstringPlayerName("Movie Theater");
                API.EndTextCommandSetBlipName(Blip);
            }
        }

        private static async Task CheckMarkers()
        {
            foreach (Vector3 location in MovieTheaterLocations)
            {
                float Distance = World.GetDistance(Game.Player.Character.Position, location);
                if (Distance <= 0.5f)
                {
                    Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to enter theater");
                    if (API.IsControlJustPressed(0, 38))
                    {
                        Game.Player.Character.Position = new Vector3(-1427.299f, -245.1012f, 16.8039f);
                    }
                }
            }

            float ExitDistance = World.GetDistance(Game.Player.Character.Position, ExitLocation);
            if (ExitDistance <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to exit theater");
                if (API.IsControlJustPressed(0, 38))
                {
                    Game.Player.Character.Position = new Vector3(-1423.3f, -214.23f, 46.5f);
                }
            }
        }

        private static async Task DrawMarkers()
        {
            //Exit Marker
            API.DrawMarker(1, ExitLocation.X, ExitLocation.Y, ExitLocation.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);

            foreach (Vector3 location in MovieTheaterLocations)
            {        
                API.DrawMarker(1, location.X, location.Y, location.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);            
            }
        }

        private static void MovieTheaters()
        {
            //Create List
            MovieTheaterLocations = new List<Vector3>();

            //Add Coords
            MovieTheaterLocations.Add(new Vector3(335.25f, 179.83f, 103.06f));
            MovieTheaterLocations.Add(new Vector3(-1423.3f, -214.23f, 46.5f));
        }
    }
}
