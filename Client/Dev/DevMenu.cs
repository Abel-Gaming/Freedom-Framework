using CitizenFX.Core;
using CitizenFX.Core.Native;
using NativeUI;
using System.Collections.Generic;

namespace client.Dev
{
    public class DevMenu : BaseScript
    {
        public static MenuPool _devmenuPool;
        public static UIMenu devMenu;

        private void MenuItems(UIMenu menu)
        {
            //Spawns
            var allspawns = new List<dynamic>
            {
                "2 Car Garage", "6 Car Garage", "10 Car Garage", "Low End Apartment", "Medium End Apartment"
            };

            var selectspawn = new UIMenuListItem("Select Spawn", allspawns, 0);
            devMenu.AddItem(selectspawn);
            devMenu.OnListSelect += (sender, item, index) =>
            {
                if (item == selectspawn)
                {
                    if (selectspawn.CurrentItem() == "2 Car Garage")
                    {
                        Game.Player.Character.Position = Apartments.ApartmentMain.TwoCarGarage;
                    }

                    if (selectspawn.CurrentItem() == "6 Car Garage")
                    {
                        Game.Player.Character.Position = Apartments.ApartmentMain.SixCarGarage;
                    }

                    if (selectspawn.CurrentItem() == "10 Car Garage")
                    {
                        Game.Player.Character.Position = Apartments.ApartmentMain.TenCarGarage;
                    }

                    if (selectspawn.CurrentItem() == "Low End Apartment")
                    {
                        Game.Player.Character.Position = Apartments.ApartmentMain.LowEndApartment;
                    }

                    if (selectspawn.CurrentItem() == "Medium End Apartment")
                    {
                        Game.Player.Character.Position = Apartments.ApartmentMain.MediumEndApartment;
                    }
                }
            };
        }

        public DevMenu()
        {
            _devmenuPool = new MenuPool();
            devMenu = new UIMenu("Dev Menu", "~p~Freedom Framework ~w~by ~b~Abel Gaming");
            _devmenuPool.Add(devMenu);

            MenuItems(devMenu);

            _devmenuPool.MouseEdgeEnabled = false;
            _devmenuPool.ControlDisablingEnabled = false;
            _devmenuPool.RefreshIndex();

            Tick += async () =>
            {
                _devmenuPool.ProcessMenus();
            };
        }
    }
}
