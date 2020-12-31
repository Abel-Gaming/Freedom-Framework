using CitizenFX.Core;
using CitizenFX.Core.Native;
using NativeUI;
using System.Collections.Generic;

namespace client.Menus
{
    public class MainMenu : BaseScript
    {
        public static MenuPool _menuPool;
        public static UIMenu mainMenu;

        private static UIMenuItem bread;
        private static UIMenuItem cola;
        private static UIMenuItem water;


        private void Inventory(UIMenu menu)
        {
            var inventory = _menuPool.AddSubMenu(menu, "Inventory");
            for (int i = 0; i < 1; i++) ;

            inventory.MouseEdgeEnabled = false;
            inventory.ControlDisablingEnabled = false;

            var drinks = _menuPool.AddSubMenu(inventory, "Drinks");
            for (int i = 0; i < 1; i++) ;

            drinks.MouseEdgeEnabled = false;
            drinks.ControlDisablingEnabled = false;

            cola = new UIMenuItem("Use Cola");
            cola.SetRightLabel($"{Utilities.Constructors.Colas.ToString()}");
            drinks.AddItem(cola);
            drinks.OnItemSelect += (sender, item, index) =>
            {
                if (item == cola)
                {
                    if (Utilities.Constructors.Colas >= 1)
                    {
                        //Take Item
                        Utilities.Constructors.Colas = Utilities.Constructors.Colas - 1;

                        //Refresh
                        cola.SetRightLabel($"{Utilities.Constructors.Colas.ToString()}");

                        //Save Data
                        string colas = Utilities.Constructors.Colas.ToString();
                        TriggerServerEvent("Freedom:SavePlayerData", colas);
                    }     
                }
            };

            water = new UIMenuItem("Use Water");
            water.SetRightLabel($"{Utilities.Constructors.Waters.ToString()}");
            drinks.AddItem(water);
            drinks.OnItemSelect += (sender, item, index) =>
            {
                if (item == water)
                {
                    if (Utilities.Constructors.Waters >= 1)
                    {
                        //Take Item
                        Utilities.Constructors.Waters = Utilities.Constructors.Waters - 1;

                        //Refresh
                        water.SetRightLabel($"{Utilities.Constructors.Waters.ToString()}");

                        //Save Data
                        string waters = Utilities.Constructors.Waters.ToString();
                        TriggerServerEvent("Freedom:SavePlayerData", waters);
                    }
                }
            };

            var food = _menuPool.AddSubMenu(inventory, "Food");
            for (int i = 0; i < 1; i++) ;

            food.MouseEdgeEnabled = false;
            food.ControlDisablingEnabled = false;

            bread = new UIMenuItem("Use Bread");
            bread.SetRightLabel($"{Utilities.Constructors.Waters.ToString()}");
            food.AddItem(bread);
            food.OnItemSelect += (sender, item, index) =>
            {
                if (item == bread)
                {
                    if (Utilities.Constructors.Bread >= 1)
                    {
                        //Take Item
                        Utilities.Constructors.Bread = Utilities.Constructors.Bread - 1;

                        //Add Health
                        Game.Player.Character.Health = Game.Player.Character.Health + 10;

                        //Refresh
                        bread.SetRightLabel($"{Utilities.Constructors.Bread.ToString()}");

                        //Save Data
                        string breads = Utilities.Constructors.Bread.ToString();
                        TriggerServerEvent("Freedom:SavePlayerData", breads);
                    }
                }
            };
        }

        private void MenuItems(UIMenu menu)
        {
            //CEO Menu
            var CEOMenu = new UIMenuItem("CEO Menu");
            mainMenu.AddItem(CEOMenu);
            mainMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == CEOMenu)
                {
                    mainMenu.Visible = false;
                    CEO.Menus.MainCEO.ceoMenu.Visible = true;
                }
            };

            //Refresh Player Data
            var reloaddata = new UIMenuItem("Reload Player Data", "~r~Use this option to reload player data after the resource has crashed and/or been restarted");
            mainMenu.AddItem(reloaddata);
            mainMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == reloaddata)
                {
                    API.ExecuteCommand("load_player_data");
                }
            };
        }

        public MainMenu()
        {
            _menuPool = new MenuPool();
            mainMenu = new UIMenu("Main Menu", "~p~Freedom Framework ~w~by ~b~Abel Gaming");
            _menuPool.Add(mainMenu);

            Inventory(mainMenu);
            MenuItems(mainMenu);

            _menuPool.MouseEdgeEnabled = false;
            _menuPool.ControlDisablingEnabled = false;
            _menuPool.RefreshIndex();

            Tick += async () =>
            {
                _menuPool.ProcessMenus();
                if (API.IsControlJustPressed(0, 168) && !_menuPool.IsAnyMenuOpen()) // Our menu on/off switch
                    mainMenu.Visible = !mainMenu.Visible;
                bread.SetRightLabel($"{Utilities.Constructors.Bread.ToString()}");
                cola.SetRightLabel($"{Utilities.Constructors.Colas.ToString()}");
                water.SetRightLabel($"{Utilities.Constructors.Waters.ToString()}");
            };
        }
    }
}
