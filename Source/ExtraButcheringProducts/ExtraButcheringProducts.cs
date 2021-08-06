using System.Collections.Generic;
using HarmonyLib;
using Verse;

namespace ExtraButcheringProducts
{
    // Token: 0x02000002 RID: 2
    [StaticConstructorOnStartup]
    internal static class ExtraButcheringProducts
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        static ExtraButcheringProducts()
        {
            var harmony = new Harmony("mehni.rimworld.framework.extrabutchering");
            harmony.Patch(AccessTools.Method(typeof(Thing), "ButcherProducts"), null,
                new HarmonyMethod(typeof(ExtraButcheringProducts), "MakeButcherProducts_PostFix"));
        }

        // Token: 0x06000002 RID: 2 RVA: 0x000020A0 File Offset: 0x000002A0
        private static void MakeButcherProducts_PostFix(Thing __instance, ref IEnumerable<Thing> __result,
            float efficiency)
        {
            CompSpecialButcherChance compSpecialButcherChance;
            if ((compSpecialButcherChance = __instance.TryGetComp<CompSpecialButcherChance>()) == null)
            {
                return;
            }

            if (compSpecialButcherChance.Props.butcherProducts.NullOrEmpty())
            {
                return;
            }

            foreach (var thingDefCountWithChanceClass in compSpecialButcherChance.Props.butcherProducts)
            {
                if (!Rand.Chance(thingDefCountWithChanceClass.chance))
                {
                    continue;
                }

                var thingDefCountWithChanceClass2 = new ThingDefCountWithChanceClass
                {
                    thingDef = thingDefCountWithChanceClass.thingDef,
                    count = thingDefCountWithChanceClass.count
                };
                var num = GenMath.RoundRandom(thingDefCountWithChanceClass2.count * efficiency);
                if (num <= 0)
                {
                    continue;
                }

                var thing = ThingMaker.MakeThing(thingDefCountWithChanceClass2.thingDef);
                thing.stackCount = num;
                __result = __result.AddItem(thing);
            }
        }
    }
}