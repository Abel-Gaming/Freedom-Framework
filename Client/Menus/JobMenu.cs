using CitizenFX.Core;
using CitizenFX.Core.UI;
using CitizenFX.Core.Native;
using NativeUI;
using System.Collections.Generic;

namespace client.Menus
{
    public class JobMenu : BaseScript
    {
        public static MenuPool _jobmenuPool;
        public static UIMenu jobmainMenu;

        private void JobOptions(UIMenu menu)
        {
            var unemployed = new UIMenuItem("Unemployed", "Salary: $500");
            jobmainMenu.AddItem(unemployed);
            jobmainMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == unemployed)
                {
                    string job = "Unemployed";
                    Utilities.Constructors.playerJob = job;
                    TriggerServerEvent("Freedom:SendPlayerJobUpdate", job);
                }
            };

            var police = new UIMenuItem("Police", "Salary: $5,000");
            jobmainMenu.AddItem(police);
            jobmainMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == police)
                {
                    string job = "Police";
                    Utilities.Constructors.playerJob = job;
                    TriggerServerEvent("Freedom:SendPlayerJobUpdate", job);
                }
            };

            var fisherman = new UIMenuItem("Fisherman", "Salary: $750");
            jobmainMenu.AddItem(fisherman);
            jobmainMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == fisherman)
                {
                    string job = "Fisherman";
                    Utilities.Constructors.playerJob = job;
                    TriggerServerEvent("Freedom:SendPlayerJobUpdate", job);
                }
            };

            var Lumberjack = new UIMenuItem("Lumberjack", "Salary: $1,000");
            jobmainMenu.AddItem(Lumberjack);
            jobmainMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == Lumberjack)
                {
                    string job = "Lumberjack";
                    Utilities.Constructors.playerJob = job;
                    TriggerServerEvent("Freedom:SendPlayerJobUpdate", job);
                }
            };

            var Reporter = new UIMenuItem("Reporter", "Salary: $750");
            jobmainMenu.AddItem(Reporter);
            jobmainMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == Reporter)
                {
                    string job = "Reporter";
                    Utilities.Constructors.playerJob = job;
                    TriggerServerEvent("Freedom:SendPlayerJobUpdate", job);
                }
            };
        }

        public JobMenu()
        {
            _jobmenuPool = new MenuPool();
            jobmainMenu = new UIMenu("Job Menu", "~p~Freedom Framework ~w~by ~b~Abel Gaming");
            _jobmenuPool.Add(jobmainMenu);

            JobOptions(jobmainMenu);

            _jobmenuPool.MouseEdgeEnabled = false;
            _jobmenuPool.ControlDisablingEnabled = false;
            _jobmenuPool.RefreshIndex();

            Tick += async () =>
            {
                _jobmenuPool.ProcessMenus();
            };
        }
    }
}
