using RimWorld;
using Verse;

namespace JurassicRimworld;

[StaticConstructorOnStartup]
public class AddDinoTradersToFactions
{
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