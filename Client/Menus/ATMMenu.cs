using CitizenFX.Core;
using CitizenFX.Core.UI;
using CitizenFX.Core.Native;
using NativeUI;
using System.Collections.Generic;

namespace client.Menus
{
    public class ATMMenu : BaseScript
    {
        public static MenuPool _atmmenuPool;
        public static UIMenu atmMenu;

        private void MainOptions(UIMenu menu)
        {
            //Transfer Amounts
            var amounts = new List<dynamic> { "$100", "$1,000", "$10,000", "$100,000" };

            var transferamounttobank = new UIMenuListItem("Transfer Amount to Bank", amounts, 0);
            atmMenu.AddItem(transferamounttobank);
            atmMenu.OnListSelect += (sender, item, index) =>
            {
                if (item == transferamounttobank)
                {
                    if (transferamounttobank.CurrentItem() == "$100")
                    {
                        if (Utilities.Constructors.playerMoney >= 100)
                        {
                            //Transfer to the bank
                            Utilities.Constructors.playerBank = Utilities.Constructors.playerBank + 100;

                            //Remove the money from the cash
                            API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 100);
                        }
                        
                    }

                    if (transferamounttobank.CurrentItem() == "$1,000")
                    {
                        if (Utilities.Constructors.playerMoney >= 1000)
                        {
                            //Transfer to the bank
                            Utilities.Constructors.playerBank = Utilities.Constructors.playerBank + 1000;

                            //Remove the money from the cash
                            API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 1000);
                        }  
                    }

                    if (transferamounttobank.CurrentItem() == "$10,000")
                    {
                        if (Utilities.Constructors.playerMoney >= 10000)
                        {
                            //Transfer to the bank
                            Utilities.Constructors.playerBank = Utilities.Constructors.playerBank + 10000;

                            //Remove the money from the cash
                            API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 10000);
                        }
                    }

                    if (transferamounttobank.CurrentItem() == "$100,000")
                    {
                        if (Utilities.Constructors.playerMoney >= 100000)
                        {
                            //Transfer to the bank
                            Utilities.Constructors.playerBank = Utilities.Constructors.playerBank + 100000;

                            //Remove the money from the cash
                            API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 100000);
                        }
                    }
                }
            };

            var transferamounttocash = new UIMenuListItem("Transfer Amount to Cash", amounts, 0);
            atmMenu.AddItem(transferamounttocash);
            atmMenu.OnListSelect += (sender, item, index) =>
            {
                if (item == transferamounttocash)
                {
                    if (transferamounttocash.CurrentItem() == "$100")
                    {
                        if (Utilities.Constructors.playerBank >= 100)
                        {
                            //Transfer to the bank
                            Utilities.Constructors.playerBank = Utilities.Constructors.playerBank - 100;

                            //Remove the money from the cash
                            API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney + 100);
                        }

                    }

                    if (transferamounttocash.CurrentItem() == "$1,000")
                    {
                        if (Utilities.Constructors.playerBank >= 1000)
                        {
                            //Transfer to the bank
                            Utilities.Constructors.playerBank = Utilities.Constructors.playerBank - 1000;

                            //Remove the money from the cash
                            API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney + 1000);
                        }
                    }

                    if (transferamounttocash.CurrentItem() == "$10,000")
                    {
                        if (Utilities.Constructors.playerBank >= 10000)
                        {
                            //Transfer to the bank
                            Utilities.Constructors.playerBank = Utilities.Constructors.playerBank - 10000;

                            //Remove the money from the cash
                            API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney + 10000);
                        }
                    }

                    if (transferamounttocash.CurrentItem() == "$100,000")
                    {
                        if (Utilities.Constructors.playerBank >= 100000)
                        {
                            //Transfer to the bank
                            Utilities.Constructors.playerBank = Utilities.Constructors.playerBank - 100000;

                            //Remove the money from the cash
                            API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney + 100000);
                        }
                    }
                }
            };

            var transfertobank = new UIMenuItem("Transfer All to Bank");
            atmMenu.AddItem(transfertobank);
            atmMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == transfertobank)
                {
                    //Transfer to the bank
                    Utilities.Constructors.playerBank = Utilities.Constructors.playerBank + Utilities.Constructors.playerMoney;

                    //Remove the money from the cash
                    API.SetPedMoney(API.GetPlayerPed(-1), 0);
                }
            };

            var transfertocash = new UIMenuItem("Transfer All to Cash");
            atmMenu.AddItem(transfertocash);
            atmMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == transfertocash)
                {
                    //Transfer to cash
                    API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney + Utilities.Constructors.playerBank);

                    //Set Bank to 0
                    Utilities.Constructors.playerBank = 0;
                }
            };
        }

        public ATMMenu()
        {
            _atmmenuPool = new MenuPool();
            atmMenu = new UIMenu("ATM", "~p~Freedom Framework ~w~by ~b~Abel Gaming");
            _atmmenuPool.Add(atmMenu);

            MainOptions(atmMenu);

            _atmmenuPool.MouseEdgeEnabled = false;
            _atmmenuPool.ControlDisablingEnabled = false;
            _atmmenuPool.RefreshIndex();

            Tick += async () =>
            {
                _atmmenuPool.ProcessMenus();
            };
        }
    }
}
