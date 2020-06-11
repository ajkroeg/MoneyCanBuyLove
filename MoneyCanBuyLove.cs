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
                int countSPFRep = __instance.CompanyStats.GetValue<int>(ModInit.Settings.SpecFactionRepItemDefTypeAndID);

                string Owner = __instance.CurSystem.Def.OwnerValue.FriendlyName;

                int getSPFRep = __instance.CompanyStats.GetValue<int>("Reputation." + ModInit.Settings.SpecFactionID);
                int modSPFRep = (countRep * ModInit.Settings.SpecFactionRepModifier) + getSPFRep;
                if (modSPFRep > ModInit.Settings.SpecFactionMaxRepLimit)
                {
                    __instance.CompanyStats.Set<int>("Reputation." + ModInit.Settings.SpecFactionID, ModInit.Settings.SpecFactionMaxRepLimit);
                    __instance.CompanyStats.Set<int>(ModInit.Settings.SpecFactionRepItemDefTypeAndID, 0);
                }
                else
                    __instance.CompanyStats.Set<int>("Reputation." + ModInit.Settings.SpecFactionID, modSPFRep);
                __instance.CompanyStats.Set<int>(ModInit.Settings.SpecFactionRepItemDefTypeAndID, 0);



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
