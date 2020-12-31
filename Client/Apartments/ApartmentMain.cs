using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.NaturalMotion;
using CitizenFX.Core.UI;

namespace client.Apartments
{
    public class ApartmentMain : BaseScript
    {
        public static List<Vector3> markerList;
        public static List<Vector3> exitMarkerList;

        //BASES
        public static Vector3 TwoCarGarage = new Vector3(173.2903f, -1003.6f, -99.65707f);
        public static Vector3 SixCarGarage = new Vector3(197.8153f, -1002.293f, -99.65749f);
        public static Vector3 TenCarGarage = new Vector3(229.9559f, -981.7928f, -99.66071f);
        public static Vector3 LowEndApartment = new Vector3(261.4586f, -998.8196f, -99.00863f); //Used
        public static Vector3 MediumEndApartment = new Vector3(347.2686f, -999.2955f, -99.19622f);

        //SPECIFIC
        public static Vector3 IntegrityWay28 = new Vector3(-18.07856f, -583.6725f, 79.46569f);
        public static Vector3 IntegrityWay30 = new Vector3(-35.31277f, -580.4199f, 88.71221f);
        public static Vector3 WildOatsDrive3655 = new Vector3(-169.286f, 486.4938f, 137.4436f); //Used

        public ApartmentMain()
        {
            //Create List
            markerList = new List<Vector3>();
            exitMarkerList = new List<Vector3>();

            //Add Coords to Markers
            markerList.Add(new Vector3(861.64f, -582.63f, 58.16f));
            markerList.Add(new Vector3(-175.83f, 502.43f, 137.42f));
            markerList.Add(new Vector3(1220.29f, -687.94f, 60.79f));

            //Add Coords to Exit
            exitMarkerList.Add(new Vector3(265.94f, -1003.21f, -99.01f));
            exitMarkerList.Add(new Vector3(-174.14f, 497.18f, 137.67f));
            exitMarkerList.Add(new Vector3(346.76f, -1011.29f, -99.2f));

            //Tick
            Tick += DrawMarkers;
            Tick += CheckMarkers;

            //Draw Blips
            foreach (Vector3 location in markerList)
            {
                int Blip = API.AddBlipForCoord(location.X, location.Y, location.Z);
                API.SetBlipSprite(Blip, 40);
                API.SetBlipColour(Blip, 2);
                API.BeginTextCommandSetBlipName("STRING");
                API.AddTextComponentSubstringPlayerName("Property");
                API.EndTextCommandSetBlipName(Blip);
            }
        }

        private static async Task CheckMarkers()
        {
            //West Mirror Drive
            float WestMirrorDrive = World.GetDistance(Game.Player.Character.Position, new Vector3(861.64f, -582.63f, 58.16f));
            if (WestMirrorDrive <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to enter house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    TriggerServerEvent("Freedom:EnterHouse");
                    Game.Player.Character.Position = LowEndApartment;
                }
            }

            float WestMirrorDriveExit = World.GetDistance(Game.Player.Character.Position, new Vector3(265.94f, -1003.21f, -99.01f));
            if (WestMirrorDriveExit <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to exit house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    TriggerServerEvent("Freedom:ExitHouse");
                    Game.Player.Character.Position = new Vector3(861.64f, -582.63f, 58.16f);
                }
            }

            //3655 Wild Oats Drive
            float WildOatsDriveEnter = World.GetDistance(Game.Player.Character.Position, new Vector3(-175.83f, 502.43f, 137.42f));
            if (WildOatsDriveEnter <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to enter house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    TriggerServerEvent("Freedom:EnterHouse");
                    Game.Player.Character.Position = WildOatsDrive3655;
                }
            }

            float WildOatsDriveExit = World.GetDistance(Game.Player.Character.Position, new Vector3(-174.14f, 497.18f, 137.67f));
            if (WildOatsDriveExit <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to exit house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    TriggerServerEvent("Freedom:ExitHouse");
                    Game.Player.Character.Position = new Vector3(-175.83f, 502.43f, 137.42f);
                }
            }

            //Mirror Park Blvd
            float MirrorParkBlvd = World.GetDistance(Game.Player.Character.Position, new Vector3(1220.29f, -687.94f, 60.79f));
            if (MirrorParkBlvd <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to enter house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    TriggerServerEvent("Freedom:EnterHouse");
                    Game.Player.Character.Position = MediumEndApartment;
                }
            }

            float MirrorParkBlvdExit = World.GetDistance(Game.Player.Character.Position, new Vector3(346.76f, -1011.29f, -99.2f));
            if (MirrorParkBlvdExit <= 0.5f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to exit house");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    TriggerServerEvent("Freedom:ExitHouse");
                    Game.Player.Character.Position = new Vector3(1220.29f, -687.94f, 60.79f);
                }
            }
        }

        private static async Task DrawMarkers()
        {
            foreach (Vector3 location in markerList)
            {
                API.DrawMarker(1, location.X, location.Y, location.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            }

            foreach (Vector3 location in exitMarkerList)
            {
                API.DrawMarker(1, location.X, location.Y, location.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
            }
        }
    }
}
