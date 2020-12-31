using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace client.Utilities
{
    public class UI : BaseScript
    {
        public UI()
        {
            Tick += DrawHUD;
        }

        private static async Task DrawHUD()
        {
            //Draws current money balance
            API.SetTextScale(0.6f, 0.6f);
            API.SetTextFont(7);
            API.SetTextProportional(true);
            API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
            API.SetTextOutline();
            API.SetTextEntry("STRING");
            API.AddTextComponentString($"Cash: ~g~${Constructors.playerMoney.ToString()}");
            API.DrawText(0.88f, 0.05f); //0.035 DIFFERENCE WITH SET FONT AND SCALE
            API.EndTextComponent();

            //Draws current bank balance
            API.SetTextScale(0.6f, 0.6f);
            API.SetTextFont(7);
            API.SetTextProportional(true);
            API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
            API.SetTextOutline();
            API.SetTextEntry("STRING");
            API.AddTextComponentString($"Bank: ~b~${Constructors.playerBank.ToString()}");
            API.DrawText(0.88f, 0.085f); //0.035 DIFFERENCE WITH SET FONT AND SCALE
            API.EndTextComponent();

            //Draws current job
            API.SetTextScale(0.6f, 0.6f);
            API.SetTextFont(7);
            API.SetTextProportional(true);
            API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
            API.SetTextOutline();
            API.SetTextEntry("STRING");
            API.AddTextComponentString($"{Constructors.playerJob}");
            API.DrawText(0.88f, 0.12f); //0.035 DIFFERENCE WITH SET FONT AND SCALE
            API.EndTextComponent();

            //Draw Speed
            if (Game.Player.Character.IsInVehicle())
            {
                //Get Speed
                float tempspeed = API.GetEntitySpeed(API.GetVehiclePedIsIn(API.GetPlayerPed(-1), false));
                float speed = (float)(tempspeed * 2.2369);

                //Draw Speed
                API.SetTextScale(0.5f, 0.5f);
                API.SetTextFont(0);
                API.SetTextProportional(true);
                API.SetTextColour((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue);
                API.SetTextOutline();
                API.SetTextEntry("STRING");
                API.AddTextComponentString("~y~Speed: ~b~" + Math.Floor(speed) + " ~w~MPH");
                API.DrawText(0.16f, 0.9225f); //0.035 DIFFERENCE WITH SET FONT AND SCALE
                API.EndTextComponent();
            }
        }
    }
}
