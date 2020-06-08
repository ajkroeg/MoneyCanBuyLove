using Harmony;
using BattleTech;
using System.Linq;

namespace MoneyCanBuyLove
{
    static class MoneyCanBuyLove
    {
        [HarmonyPatch(typeof(BattleTech.SimGameState), "OnDayPassed")]
        public static class OnDayPassed_Patch
        {
            public static void Postfix(SimGameState __instance, int timeLapse)
            {

                int countRep = __instance.CompanyStats.GetValue<int>(ModInit.Settings.RepItemDefTypeAndID);
                string Owner = __instance.CurSystem.Def.OwnerValue.FriendlyName;

                bool exclude = ModInit.Settings.excludedFactions.Any((string XFact) => __instance.CurSystem.Def.OwnerValue.FriendlyName.Contains(XFact));
                if (exclude == true)
                {
                    __instance.CompanyStats.Set<int>(ModInit.Settings.RepItemDefTypeAndID, 0);
                    return;
                }
                int getRep = __instance.CompanyStats.GetValue<int>("Reputation." + Owner);
                int modRep = (countRep * ModInit.Settings.RepModifier) + getRep;
                if(modRep > ModInit.Settings.MaxRepLimit)
                {
                    __instance.CompanyStats.Set<int>("Reputation." + Owner, ModInit.Settings.MaxRepLimit);
                    __instance.CompanyStats.Set<int>(ModInit.Settings.RepItemDefTypeAndID, 0);
                }
                else
                __instance.CompanyStats.Set<int>("Reputation." + Owner, modRep);
                __instance.CompanyStats.Set<int>(ModInit.Settings.RepItemDefTypeAndID, 0);
            }
        }
    }
}
