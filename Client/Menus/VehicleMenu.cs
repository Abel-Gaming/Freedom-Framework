using System.Collections.Generic;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using NativeUI;

namespace client.Menus
{
    public class VehicleMenu : BaseScript
    {
        public static MenuPool _vehiclemenuPool;
        public static UIMenu vehicleMenu;
        private static Vector3 CarSpawn = new Vector3(-45.74f, -1081.99f, 26.36f);
        private static float CarSpawnHeading = 71.8f;

        //MENUS
        private static UIMenu COMMERCIAL;
        private static UIMenu COMPACTS;
        private static UIMenu COUPES;
        private static UIMenu CYCLES;
        private static UIMenu INDUSTRIAL;
        private static UIMenu MILITARY;
        private static UIMenu MOTORCYCLES;
        private static UIMenu MUSCLE;
        private static UIMenu OFFROAD;
        private static UIMenu SEDANS;
        private static UIMenu SERVICE;
        private static UIMenu SPORTS;
        private static UIMenu SPORTSCLASSICS;
        private static UIMenu SUPER;
        private static UIMenu SUV;
        private static UIMenu UTILITY;
        private static UIMenu VANS;
        private static UIMenu ADDON;

        private static List<VehicleHash> allVehicles;
        private static List<VehicleClass> allClasses;

        public void CreateMenus()
        {
            //COMMERCIAL
            COMMERCIAL = _vehiclemenuPool.AddSubMenu(vehicleMenu, "COMMERCIAL");
            for (int i = 0; i < 1; i++) ;

            COMMERCIAL.MouseEdgeEnabled = false;
            COMMERCIAL.ControlDisablingEnabled = false;

            //COMPACTS
            COMPACTS = _vehiclemenuPool.AddSubMenu(vehicleMenu, "COMPACTS");
            for (int i = 0; i < 1; i++) ;

            COMPACTS.MouseEdgeEnabled = false;
            COMPACTS.ControlDisablingEnabled = false;

            //COUPES
            COUPES = _vehiclemenuPool.AddSubMenu(vehicleMenu, "COUPES");
            for (int i = 0; i < 1; i++) ;

            COUPES.MouseEdgeEnabled = false;
            COUPES.ControlDisablingEnabled = false;

            //CYCLES
            CYCLES = _vehiclemenuPool.AddSubMenu(vehicleMenu, "CYCLES");
            for (int i = 0; i < 1; i++) ;

            CYCLES.MouseEdgeEnabled = false;
            CYCLES.ControlDisablingEnabled = false;

            //INDUSTRIAL
            INDUSTRIAL = _vehiclemenuPool.AddSubMenu(vehicleMenu, "INDUSTRIAL");
            for (int i = 0; i < 1; i++) ;

            INDUSTRIAL.MouseEdgeEnabled = false;
            INDUSTRIAL.ControlDisablingEnabled = false;

            //MILITARY
            MILITARY = _vehiclemenuPool.AddSubMenu(vehicleMenu, "MILITARY");
            for (int i = 0; i < 1; i++) ;

            MILITARY.MouseEdgeEnabled = false;
            MILITARY.ControlDisablingEnabled = false;

            //MOTORCYCLES
            MOTORCYCLES = _vehiclemenuPool.AddSubMenu(vehicleMenu, "MOTORCYCLES");
            for (int i = 0; i < 1; i++) ;

            MOTORCYCLES.MouseEdgeEnabled = false;
            MOTORCYCLES.ControlDisablingEnabled = false;

            //MUSCLE
            MUSCLE = _vehiclemenuPool.AddSubMenu(vehicleMenu, "MUSCLE");
            for (int i = 0; i < 1; i++) ;

            MUSCLE.MouseEdgeEnabled = false;
            MUSCLE.ControlDisablingEnabled = false;

            //OFFROAD
            OFFROAD = _vehiclemenuPool.AddSubMenu(vehicleMenu, "OFFROAD");
            for (int i = 0; i < 1; i++) ;

            OFFROAD.MouseEdgeEnabled = false;
            OFFROAD.ControlDisablingEnabled = false;

            //SEDANS
            SEDANS = _vehiclemenuPool.AddSubMenu(vehicleMenu, "SEDANS");
            for (int i = 0; i < 1; i++) ;

            SEDANS.MouseEdgeEnabled = false;
            SEDANS.ControlDisablingEnabled = false;

            //SERVICE
            SERVICE = _vehiclemenuPool.AddSubMenu(vehicleMenu, "SERVICE");
            for (int i = 0; i < 1; i++) ;

            SERVICE.MouseEdgeEnabled = false;
            SERVICE.ControlDisablingEnabled = false;

            //SPORTS
            SPORTS = _vehiclemenuPool.AddSubMenu(vehicleMenu, "SPORTS");
            for (int i = 0; i < 1; i++) ;

            SPORTS.MouseEdgeEnabled = false;
            SPORTS.ControlDisablingEnabled = false;

            //SPORTS CLASSICS
            SPORTSCLASSICS = _vehiclemenuPool.AddSubMenu(vehicleMenu, "SPORTS CLASSICS");
            for (int i = 0; i < 1; i++) ;

            SPORTSCLASSICS.MouseEdgeEnabled = false;
            SPORTSCLASSICS.ControlDisablingEnabled = false;

            //SUPER
            SUPER = _vehiclemenuPool.AddSubMenu(vehicleMenu, "SUPER");
            for (int i = 0; i < 1; i++) ;

            SUPER.MouseEdgeEnabled = false;
            SUPER.ControlDisablingEnabled = false;

            //SUV
            SUV = _vehiclemenuPool.AddSubMenu(vehicleMenu, "SUV");
            for (int i = 0; i < 1; i++) ;

            SUV.MouseEdgeEnabled = false;
            SUV.ControlDisablingEnabled = false;

            //UTILITY
            UTILITY = _vehiclemenuPool.AddSubMenu(vehicleMenu, "UTILITY");
            for (int i = 0; i < 1; i++) ;

            UTILITY.MouseEdgeEnabled = false;
            UTILITY.ControlDisablingEnabled = false;

            //VANS
            VANS = _vehiclemenuPool.AddSubMenu(vehicleMenu, "VANS");
            for (int i = 0; i < 1; i++) ;

            VANS.MouseEdgeEnabled = false;
            VANS.ControlDisablingEnabled = false;

            //ADDONS
            ADDON = _vehiclemenuPool.AddSubMenu(vehicleMenu, "ADD-ONS");
            for (int i = 0; i < 1; i++) ;

            ADDON.MouseEdgeEnabled = false;
            ADDON.ControlDisablingEnabled = false;
        }

