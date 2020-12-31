using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace client.Functions
{
    public class ATMMachines : BaseScript
    {
        private static string atm1 = "prop_atm_01";
        private static string atm2 = "prop_atm_02";
        private static string atm3 = "prop_atm_03";
        private static string atm4 = "prop_fleeca_atm";
        public ATMMachines()
        {
            Tick += ATM1Check;
            Tick += ATM2Check;
            Tick += ATM3Check;
            Tick += ATM4Check;
        }

        private static async Task ATM1Check()
        {
            //Define Player
            Ped player = Game.Player.Character;

            //Get closest atm
            int atm1int = API.GetClosestObjectOfType(player.Position.X, player.Position.Y, player.Position.Z, 5f, (uint)API.GetHashKey(atm1), false, true, true);

            //Get coords
            Vector3 atmcoords = API.GetEntityCoords(atm1int, false);

            //Get Distance
            float distance = World.GetDistance(player.Position, atmcoords);

            if (distance <= 2.0f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to use this ATM");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    Menus.ATMMenu.atmMenu.Visible = true;
                }
            }
        }

        private static async Task ATM2Check()
        {
            //Define Player
            Ped player = Game.Player.Character;

            //Get closest atm
            int atm1int = API.GetClosestObjectOfType(player.Position.X, player.Position.Y, player.Position.Z, 5f, (uint)API.GetHashKey(atm2), false, true, true);

            //Get coords
            Vector3 atmcoords = API.GetEntityCoords(atm1int, false);

            //Get Distance
            float distance = World.GetDistance(player.Position, atmcoords);

            if (distance <= 2.0f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to use this ATM");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    Menus.ATMMenu.atmMenu.Visible = true;
                }
            }
        }

        private static async Task ATM3Check()
        {
            //Define Player
            Ped player = Game.Player.Character;

            //Get closest atm
            int atm1int = API.GetClosestObjectOfType(player.Position.X, player.Position.Y, player.Position.Z, 5f, (uint)API.GetHashKey(atm3), false, true, true);

            //Get coords
            Vector3 atmcoords = API.GetEntityCoords(atm1int, false);

            //Get Distance
            float distance = World.GetDistance(player.Position, atmcoords);

            if (distance <= 2.0f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to use this ATM");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    Menus.ATMMenu.atmMenu.Visible = true;
                }
            }
        }

        private static async Task ATM4Check()
        {
            //Define Player
            Ped player = Game.Player.Character;

            //Get closest atm
            int atm1int = API.GetClosestObjectOfType(player.Position.X, player.Position.Y, player.Position.Z, 5f, (uint)API.GetHashKey(atm4), false, true, true);

            //Get coords
            Vector3 atmcoords = API.GetEntityCoords(atm1int, false);

            //Get Distance
            float distance = World.GetDistance(player.Position, atmcoords);

            if (distance <= 2.0f)
            {
                Screen.DisplayHelpTextThisFrame("Press ~INPUT_PICKUP~ to use this ATM");
                if (Game.IsControlJustPressed(0, Control.Pickup))
                {
                    Menus.ATMMenu.atmMenu.Visible = true;
                }
            }
        }
    }
}
