using System.Collections.Generic;
using Verse;

namespace ExtraButcheringProducts
{
    // Token: 0x02000003 RID: 3
    public class CompProperties_SpecialButcherChance : CompProperties
    {
        // Token: 0x04000001 RID: 1
        public List<ThingDefCountWithChanceClass> butcherProducts = new List<ThingDefCountWithChanceClass>();

        // Token: 0x06000003 RID: 3 RVA: 0x000021A0 File Offset: 0x000003A0
        public CompProperties_SpecialButcherChance()
        {
            compClass = typeof(CompSpecialButcherChance);
        }

        // Token: 0x06000004 RID: 4 RVA: 0x000021C5 File Offset: 0x000003C5
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
}