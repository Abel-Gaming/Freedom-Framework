using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.NaturalMotion;
using CitizenFX.Core.UI;

namespace client
{
    public class Main : BaseScript
    {
        public Main()
        {
            Debug.WriteLine("Freedom Framework Loaded");

            Tick += playerInfo;
            Tick += updateInfo;
        }

        private static async Task updateInfo()
        {
            if (Utilities.Constructors.BalanceLoaded)
            {
                //Update Database
                string cash = Utilities.Constructors.playerMoney.ToString();
                string bank = Utilities.Constructors.playerBank.ToString();
                string job = Utilities.Constructors.playerJob;
                int colas = Utilities.Constructors.Colas;
                int water = Utilities.Constructors.Waters;
                int bread = Utilities.Constructors.Bread;
                TriggerServerEvent("Freedom:SavePlayerData", cash, bank, job, colas, water, bread);
                await Delay(60000); //Update every minute
            }
        }

        private static async Task playerInfo()
        {
            Utilities.Constructors.playerMoney = API.GetPedMoney(API.GetPlayerPed(-1));
        }
    }
}
