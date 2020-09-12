﻿using BepInEx;
using BepInEx.Configuration;
using Common;

namespace IllusionFixes
{
    [BepInProcess(Constants.GameProcessName)]
    [BepInProcess(Constants.GameProcessNameSteam)]
    [BepInPlugin(GUID, PluginName, Constants.PluginsVersion)]
    public partial class MakerOptimizations : BaseUnityPlugin
    {
        public const string GUID = "KK_Fix_MakerOptimizations";

        private void Start()
        {
            ListWidth = Config.Bind(Utilities.ConfigSectionTweaks, "Width of maker item lists", 3,
                new ConfigDescription(
                    "How many items fit horizontally in a single row of the item lists in character maker.\n Changes require a restart of character maker.",
                    new AcceptableValueRange<int>(3, 8)));

            var virtualize = Config.Bind(Utilities.ConfigSectionTweaks, "Virtualize maker lists", true, "Major load time reduction and performance improvement in character maker. Eliminates lag when switching tabs." +
                                                                                                        "\nCan cause some compatibility issues with other plugins." +
                                                                                                        "\nChanges take effect after game restart.");
            if (virtualize.Value) VirtualizeMakerLists.InstallHooks();
        }

        private static ConfigEntry<int> ListWidth { get; set; }
    }
}
