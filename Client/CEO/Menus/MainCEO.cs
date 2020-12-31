using CitizenFX.Core;
using CitizenFX.Core.UI;
using CitizenFX.Core.Native;
using NativeUI;
using System.Collections.Generic;

namespace client.CEO.Menus
{
    public class MainCEO : BaseScript
    {
        public static MenuPool _CEOmenuPool;
        public static UIMenu ceoMenu;

        private void MenuOptions(UIMenu menu)
        {
            
        }

        public MainCEO()
        {
            _CEOmenuPool = new MenuPool();
            ceoMenu = new UIMenu("CEO", "~p~Freedom Framework ~w~by ~b~Abel Gaming");
            _CEOmenuPool.Add(ceoMenu);

            MenuOptions(ceoMenu);

            _CEOmenuPool.MouseEdgeEnabled = false;
            _CEOmenuPool.ControlDisablingEnabled = false;
            _CEOmenuPool.RefreshIndex();

            Tick += async () =>
            {
                _CEOmenuPool.ProcessMenus();
            };
        }
    }
}