        private static void LoadVehicles()
        {
            allVehicles = new List<VehicleHash>();
            allClasses = new List<VehicleClass>();

            allClasses.Add(VehicleClass.Commercial);
            allClasses.Add(VehicleClass.Compacts);
            allClasses.Add(VehicleClass.Coupes);
            allClasses.Add(VehicleClass.Cycles);
            allClasses.Add(VehicleClass.Industrial);
            allClasses.Add(VehicleClass.Military);
            allClasses.Add(VehicleClass.Motorcycles);
            allClasses.Add(VehicleClass.Muscle);
            allClasses.Add(VehicleClass.OffRoad);
            allClasses.Add(VehicleClass.Sedans);
            allClasses.Add(VehicleClass.Service);
            allClasses.Add(VehicleClass.Sports);
            allClasses.Add(VehicleClass.SportsClassics);
            allClasses.Add(VehicleClass.Super);
            allClasses.Add(VehicleClass.SUVs);
            allClasses.Add(VehicleClass.Utility);
            allClasses.Add(VehicleClass.Vans);

            allVehicles.Add(VehicleHash.Adder);
            allVehicles.Add(VehicleHash.Akuma);
            allVehicles.Add(VehicleHash.Asea);
            allVehicles.Add(VehicleHash.Asterope);
            allVehicles.Add(VehicleHash.Avarus);

            allVehicles.Add(VehicleHash.Bagger);
            allVehicles.Add(VehicleHash.Baller);
            allVehicles.Add(VehicleHash.Baller2);
            allVehicles.Add(VehicleHash.Baller3);
            allVehicles.Add(VehicleHash.Baller4);
            allVehicles.Add(VehicleHash.Baller5);
            allVehicles.Add(VehicleHash.Baller6);
            allVehicles.Add(VehicleHash.Banshee);
            allVehicles.Add(VehicleHash.Banshee2);
            allVehicles.Add(VehicleHash.Bati);
            allVehicles.Add(VehicleHash.Bati2);
            allVehicles.Add(VehicleHash.BfInjection);
            allVehicles.Add(VehicleHash.Bison);
            allVehicles.Add(VehicleHash.Bison2);
            allVehicles.Add(VehicleHash.Bison3);
            allVehicles.Add(VehicleHash.BJXL);
            allVehicles.Add(VehicleHash.Blista);
            allVehicles.Add(VehicleHash.Blista2);
            allVehicles.Add(VehicleHash.Blista3);
            allVehicles.Add(VehicleHash.BobcatXL);
            allVehicles.Add(VehicleHash.Bodhi2);
            allVehicles.Add(VehicleHash.Brawler);
            allVehicles.Add(VehicleHash.Buccaneer);
            allVehicles.Add(VehicleHash.Buccaneer2);
            allVehicles.Add(VehicleHash.Buffalo);
            allVehicles.Add(VehicleHash.Buffalo2);
            allVehicles.Add(VehicleHash.Buffalo3);
            allVehicles.Add(VehicleHash.Bullet);
            allVehicles.Add(VehicleHash.Burrito);

            allVehicles.Add(VehicleHash.Caddy);
            allVehicles.Add(VehicleHash.Carbonizzare);
            allVehicles.Add(VehicleHash.CarbonRS);
            allVehicles.Add(VehicleHash.Cavalcade);
            allVehicles.Add(VehicleHash.Cavalcade2);
            allVehicles.Add(VehicleHash.Cheetah);
            allVehicles.Add(VehicleHash.Cheetah2);
            allVehicles.Add(VehicleHash.Chino);
            allVehicles.Add(VehicleHash.Cog55);
            allVehicles.Add(VehicleHash.Cog552);
            allVehicles.Add(VehicleHash.Cognoscenti);
            allVehicles.Add(VehicleHash.Cognoscenti2);
            allVehicles.Add(VehicleHash.Comet2);
            allVehicles.Add(VehicleHash.Comet3);
            allVehicles.Add(VehicleHash.Contender);
            allVehicles.Add(VehicleHash.Coquette);
            allVehicles.Add(VehicleHash.Coquette2);
            allVehicles.Add(VehicleHash.Coquette3);

            allVehicles.Add(VehicleHash.Daemon);
            allVehicles.Add(VehicleHash.Daemon2);
            allVehicles.Add(VehicleHash.Diablous);
            allVehicles.Add(VehicleHash.Diablous2);
            allVehicles.Add(VehicleHash.Dilettante);
            allVehicles.Add(VehicleHash.Dilettante2);
            allVehicles.Add(VehicleHash.DLoader);
            allVehicles.Add(VehicleHash.Dominator);
            allVehicles.Add(VehicleHash.Dominator2);
            allVehicles.Add(VehicleHash.Double);
            allVehicles.Add(VehicleHash.Dubsta);
            allVehicles.Add(VehicleHash.Dubsta2);
            allVehicles.Add(VehicleHash.Dubsta3);
            allVehicles.Add(VehicleHash.Dukes);
            allVehicles.Add(VehicleHash.Dukes2);
        }

