using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NerfFloorScanner
{

    /// <summary>
    /// Removes the floor scanning ability by always returning "false", which means the floor cannot be scanned.
    /// </summary>
    [HarmonyPatch(typeof(HyperwaveScannerDepartment), nameof(HyperwaveScannerDepartment.TryScanFloor))]
    public static class HyperwaveScannerDepartment_TryScanFloor_Patch
    {
        public static bool Prefix()
        {
            //Do not run or the game will add the scanned floors to the map info.
            return false;
        }
    }
}
