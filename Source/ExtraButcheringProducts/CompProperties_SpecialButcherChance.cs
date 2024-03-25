using System.Collections.Generic;
using Verse;

namespace ExtraButcheringProducts;

public class CompProperties_SpecialButcherChance : CompProperties
{
    public readonly List<ThingDefCountWithChanceClass> butcherProducts = [];

    public CompProperties_SpecialButcherChance()
    {
        compClass = typeof(CompSpecialButcherChance);
    }

    public override IEnumerable<string> ConfigErrors(ThingDef parentDef)
    {
        foreach (var item in base.ConfigErrors(parentDef))
        {
            yield return item;
        }

        if (butcherProducts.NullOrEmpty())
        {
        }
    }
}