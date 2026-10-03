using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NerfFloorScanner
{
    public static class Plugin
    {
        public static ConfigDirectories ConfigDirectories = new ConfigDirectories();


        public static Logger Logger { get; private set; } = new Logger();


        [Hook(ModHookType.AfterConfigsLoaded)]
        public static void AfterConfig(IModContext context)
        {

            RemoveScannerPurchaseCost();

            new Harmony("nbk_RedSpy_" + ConfigDirectories.ModAssemblyName).PatchAll();

        }

        /// <summary>
        /// Removes the purchase cost for the floor scanner upgrades.
        /// </summary>
        private static void RemoveScannerPurchaseCost()
        {
            string[] departments =
            {
                "hyperwave_scanner_department",
                "hwsc_scan_floor_bonus",
                "hwsc_scan_floor_bonus_2",
            };

            foreach (string department in departments)
            {
                MagnumPerkRecord perk = Data.MagnumPerks.GetRecord(department);
                if (perk == null)
                {
                    Logger.LogError($"MagnumPerks record for upgrade '{department}' not found.");
                    continue;
                }

                perk.UpgradePrice = new List<string>();
            }

        }

    }
}
