using Harmony;
using System;
using System.Reflection;
using Newtonsoft.Json;

namespace MoneyCanBuyLove
{
    public static class ModInit
    {
        public static MCBLSettings Settings = new MCBLSettings();
        public const string HarmonyPackage = "us.tbone.MoneyCanBuyLove";
        public static void Init(string directory, string settingsJSON)
        {
            try
            {
                ModInit.Settings = JsonConvert.DeserializeObject<MCBLSettings>(settingsJSON);
            }
            catch (Exception)
            {
                ModInit.Settings = new MCBLSettings();
            }
            var harmony = HarmonyInstance.Create(HarmonyPackage);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
    public class MCBLSettings
    {
        public string RepItemDefTypeAndID = "Item.HeatSinkDef.Gear_HeatSink_Generic_Standard";
        public string[] excludedFactions = { "ClanJadeFalcon", "ClanWolf", "ClanGhostBear" };
        public int RepModifier = 15;
        public int MaxRepLimit = 20;

    }

}

