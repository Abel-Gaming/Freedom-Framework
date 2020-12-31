using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.NaturalMotion;
using CitizenFX.Core.UI;

namespace client.Modules
{
    public class PoliceJob : BaseScript
    {
        public static int TicketRecipientID;

        private static bool IsPlayerCop = false;
        private static List<Vector3> policeStationList;

        public PoliceJob()
        {
            //Add Stations
            StationList();

            //Add Chat
            Chat();

            //Tick
            Tick += JobCheck;
            Tick += DrawMarkers;
            Tick += CheckMarkers;
        }

        private void Chat()
        {
            //Commands
            API.RegisterCommand("ticket", new Action<int, List<object>, string>((src, args, raw) =>
            {
                Player p = new PlayerList()[src];
                var argList = args.Select(o => o.ToString()).ToList();
                if (argList.Any())
                {
                    if (Utilities.Constructors.playerJob == "Police")
                    {
                        string displayString = string.Join(" ", argList.ToArray());
                        TicketRecipientID = int.Parse(displayString);
                        Menus.TicketMenu.ticketMenu.Visible = true;
                    }
                    else
                    {
                        Screen.ShowNotification("~r~[ERROR]~w~ You are not a police officer");
                    }
                }
            }), false);

            //Suggestions
            TriggerEvent("chat:addSuggestion", "/ticket", "Player ID", new[]
            {
                new { name="player", help="Player ID" }
            });
        }

        private void StationList()
        {
            policeStationList = new List<Vector3>();

            policeStationList.Add(new Vector3(1852.26f, 3690.03f, 34.28f));
            policeStationList.Add(new Vector3(-448.95f, 6011.49f, 31.72f));
            policeStationList.Add(new Vector3(442.02f, -976.77f, 30.69f));
            policeStationList.Add(new Vector3(826.46f, -1290.07f, 28.24f));
            policeStationList.Add(new Vector3(-560.92f, -133.48f, 38.08f));
            policeStationList.Add(new Vector3(-1108.54f, -845.19f, 19.32f));
        }

        private static async Task DrawMarkers()
        {
            if (IsPlayerCop)
            {
                foreach (Vector3 location in policeStationList)
                {
                    API.DrawMarker(1, location.X, location.Y, location.Z, 0.0f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 1.0f, 1.0f, 1.0f, 65, 150, 245, 100, false, true, 2, false, null, null, false);
                }
            }          
        }

        private static async Task CheckMarkers()
        {
            if (IsPlayerCop)
            {
                foreach (Vector3 location in policeStationList)
                {
                    float Distance = World.GetDistance(Game.Player.Character.Position, location);
                    if (Distance <= 0.5f)
                    {
                        Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to open police menu");
                        if (API.IsControlJustPressed(0, 38))
                        {
                            Menus.PoliceMenu.policeMenu.Visible = true;
                        }
                    }
                }
            }      
        }

        private static async Task JobCheck()
        {
            if (Utilities.Constructors.playerJob == "Police")
            {
                IsPlayerCop = true;
            }
            else
            {
                IsPlayerCop = false;
            }
        }
    }
}
