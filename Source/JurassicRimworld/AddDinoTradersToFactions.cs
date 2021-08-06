using RimWorld;
using Verse;

namespace JurassicRimworld
{
    // Token: 0x02000002 RID: 2
    [StaticConstructorOnStartup]
    public class AddDinoTradersToFactions
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        static AddDinoTradersToFactions()
        {
            DefDatabase<FactionDef>.AllDefsListForReading.ForEach(delegate(FactionDef fd)
            {
                if (fd.humanlikeFaction && !fd.permanentEnemy)
                {
                    DefDatabase<TraderKindDef>.AllDefsListForReading.ForEach(delegate(TraderKindDef tkd)
                    {
                        if (!tkd.HasModExtension<TraderKindDefExtension>())
                        {
                            return;
                        }

                        var modExtension = tkd.GetModExtension<TraderKindDefExtension>();
                        var addToAllFactions = modExtension.AddToAllFactions;
                        if (addToAllFactions)
                        {
                            fd.caravanTraderKinds.Add(tkd);
                        }
                    });
                }
            });
        }
    }
}