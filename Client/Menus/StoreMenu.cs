using CitizenFX.Core;
using CitizenFX.Core.UI;
using CitizenFX.Core.Native;
using NativeUI;
using System.Collections.Generic;

namespace client.Menus
{
    public class StoreMenu : BaseScript
    {
        public static MenuPool _storemenuPool;
        public static UIMenu storeMenu;

        private void Drinks(UIMenu menu)
        {
            var drinks = _storemenuPool.AddSubMenu(menu, "Drinks");
            for (int i = 0; i < 1; i++) ;

            drinks.MouseEdgeEnabled = false;
            drinks.ControlDisablingEnabled = false;

            var cola = new UIMenuItem("Buy Cola");
            cola.SetRightLabel("$2");
            drinks.AddItem(cola);
            drinks.OnItemSelect += (sender, item, index) =>
            {
                if (item == cola)
                {
                    if (Utilities.Constructors.playerMoney >= 2)
                    {
                        //Take Away Money
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 2);

                        //Give Item
                        Utilities.Constructors.Colas = Utilities.Constructors.Colas + 1;

                        //Refresh Main
                        MainMenu._menuPool.RefreshIndex();
                    }
                }
            };

            var water = new UIMenuItem("Buy Water");
            water.SetRightLabel("$1");
            drinks.AddItem(water);
            drinks.OnItemSelect += (sender, item, index) =>
            {
                if (item == water)
                {
                    if (Utilities.Constructors.playerMoney >= 1)
                    {
                        //Take Away Money
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 1);

                        //Give Item
                        Utilities.Constructors.Waters = Utilities.Constructors.Waters + 1;

                        //Refresh Main
                        MainMenu._menuPool.RefreshIndex();
                    }
                }
            };
        }

        private void Food(UIMenu menu)
        {
            var food = _storemenuPool.AddSubMenu(menu, "Food");
            for (int i = 0; i < 1; i++) ;

            food.MouseEdgeEnabled = false;
            food.ControlDisablingEnabled = false;

            var bread = new UIMenuItem("Buy Bread");
            bread.SetRightLabel("$1");
            food.AddItem(bread);
            food.OnItemSelect += (sender, item, index) =>
            {
                if (item == bread)
                {
                    if (Utilities.Constructors.playerMoney >= 1)
                    {
                        //Take Away Money
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 1);

                        //Give Item
                        Utilities.Constructors.Bread = Utilities.Constructors.Bread + 1;

                        //Refresh Main
                        MainMenu._menuPool.RefreshIndex();
                    }
                }
            };
        }

        public StoreMenu()
        {
            _storemenuPool = new MenuPool();
            storeMenu = new UIMenu("Job Menu", "~p~Freedom Framework ~w~by ~b~Abel Gaming");
            _storemenuPool.Add(storeMenu);

            Drinks(storeMenu);
            Food(storeMenu);

            _storemenuPool.MouseEdgeEnabled = false;
            _storemenuPool.ControlDisablingEnabled = false;
            _storemenuPool.RefreshIndex();

            Tick += async () =>
            {
                _storemenuPool.ProcessMenus();
            };
        }
    }
}
