﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Verse;

namespace FrankWilco.RimWorld
{
    [HarmonyPatch(typeof(GenCommandLine), nameof(GenCommandLine.Restart))]
    public static class RestartModifier
    {
        public static readonly string[] doorstopVariables =
            {
                "DOORSTOP_DISABLE",
                "DOORSTOP_INITIALIZED",
                "DOORSTOP_DLL_SEARCH_DIRS",
                "DOORSTOP_INVOKE_DLL_PATH",
                "DOORSTOP_MANAGED_FOLDER_DIR",
                "DOORSTOP_MONO_LIB_PATH",
                "DOORSTOP_PROCESS_PATH"
            };

        public static void Prefix()
        {
            // We have to remove all UnityDoorstop environment variables from
            // the current process to prevent it from passing these variables
            // to the new game instance. Otherwise, UnityDoorstop will assume
            // that it doesn't have to patch the new instance anymore.
            // See NeighTools/UnityDoorstop#34.
            foreach (string variable in doorstopVariables)
            {
                Environment.SetEnvironmentVariable(variable, null);
            }
        }
    }
}