        public void AddVehicles(UIMenu menu)
        {
            //VEHICLES
            foreach (VehicleHash vehicle in allVehicles)
            {
                //Get Vehicle Name
                string vehiclename = API.GetDisplayNameFromVehicleModel((uint)vehicle);

                //Get Vehicle Class
                int vehicleClass = API.GetVehicleClassFromName((uint)vehicle);
                string vehclass = vehicleClass.ToString();

                //COMMERCIAL
                if (vehicleClass == 20)
                {
                    //Create Price
                    int Price = 4000;

                    //Create Menu Items
                    var newvehicle = new UIMenuItem(vehiclename);
                    newvehicle.SetRightLabel($"~g~${Price.ToString()}");
                    COMMERCIAL.AddItem(newvehicle);
                    COMMERCIAL.OnItemSelect += async (sender, item, index) =>
                    {
                        if (item == newvehicle)
                        {
                            if (Utilities.Constructors.playerMoney >= Price) //Check to ensure player has enough money
                            {
                                //Create Car
                                API.RequestModel((uint)vehicle);
                                while (!API.HasModelLoaded((uint)vehicle))
                                {
                                    await BaseScript.Delay(100);
                                }
                                int Rancherxl = API.CreateVehicle((uint)vehicle, CarSpawn.X, CarSpawn.Y, CarSpawn.Z, CarSpawnHeading, true, true);
                                API.TaskWarpPedIntoVehicle(Game.Player.Character.Handle, Rancherxl, -1);
                                _vehiclemenuPool.CloseAllMenus();

                                //Take Money
                                API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - Price);
                            }
                            else
                            {
                                Screen.ShowNotification("~r~Not enough money");
                            }

                        }
                    };
                }

                //COMPACTS
                if (vehicleClass == 0)
                {
                    //Create Price
                    int Price = 2000;

                    //Create Menu Items
                    var newvehicle = new UIMenuItem(vehiclename);
                    newvehicle.SetRightLabel($"~g~${Price.ToString()}");
                    COMPACTS.AddItem(newvehicle);
                    COMPACTS.OnItemSelect += async (sender, item, index) =>
                    {
                        if (item == newvehicle)
                        {
                            if (Utilities.Constructors.playerMoney >= Price) //Check to ensure player has enough money
                            {
                                //Create Car
                                API.RequestModel((uint)vehicle);
                                while (!API.HasModelLoaded((uint)vehicle))
                                {
                                    await BaseScript.Delay(100);
                                }
                                int Rancherxl = API.CreateVehicle((uint)vehicle, CarSpawn.X, CarSpawn.Y, CarSpawn.Z, CarSpawnHeading, true, true);
                                API.TaskWarpPedIntoVehicle(Game.Player.Character.Handle, Rancherxl, -1);
                                _vehiclemenuPool.CloseAllMenus();

                                //Take Money
                                API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - Price);
                            }
                            else
                            {
                                Screen.ShowNotification("~r~Not enough money");
                            }

                        }
                    };
                }

