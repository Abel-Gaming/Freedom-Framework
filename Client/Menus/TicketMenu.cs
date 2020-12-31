using CitizenFX.Core;
using CitizenFX.Core.Native;
using NativeUI;
using System.Collections.Generic;
using System.Linq;

namespace client.Menus
{
    public class TicketMenu : BaseScript
    {
        public static MenuPool _TicketPool;
        public static UIMenu ticketMenu;

        private void MenuOptions(UIMenu menu)
        {
            //Transfer Amounts
            var amounts = new List<dynamic> { 
                "50", "$100", "150", "200", "250", "300", "350", "400", "450", "500", "550", "600", "650", "700"
            };

            var transfertoplayer = new UIMenuListItem("Ticket Amount", amounts, 0);
            ticketMenu.AddItem(transfertoplayer);
            ticketMenu.OnListSelect += (sender, item, index) =>
            {
                if (item == transfertoplayer)
                {
                    int fine = int.Parse(transfertoplayer.CurrentItem());
                    int TicketRecipient = Modules.PoliceJob.TicketRecipientID;
                    TriggerServerEvent("Freedom:IssueTicket", TicketRecipient, fine);
                    _TicketPool.CloseAllMenus();
                }
            };

            var otheramount = new UIMenuItem("Other Amount");
            ticketMenu.AddItem(otheramount);
            ticketMenu.OnItemSelect += async (sender, item, index) =>
            {
                if (item == otheramount)
                {
                    API.DisplayOnscreenKeyboard(1, "", "", "", "", "", "", 500);
                    Game.Player.CanControlCharacter = false;
                    await Delay(5000);
                    string amount = API.GetOnscreenKeyboardResult();
                    API.CancelOnscreenKeyboard();
                    int fine = int.Parse(amount);
                    int TicketRecipient = Modules.PoliceJob.TicketRecipientID;
                    TriggerServerEvent("Freedom:IssueTicket", TicketRecipient, fine);
                    _TicketPool.CloseAllMenus();
                    Game.Player.CanControlCharacter = true;
                }
            };
        }

        public TicketMenu()
        {
            _TicketPool = new MenuPool();
            ticketMenu = new UIMenu("Ticket Menu", "~p~Freedom Framework ~w~by ~b~Abel Gaming");
            _TicketPool.Add(ticketMenu);

            MenuOptions(ticketMenu);

            _TicketPool.MouseEdgeEnabled = false;
            _TicketPool.ControlDisablingEnabled = false;
            _TicketPool.RefreshIndex();

            Tick += async () =>
            {
                _TicketPool.ProcessMenus();
            };
        }
    }
}
