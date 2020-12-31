using CitizenFX.Core;
using CitizenFX.Core.UI;
using CitizenFX.Core.Native;
using System;

namespace client.Utilities
{
    public class Constructors : BaseScript
    {
        //Player Info
        public static bool isAdmin = false;
        public static string playerName;
        public static Vector3 playerLocation;

        //Player Money
        public static int playerMoney;
        public static int playerBank;

        //Player Job
        public static int playerSalary;
        public static string playerJob;

        //Player Inventory
        public static int Colas;
        public static int Waters;
        public static int Bread;

        //Script Info
        public static bool BalanceLoaded = false;

        public Constructors()
        {
            EventHandlers.Add("Freedom:PlayerInfo", new Action<string, string, string, string, string>(RecieveInfo));
            EventHandlers.Add("Freedom:PlayerInventory", new Action<string, string, string>(RecieveInventory));
            EventHandlers.Add("Freedom:UpdatePlayerJob", new Action<string>(UpdateJobInfo));
        }

        private static void UpdateJobInfo(string GetJobSalary)
        {
            playerSalary = int.Parse(GetJobSalary);
            API.SetNotificationTextEntry("STRING");
            API.SetNotificationColorNext(4);
            API.AddTextComponentString($"You are now working as ~b~{playerJob}");
            API.SetTextScale(0.5f, 0.5f);
            API.SetNotificationMessage("CHAR_SOCIAL_CLUB", "CHAR_SOCIAL_CLUB", false, 0, "JOB UPDATED", "NEW JOB");
            API.DrawNotification(true, false);
        }

        private static void RecieveInventory(string GetColas, string GetWater, string GetBread)
        {
            Colas = int.Parse(GetColas);
            Waters = int.Parse(GetWater);
            Bread = int.Parse(GetBread);
        }

        private static void RecieveInfo(string GetPlayerCash, string GetPlayerBank, string GetPlayerAdmin, string GetPlayerJob, string GetJobSalary)
        {
            playerBank = int.Parse(GetPlayerBank);
            playerMoney = int.Parse(GetPlayerCash);
            playerSalary = int.Parse(GetJobSalary);
            playerJob = GetPlayerJob;
            API.SetPedMoney(API.GetPlayerPed(-1), playerMoney);
            if (GetPlayerAdmin == "true")
            {
                isAdmin = true;
                Screen.ShowNotification("~g~Admin Loaded");
            }
            BalanceLoaded = true;
        }
    }
}