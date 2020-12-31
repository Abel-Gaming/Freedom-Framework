using CitizenFX.Core;
using CitizenFX.Core.Native;
using NativeUI;
using System.Collections.Generic;

namespace client.Menus
{
    public class PoliceMenu : BaseScript
    {
        public static MenuPool _policeMenuPool;
        public static UIMenu policeMenu;

        private void Outfits(UIMenu menu)
        {
            var outfits = _policeMenuPool.AddSubMenu(menu, "Uniforms");
            for (int i = 0; i < 1; i++) ;

            outfits.MouseEdgeEnabled = false;
            outfits.ControlDisablingEnabled = false;

            var bcsom = new UIMenuItem("Blaine County Sheriff Officer");
            bcsom.SetRightLabel("[M]");
            outfits.AddItem(bcsom);
            outfits.OnItemSelect += async (sender, item, index) =>
            {
                if (item == bcsom)
                {
                    await Game.Player.ChangeModel(PedHash.Sheriff01SMY);
                    Game.Player.Character.Style.RandomizeOutfit();
                    Game.Player.Character.Style.RandomizeProps();
                }
            };

            var bcsof = new UIMenuItem("Blaine County Sheriff Officer");
            bcsof.SetRightLabel("[F]");
            outfits.AddItem(bcsof);
            outfits.OnItemSelect += async (sender, item, index) =>
            {
                if (item == bcsof)
                {
                    await Game.Player.ChangeModel(PedHash.Sheriff01SFY);
                    Game.Player.Character.Style.RandomizeOutfit();
                    Game.Player.Character.Style.RandomizeProps();
                }
            };

            var lspdm = new UIMenuItem("Los Santos Police Officer");
            lspdm.SetRightLabel("[M]");
            outfits.AddItem(lspdm);
            outfits.OnItemSelect += async (sender, item, index) =>
            {
                if (item == lspdm)
                {
                    await Game.Player.ChangeModel(PedHash.Cop01SMY);
                    Game.Player.Character.Style.RandomizeOutfit();
                    Game.Player.Character.Style.RandomizeProps();
                }
            };

            var lspdf = new UIMenuItem("Los Santos Police Officer");
            lspdf.SetRightLabel("[F]");
            outfits.AddItem(lspdf);
            outfits.OnItemSelect += async (sender, item, index) =>
            {
                if (item == lspdf)
                {
                    await Game.Player.ChangeModel(PedHash.Cop01SFY);
                    Game.Player.Character.Style.RandomizeOutfit();
                    Game.Player.Character.Style.RandomizeProps();
                }
            };

            var highway = new UIMenuItem("Highway Patrol Officer");
            highway.SetRightLabel("[M]");
            outfits.AddItem(highway);
            outfits.OnItemSelect += async (sender, item, index) =>
            {
                if (item == highway)
                {
                    await Game.Player.ChangeModel(PedHash.Hwaycop01SMY);
                    Game.Player.Character.Style.RandomizeOutfit();
                    Game.Player.Character.Style.RandomizeProps();
                }
            };
        }

        private void Vehicles(UIMenu menu)
        {

        }

        public PoliceMenu()
        {
            _policeMenuPool = new MenuPool();
            policeMenu = new UIMenu("Police Menu", "~p~Freedom Framework ~w~by ~b~Abel Gaming");
            _policeMenuPool.Add(policeMenu);

            Outfits(policeMenu);

            _policeMenuPool.MouseEdgeEnabled = false;
            _policeMenuPool.ControlDisablingEnabled = false;
            _policeMenuPool.RefreshIndex();

            Tick += async () =>
            {
                _policeMenuPool.ProcessMenus();
            };
        }
    }
}
