using System;
using System.Collections.Generic;
using System.Linq;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace client.Utilities
{
    public class Commands : BaseScript
    {
        public static int PaymentRecipientID;
        public Commands()
        {
            //Input Commands
            API.RegisterCommand("givecash", new Action<int, List<object>, string>((src, args, raw) =>
            {
                Player p = new PlayerList()[src];
                var argList = args.Select(o => o.ToString()).ToList();
                if (argList.Any())
                {
                    string displayString = string.Join(" ", argList.ToArray());
                    if (Constructors.isAdmin)
                    {
                        int amount = int.Parse(displayString);
                        API.SetPedMoney(API.GetPlayerPed(-1), Constructors.playerMoney + amount);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~[ERROR] ~w~You are not an admin!");
                    }
                }
            }), false);
            API.RegisterCommand("pay", new Action<int, List<object>, string>((src, args, raw) =>
            {
                Player p = new PlayerList()[src];
                var argList = args.Select(o => o.ToString()).ToList();
                if (argList.Any())
                {
                    string displayString = string.Join(" ", argList.ToArray());
                    PaymentRecipientID = int.Parse(displayString);
                    Menus.PaymentMenu.paymentMenu.Visible = true;
                }
            }), false);

            //Commands
            API.RegisterCommand("save", new Action(SaveData), false); //Allows the player to save data before the two minutes
            API.RegisterCommand("load_player_data", new Action(LoadData), false); //Allows the player to reload their data
            API.RegisterCommand("dv", new Action(DeleteVehicle), false); //Deletes current vehicle
            API.RegisterCommand("devMenu", new Action(DevMenu), false);

            //Suggestions
            TriggerEvent("chat:addSuggestion", "/givecash", "Cash Amount", new[]
            {
                new { name="amount", help="Insert Amount" }
            });
            TriggerEvent("chat:addSuggestion", "/pay", "Player ID", new[]
            {
                new { name="ID", help="Player ID" }
            });
        }

        private static void DevMenu()
        {
            if (Constructors.isAdmin)
            {
                Dev.DevMenu.devMenu.Visible = true;
            }
            else
            {
                Screen.ShowNotification("~r~[ERROR] ~w~You are not an admin!");
            }
        }

        private static void DeleteVehicle()
        {
            if (Game.Player.Character.IsInVehicle())
            {
                Game.Player.Character.CurrentVehicle.Delete();
                Screen.ShowNotification("~r~Vehicle deleted");
            }
        }

        private static void LoadData()
        {
            //Show Notification
            Screen.ShowNotification("Loading Player Data");

            //Get Player Info
            TriggerServerEvent("Freedom:GetPlayerInfo");

            //Get Player Info
            TriggerServerEvent("Freedom:GetPlayerInventory");
        }

        private static void SaveData()
        {
            //Update Database
            string cash = Utilities.Constructors.playerMoney.ToString();
            string bank = Utilities.Constructors.playerBank.ToString();
            string job = Utilities.Constructors.playerJob;
            string colas = Utilities.Constructors.Colas.ToString();
            string water = Utilities.Constructors.Waters.ToString();
            string bread = Utilities.Constructors.Bread.ToString();
            TriggerServerEvent("Freedom:SavePlayerData", cash, bank, job, colas, water, bread);
        }
    }
}
