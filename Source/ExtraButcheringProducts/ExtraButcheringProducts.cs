using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace ExtraButcheringProducts;

[StaticConstructorOnStartup]
internal static class ExtraButcheringProducts
{
    static ExtraButcheringProducts()
    {
        new Harmony("mehni.rimworld.framework.extrabutchering").PatchAll(Assembly.GetExecutingAssembly());
    }
}

[HarmonyPatch(typeof(Thing), nameof(Thing.ButcherProducts))]
public static class Thing_ButcherProducts
{
    public static void Postfix(Thing __instance, ref IEnumerable<Thing> __result,
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