                //COUPES
                if (vehicleClass == 3)
                {
                    //Create Price
                    int Price = 1800;

                    //Create Menu Items
                    var newvehicle = new UIMenuItem(vehiclename);
                    newvehicle.SetRightLabel($"~g~${Price.ToString()}");
                    COUPES.AddItem(newvehicle);
                    COUPES.OnItemSelect += async (sender, item, index) =>
                    {
                        if (item == newvehicle)
                        {
                            if (Utilities.Constructors.playerMoney >= Price) //Check to ensure player has enough money
                            {
                                //Create Car
                                API.RequestModel((uint)vehicle);
                                while (!API.HasModelLoaded((uint)vehicle))
                                {
                                    await BaseScript.Delay(100);
                                }
                                int Rancherxl = API.CreateVehicle((uint)vehicle, CarSpawn.X, CarSpawn.Y, CarSpawn.Z, CarSpawnHeading, true, true);
                                API.TaskWarpPedIntoVehicle(Game.Player.Character.Handle, Rancherxl, -1);
                                _vehiclemenuPool.CloseAllMenus();

                                //Take Money
                                API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - Price);
                            }
                            else
                            {
                                Screen.ShowNotification("~r~Not enough money");
                            }

                        }
                    };
                }

                //CYCLES
                if (vehicleClass == 13)
                {
                    //Create Price
                    int Price = 500;

                    //Create Menu Items
                    var newvehicle = new UIMenuItem(vehiclename);
                    newvehicle.SetRightLabel($"~g~${Price.ToString()}");
                    CYCLES.AddItem(newvehicle);
                    CYCLES.OnItemSelect += async (sender, item, index) =>
                    {
                        if (item == newvehicle)
                        {
                            if (Utilities.Constructors.playerMoney >= Price) //Check to ensure player has enough money
                            {
                                //Create Car
                                API.RequestModel((uint)vehicle);
                                while (!API.HasModelLoaded((uint)vehicle))
                                {
                                    await BaseScript.Delay(100);
                                }
                                int Rancherxl = API.CreateVehicle((uint)vehicle, CarSpawn.X, CarSpawn.Y, CarSpawn.Z, CarSpawnHeading, true, true);
                                API.TaskWarpPedIntoVehicle(Game.Player.Character.Handle, Rancherxl, -1);
                                _vehiclemenuPool.CloseAllMenus();

                                //Take Money
                                API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - Price);
                            }
                            else
                            {
                                Screen.ShowNotification("~r~Not enough money");
                            }

                        }
                    };
                }

                //INDUSTRIAL
                if (vehicleClass == 10)
                {
                    //Create Price
                    int Price = 7500;

                    //Create Menu Items
                    var newvehicle = new UIMenuItem(vehiclename);
                    newvehicle.SetRightLabel($"~g~${Price.ToString()}");
                    INDUSTRIAL.AddItem(newvehicle);
                    INDUSTRIAL.OnItemSelect += async (sender, item, index) =>
                    {
                        if (item == newvehicle)
                        {
                            if (Utilities.Constructors.playerMoney >= Price) //Check to ensure player has enough money
                            {
                                //Create Car
                                API.RequestModel((uint)vehicle);
                                while (!API.HasModelLoaded((uint)vehicle))
                                {
                                    await BaseScript.Delay(100);
                                }
                                int Rancherxl = API.CreateVehicle((uint)vehicle, CarSpawn.X, CarSpawn.Y, CarSpawn.Z, CarSpawnHeading, true, true);
                                API.TaskWarpPedIntoVehicle(Game.Player.Character.Handle, Rancherxl, -1);
                                _vehiclemenuPool.CloseAllMenus();

                                //Take Money
                                API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - Price);
                            }
                            else
                            {
                                Screen.ShowNotification("~r~Not enough money");
                            }

                        }
                    };
                }

                //MILITARY
                if (vehicleClass == 19)
                {
                    //Create Price
                    int Price = 15000;

                    //Create Menu Items
                    var newvehicle = new UIMenuItem(vehiclename);
                    newvehicle.SetRightLabel($"~g~${Price.ToString()}");
                    MILITARY.AddItem(newvehicle);
                    MILITARY.OnItemSelect += async (sender, item, index) =>
                    {
                        if (item == newvehicle)
                        {
                            if (Utilities.Constructors.playerMoney >= Price) //Check to ensure player has enough money
                            {
                                //Create Car
                                API.RequestModel((uint)vehicle);
                                while (!API.HasModelLoaded((uint)vehicle))
                                {
                                    await BaseScript.Delay(100);
                                }
                                int Rancherxl = API.CreateVehicle((uint)vehicle, CarSpawn.X, CarSpawn.Y, CarSpawn.Z, CarSpawnHeading, true, true);
                                API.TaskWarpPedIntoVehicle(Game.Player.Character.Handle, Rancherxl, -1);
                                _vehiclemenuPool.CloseAllMenus();

                                //Take Money
                                API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - Price);
                            }
                            else
                            {
                                Screen.ShowNotification("~r~Not enough money");
                            }

                        }
                    };
                }

                //MOTORCYCLES
                if (vehicleClass == 8)
                {
                    //Create Price
                    int Price = 7500;

                    //Create Menu Items
                    var newvehicle = new UIMenuItem(vehiclename);
                    newvehicle.SetRightLabel($"~g~${Price.ToString()}");
                    MOTORCYCLES.AddItem(newvehicle);
                    MOTORCYCLES.OnItemSelect += async (sender, item, index) =>
                    {
                        if (item == newvehicle)
                        {
                            if (Utilities.Constructors.playerMoney >= Price) //Check to ensure player has enough money
                            {
                                //Create Car
                                API.RequestModel((uint)vehicle);
                                while (!API.HasModelLoaded((uint)vehicle))
                                {
                                    await BaseScript.Delay(100);
                                }
                                int Rancherxl = API.CreateVehicle((uint)vehicle, CarSpawn.X, CarSpawn.Y, CarSpawn.Z, CarSpawnHeading, true, true);
                                API.TaskWarpPedIntoVehicle(Game.Player.Character.Handle, Rancherxl, -1);
                                _vehiclemenuPool.CloseAllMenus();

                                //Take Money
                                API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - Price);
                            }
                            else
                            {
                                Screen.ShowNotification("~r~Not enough money");
                            }

                        }
                    };
                }

                //MUSCLE
                if (vehicleClass == 4)
                {
                    //Create Price
                    int Price = 7500;

                    //Create Menu Items
                    var newvehicle = new UIMenuItem(vehiclename);
                    newvehicle.SetRightLabel($"~g~${Price.ToString()}");
                    MUSCLE.AddItem(newvehicle);
                    MUSCLE.OnItemSelect += async (sender, item, index) =>
                    {
                        if (item == newvehicle)
                        {
                            if (Utilities.Constructors.playerMoney >= Price) //Check to ensure player has enough money
                            {
                                //Create Car
                                API.RequestModel((uint)vehicle);
                                while (!API.HasModelLoaded((uint)vehicle))
                                {
                                    await BaseScript.Delay(100);
                                }
                                int Rancherxl = API.CreateVehicle((uint)vehicle, CarSpawn.X, CarSpawn.Y, CarSpawn.Z, CarSpawnHeading, true, true);
                                API.TaskWarpPedIntoVehicle(Game.Player.Character.Handle, Rancherxl, -1);
                                _vehiclemenuPool.CloseAllMenus();

                                //Take Money
                                API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - Price);
                            }
                            else
                            {
                                Screen.ShowNotification("~r~Not enough money");
                            }

                        }
                    };
                }

                //OFFROAD
                if (vehicleClass == 9)
                {
                    //Create Price
                    int Price = 8000;

                    //Create Menu Items
                    var newvehicle = new UIMenuItem(vehiclename);
                    newvehicle.SetRightLabel($"~g~${Price.ToString()}");
                    OFFROAD.AddItem(newvehicle);
                    OFFROAD.OnItemSelect += async (sender, item, index) =>
                    {
                        if (item == newvehicle)
                        {
                            if (Utilities.Constructors.playerMoney >= Price) //Check to ensure player has enough money
                            {
                                //Create Car
                                API.RequestModel((uint)vehicle);
                                while (!API.HasModelLoaded((uint)vehicle))
                                {
                                    await BaseScript.Delay(100);
                                }
                                int Rancherxl = API.CreateVehicle((uint)vehicle, CarSpawn.X, CarSpawn.Y, CarSpawn.Z, CarSpawnHeading, true, true);
                                API.TaskWarpPedIntoVehicle(Game.Player.Character.Handle, Rancherxl, -1);
                                _vehiclemenuPool.CloseAllMenus();

                                //Take Money
                                API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - Price);
                            }
                            else
                            {
                                Screen.ShowNotification("~r~Not enough money");
                            }

                        }
                    };
                }

                //SEDANS
                if (vehicleClass == 1)
                {
                    //Create Price
                    int Price = 5000;

                    //Create Menu Items
                    var newvehicle = new UIMenuItem(vehiclename);
                    newvehicle.SetRightLabel($"~g~${Price.ToString()}");
                    SEDANS.AddItem(newvehicle);
                    SEDANS.OnItemSelect += async (sender, item, index) =>
                    {
                        if (item == newvehicle)
                        {
                            if (Utilities.Constructors.playerMoney >= Price) //Check to ensure player has enough money
                            {
                                //Create Car
                                API.RequestModel((uint)vehicle);
                                while (!API.HasModelLoaded((uint)vehicle))
                                {
                                    await BaseScript.Delay(100);
                                }
                                int Rancherxl = API.CreateVehicle((uint)vehicle, CarSpawn.X, CarSpawn.Y, CarSpawn.Z, CarSpawnHeading, true, true);
                                API.TaskWarpPedIntoVehicle(Game.Player.Character.Handle, Rancherxl, -1);
                                _vehiclemenuPool.CloseAllMenus();

                                //Take Money
                                API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - Price);
                            }
                            else
                            {
                                Screen.ShowNotification("~r~Not enough money");
                            }

                        }
                    };
                }

                //SERVICE
                if (vehicleClass == 17)
                {
                    //Create Price
                    int Price = 4000;

                    //Create Menu Items
                    var newvehicle = new UIMenuItem(vehiclename);
                    newvehicle.SetRightLabel($"~g~${Price.ToString()}");
                    SERVICE.AddItem(newvehicle);
                    SERVICE.OnItemSelect += async (sender, item, index) =>
                    {
                        if (item == newvehicle)
                        {
                            if (Utilities.Constructors.playerMoney >= Price) //Check to ensure player has enough money
                            {
                                //Create Car
                                API.RequestModel((uint)vehicle);
                                while (!API.HasModelLoaded((uint)vehicle))
                                {
                                    await BaseScript.Delay(100);
                                }
                                int Rancherxl = API.CreateVehicle((uint)vehicle, CarSpawn.X, CarSpawn.Y, CarSpawn.Z, CarSpawnHeading, true, true);
                                API.TaskWarpPedIntoVehicle(Game.Player.Character.Handle, Rancherxl, -1);
                                _vehiclemenuPool.CloseAllMenus();

                                //Take Money
                                API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - Price);
                            }
                            else
                            {
                                Screen.ShowNotification("~r~Not enough money");
                            }

                        }
                    };
                }

                //SPORTS
                if (vehicleClass == 6)
                {
                    //Create Price
                    int Price = 9000;

                    //Create Menu Items
                    var newvehicle = new UIMenuItem(vehiclename);
                    newvehicle.SetRightLabel($"~g~${Price.ToString()}");
                    SPORTS.AddItem(newvehicle);
                    SPORTS.OnItemSelect += async (sender, item, index) =>
                    {
                        if (item == newvehicle)
                        {
                            if (Utilities.Constructors.playerMoney >= Price) //Check to ensure player has enough money
                            {
                                //Create Car
                                API.RequestModel((uint)vehicle);
                                while (!API.HasModelLoaded((uint)vehicle))
                                {
                                    await BaseScript.Delay(100);
                                }
                                int Rancherxl = API.CreateVehicle((uint)vehicle, CarSpawn.X, CarSpawn.Y, CarSpawn.Z, CarSpawnHeading, true, true);
                                API.TaskWarpPedIntoVehicle(Game.Player.Character.Handle, Rancherxl, -1);
                                _vehiclemenuPool.CloseAllMenus();

                                //Take Money
                                API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - Price);
                            }
                            else
                            {
                                Screen.ShowNotification("~r~Not enough money");
                            }

                        }
                    };
                }

                //SPORTS CLASSICS
                if (vehicleClass == 5)
                {
                    //Create Price
                    int Price = 15000;

                    //Create Menu Items
                    var newvehicle = new UIMenuItem(vehiclename);
                    newvehicle.SetRightLabel($"~g~${Price.ToString()}");
                    SPORTSCLASSICS.AddItem(newvehicle);
                    SPORTSCLASSICS.OnItemSelect += async (sender, item, index) =>
                    {
                        if (item == newvehicle)
                        {
                            if (Utilities.Constructors.playerMoney >= Price) //Check to ensure player has enough money
                            {
                                //Create Car
                                API.RequestModel((uint)vehicle);
                                while (!API.HasModelLoaded((uint)vehicle))
                                {
                                    await BaseScript.Delay(100);
                                }
                                int Rancherxl = API.CreateVehicle((uint)vehicle, CarSpawn.X, CarSpawn.Y, CarSpawn.Z, CarSpawnHeading, true, true);
                                API.TaskWarpPedIntoVehicle(Game.Player.Character.Handle, Rancherxl, -1);
                                _vehiclemenuPool.CloseAllMenus();

                                //Take Money
                                API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - Price);
                            }
                            else
                            {
                                Screen.ShowNotification("~r~Not enough money");
                            }

                        }
                    };
                }

                //SUPER
                if (vehicleClass == 7)
                {
                    //Create Price
                    int Price = 17500;

                    //Create Menu Items
                    var newvehicle = new UIMenuItem(vehiclename);
                    newvehicle.SetRightLabel($"~g~${Price.ToString()}");
                    SUPER.AddItem(newvehicle);
                    SUPER.OnItemSelect += async (sender, item, index) =>
                    {
                        if (item == newvehicle)
                        {
                            if (Utilities.Constructors.playerMoney >= Price) //Check to ensure player has enough money
                            {
                                //Create Car
                                API.RequestModel((uint)vehicle);
                                while (!API.HasModelLoaded((uint)vehicle))
                                {
                                    await BaseScript.Delay(100);
                                }
                                int Rancherxl = API.CreateVehicle((uint)vehicle, CarSpawn.X, CarSpawn.Y, CarSpawn.Z, CarSpawnHeading, true, true);
                                API.TaskWarpPedIntoVehicle(Game.Player.Character.Handle, Rancherxl, -1);
                                _vehiclemenuPool.CloseAllMenus();

                                //Take Money
                                API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - Price);
                            }
                            else
                            {
                                Screen.ShowNotification("~r~Not enough money");
                            }

                        }
                    };
                }

                //SUV
                if (vehicleClass == 2)
                {
                    //Create Price
                    int Price = 10000;

                    //Create Menu Items
                    var newvehicle = new UIMenuItem(vehiclename);
                    newvehicle.SetRightLabel($"~g~${Price.ToString()}");
                    SUV.AddItem(newvehicle);
                    SUV.OnItemSelect += async (sender, item, index) =>
                    {
                        if (item == newvehicle)
                        {
                            if (Utilities.Constructors.playerMoney >= Price) //Check to ensure player has enough money
                            {
                                //Create Car
                                API.RequestModel((uint)vehicle);
                                while (!API.HasModelLoaded((uint)vehicle))
                                {
                                    await BaseScript.Delay(100);
                                }
                                int Rancherxl = API.CreateVehicle((uint)vehicle, CarSpawn.X, CarSpawn.Y, CarSpawn.Z, CarSpawnHeading, true, true);
                                API.TaskWarpPedIntoVehicle(Game.Player.Character.Handle, Rancherxl, -1);
                                _vehiclemenuPool.CloseAllMenus();

                                //Take Money
                                API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - Price);
                            }
                            else
                            {
                                Screen.ShowNotification("~r~Not enough money");
                            }

                        }
                    };
                }

                //UTILITY
                if (vehicleClass == 11)
                {
                    //Create Price
                    int Price = 3500;

                    //Create Menu Items
                    var newvehicle = new UIMenuItem(vehiclename);
                    newvehicle.SetRightLabel($"~g~${Price.ToString()}");
                    UTILITY.AddItem(newvehicle);
                    UTILITY.OnItemSelect += async (sender, item, index) =>
                    {
                        if (item == newvehicle)
                        {
                            if (Utilities.Constructors.playerMoney >= Price) //Check to ensure player has enough money
                            {
                                //Create Car
                                API.RequestModel((uint)vehicle);
                                while (!API.HasModelLoaded((uint)vehicle))
                                {
                                    await BaseScript.Delay(100);
                                }
                                int Rancherxl = API.CreateVehicle((uint)vehicle, CarSpawn.X, CarSpawn.Y, CarSpawn.Z, CarSpawnHeading, true, true);
                                API.TaskWarpPedIntoVehicle(Game.Player.Character.Handle, Rancherxl, -1);
                                _vehiclemenuPool.CloseAllMenus();

                                //Take Money
                                API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - Price);
                            }
                            else
                            {
                                Screen.ShowNotification("~r~Not enough money");
                            }

                        }
                    };
                }

                //VANS
                if (vehicleClass == 12)
                {
                    //Create Price
                    int Price = 4000;

                    //Create Menu Items
                    var newvehicle = new UIMenuItem(vehiclename);
                    newvehicle.SetRightLabel($"~g~${Price.ToString()}");
                    VANS.AddItem(newvehicle);
                    VANS.OnItemSelect += async (sender, item, index) =>
                    {
                        if (item == newvehicle)
                        {
                            if (Utilities.Constructors.playerMoney >= Price) //Check to ensure player has enough money
                            {
                                //Create Car
                                API.RequestModel((uint)vehicle);
                                while (!API.HasModelLoaded((uint)vehicle))
                                {
                                    await BaseScript.Delay(100);
                                }
                                int Rancherxl = API.CreateVehicle((uint)vehicle, CarSpawn.X, CarSpawn.Y, CarSpawn.Z, CarSpawnHeading, true, true);
                                API.TaskWarpPedIntoVehicle(Game.Player.Character.Handle, Rancherxl, -1);
                                _vehiclemenuPool.CloseAllMenus();

                                //Take Money
                                API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - Price);
                            }
                            else
                            {
                                Screen.ShowNotification("~r~Not enough money");
                            }

                        }
                    };
                }
            }
        }

        public void AddedVehicles(UIMenu menu)
        {
            //Tahoe
            var chevytahoe = new UIMenuItem("Chevy Tahoe");
            chevytahoe.SetRightLabel($"~g~$7500");
            ADDON.AddItem(chevytahoe);
            ADDON.OnItemSelect += async (sender, item, index) =>
            {
                if (item == chevytahoe)
                {
                    if (Utilities.Constructors.playerMoney >= 7500) //Check to ensure player has enough money
                    {
                        //Convert to hash
                        var modelName = "tahoe";
                        var modelHash = (uint)API.GetHashKey(modelName);

                        //Check if model is valid
                        if (API.IsModelInCdimage(modelHash))
                        {
                            //Request Model
                            API.RequestModel(modelHash);

                            //Check if model has loaded
                            while (!API.HasModelLoaded(modelHash))
                            {
                                await Delay(0);
                            }

                            //Spawn Vehicle
                            var vehicle = API.CreateVehicle(modelHash, CarSpawn.X, CarSpawn.Y, CarSpawn.Z, CarSpawnHeading, true, true);

                            //Warp Into Vehicle
                            API.TaskWarpPedIntoVehicle(Game.Player.Character.Handle, vehicle, -1);
                        }
                        else
                        {
                            //Show notification that model does not exist
                            Screen.ShowNotification("~r~Model does not exist");
                        }

                        //Take Money
                        API.SetPedMoney(API.GetPlayerPed(-1), Utilities.Constructors.playerMoney - 7500);
                    }
                    else
                    {
                        Screen.ShowNotification("~r~Not enough money");
                    }

                }
            };
        }

        public VehicleMenu()
        {
            _vehiclemenuPool = new MenuPool();
            vehicleMenu = new UIMenu("Vehicle Menu", "~p~Freedom Framework ~w~by ~b~Abel Gaming");
            _vehiclemenuPool.Add(vehicleMenu);

            //Create Menus
            CreateMenus();

            //Load Vehicle Hashes
            LoadVehicles();

            //Add Things to Menu
            AddVehicles(vehicleMenu);
            AddedVehicles(vehicleMenu);

            _vehiclemenuPool.MouseEdgeEnabled = false;
            _vehiclemenuPool.ControlDisablingEnabled = false;
            _vehiclemenuPool.RefreshIndex();

            Tick += async () =>
            {
                _vehiclemenuPool.ProcessMenus();
            };
        }
    }
}
