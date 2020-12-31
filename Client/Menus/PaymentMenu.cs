using CitizenFX.Core;
using CitizenFX.Core.Native;
using NativeUI;
using System.Collections.Generic;

namespace client.Menus
{
    public class PaymentMenu : BaseScript
    {
        public static MenuPool _PaymentPool;
        public static UIMenu paymentMenu;

        private void MenuOptions(UIMenu menu)
        {
            //Transfer Amounts
            var amounts = new List<dynamic> { "$100", "$1,000", "$10,000", "$100,000" };

            var transfertoplayer = new UIMenuListItem("Transfer Amount to Player", amounts, 0);
            paymentMenu.AddItem(transfertoplayer);
            paymentMenu.OnListSelect += (sender, item, index) =>
            {
                if (item == transfertoplayer)
                {
                    if (transfertoplayer.CurrentItem() == "$100")
                    {
                        if (Utilities.Constructors.playerMoney >= 100)
                        {
                            string recipientid = Utilities.Commands.PaymentRecipientID.ToString();
                            string amount = "100";
                            TriggerServerEvent("Freedom:PayPlayer", recipientid, amount);
                        }

                    }

                    if (transfertoplayer.CurrentItem() == "$1,000")
                    {
                        if (Utilities.Constructors.playerMoney >= 1000)
                        {
                            string recipientid = Utilities.Commands.PaymentRecipientID.ToString();
                            string amount = "1000";
                            TriggerServerEvent("Freedom:PayPlayer", recipientid, amount);
                        }
                    }

                    if (transfertoplayer.CurrentItem() == "$10,000")
                    {
                        if (Utilities.Constructors.playerMoney >= 10000)
                        {
                            string recipientid = Utilities.Commands.PaymentRecipientID.ToString();
                            string amount = "10000";
                            TriggerServerEvent("Freedom:PayPlayer", recipientid, amount);
                        }
                    }

                    if (transfertoplayer.CurrentItem() == "$100,000")
                    {
                        if (Utilities.Constructors.playerMoney >= 100000)
                        {
                            string recipientid = Utilities.Commands.PaymentRecipientID.ToString();
                            string amount = "100000";
                            TriggerServerEvent("Freedom:PayPlayer", recipientid, amount);
                        }
                    }
                }
            };
        }

        public PaymentMenu()
        {
            _PaymentPool = new MenuPool();
            paymentMenu = new UIMenu("Payment Menu", "~p~Freedom Framework ~w~by ~b~Abel Gaming");
            _PaymentPool.Add(paymentMenu);

            MenuOptions(paymentMenu);

            _PaymentPool.MouseEdgeEnabled = false;
            _PaymentPool.ControlDisablingEnabled = false;
            _PaymentPool.RefreshIndex();

            Tick += async () =>
            {
                _PaymentPool.ProcessMenus();
            };
        }
    }
}
