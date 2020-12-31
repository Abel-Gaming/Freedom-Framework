using System;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace client.Utilities
{
    public class Events : BaseScript
    {
        public Events()
        {
            //Internal Events
            EventHandlers["playerSpawned"] += new Action(playerSpawned);
            EventHandlers["onPlayerDied"] += new Action(playerDied);
            EventHandlers["onPlayerKilled"] += new Action(playerKilled);

            //External Events
            EventHandlers["Freedom:PaymentRecieved"] += new Action<string, string>(PaymentRecieved);
            EventHandlers["Freedom:PaymentSent"] += new Action<string, string>(PaymentSent);

            //Bank Robbery Events
            EventHandlers["Freedom:BankRobberyStartingGlobal"] += new Action<string>(BankRobberyStarting);
            EventHandlers["Freedom:BankRobberyCompleteGlobal"] += new Action<string>(BankRobberyComplete);

            //Tickets
            EventHandlers["Freedom:TicketIssued"] += new Action<string, int>(TicketIssued);
            EventHandlers["Freedom:TicketRecieved"] += new Action<string, int>(TicketRecieved);

            //Errors
            EventHandlers["Freedom:CannotPayYourself"] += new Action(CannotPayYourself);
            EventHandlers["Freedom:CannotTicketYourself"] += new Action(CannotTicketYourself);
        }

        private static void TicketRecieved(string playername, int fine)
        {
            Screen.ShowNotification($"You have recieved a ticket from ~b~{playername}~w~ for ~g~${fine.ToString()}");
            Constructors.playerBank = Constructors.playerBank - fine;
        }

        private static void TicketIssued(string recipientname, int fine)
        {
            Screen.ShowNotification($"You have issued a ticket to ~b~{recipientname}~w~ for ~g~${fine.ToString()}");
        }

        private static void CannotTicketYourself()
        {
            Screen.ShowNotification("~r~[ERROR] ~w~You cannot ticket yourself");
        }

        private static void CannotPayYourself()
        {
            Screen.ShowNotification("~r~[ERROR] ~w~You cannot pay yourself");
        }

        private static void BankRobberyStarting(string street)
        {
            Screen.ShowNotification($"A bank robbery has started at ~b~{street}");
        }

        private static void BankRobberyComplete(string street)
        {
            Screen.ShowNotification($"A bank robbery has just been completed at ~b~{street}");
        }

        private static void PaymentSent(string recipientname, string amount)
        {
            //Turn Amount Into Int
            int amountint = int.Parse(amount);

            //Display Notification
            Screen.ShowNotification($"You have sent ~g~${amount}~w~ to ~b~{recipientname}");

            //Change Cash
            API.SetPedMoney(API.GetPlayerPed(-1), Constructors.playerMoney - amountint);
            
            //Update Database
            string cash = Constructors.playerMoney.ToString();
            string bank = Constructors.playerBank.ToString();
            TriggerServerEvent("Freedom:SavePlayerData", cash, bank);

        }

        private static void PaymentRecieved(string playername, string amount)
        {
            //Turn Amount Into Int
            int amountint = int.Parse(amount);

            //Display Notification
            Screen.ShowNotification($"You have recieved ~g~${amount}~w~ from ~b~{playername}");

            //Change Cash
            API.SetPedMoney(API.GetPlayerPed(-1), Constructors.playerMoney + amountint);

            //Update Database
            string cash = Constructors.playerMoney.ToString();
            string bank = Constructors.playerBank.ToString();
            TriggerServerEvent("Freedom:SavePlayerData", cash, bank);
        }

        private static void playerSpawned()
        {
            //Get Player Info
            TriggerServerEvent("Freedom:GetPlayerInfo");

            //Get Player Info
            TriggerServerEvent("Freedom:GetPlayerInventory");

            //Show Notification
            Screen.ShowNotification("Welcome to ~p~Freedom Framework");
        }

        private static void playerDied()
        {

        }

        private static void playerKilled()
        {

        }
    }
}
