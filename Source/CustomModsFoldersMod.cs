﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace FrankWilco.RimWorld
{
    public class CustomModsFoldersMod : Mod
    {
        public static CustomModsFoldersModSettings settings;

        public CustomModsFoldersMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<CustomModsFoldersModSettings>();
        }

        public override string SettingsCategory()
        {
            return "mdf.prefs.title".Translate();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            settings.DoSettingsWindowContents(inRect);
        }
    }
}
