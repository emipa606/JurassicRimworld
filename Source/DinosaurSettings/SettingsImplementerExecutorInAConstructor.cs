using System.Collections.Generic;
using System.Linq;
using Verse;

namespace DinosaurSettings
{
    // Token: 0x02000004 RID: 4
    [StaticConstructorOnStartup]
    internal static class SettingsImplementerExecutorInAConstructor
    {
        // Token: 0x06000008 RID: 8 RVA: 0x00002188 File Offset: 0x00000388
        static SettingsImplementerExecutorInAConstructor()
        {
            if (!DinoSettings.dinosCanSpawnWild)
            {
                var list = DefDatabase<PawnKindDef>.AllDefsListForReading.FindAll(delegate(PawnKindDef x)
                {
                    var wildBiomes = x.RaceProps.wildBiomes;
                    return wildBiomes?.First() != null &&
                           x.RaceProps.wildBiomes.First().commonality != 0f && x.race.description.StartsWith("-- >");
                });
                foreach (var pawnKindDef in list)
                {
                    foreach (var animalBiomeRecord in pawnKindDef.RaceProps.wildBiomes)
                    {
                        animalBiomeRecord.commonality = 0f;
                    }
                }
            }

            if (DinoSettings.dinosCanBeReconstructed)
            {
                return;
            }

            ResearchProjectDef[] dinoResearchDefs =
            {
                DefDatabase<ResearchProjectDef>.GetNamed("DNAReconstruction"),
                DefDatabase<ResearchProjectDef>.GetNamed("AmberExtraction")
            };
            var enumerable = DefDatabase<ThingDef>.AllDefsListForReading.Where(delegate(ThingDef x)
            {
                IEnumerable<ResearchProjectDef> dinoResearchDefs2 = dinoResearchDefs;
                var researchPrerequisites = x.researchPrerequisites;
                return dinoResearchDefs2.Contains(researchPrerequisites?.First());
            });
            foreach (var thingDef in enumerable)
            {
                thingDef.designationCategory = null;
            }

            foreach (var item in dinoResearchDefs)
            {
                DefDatabase<ResearchProjectDef>.AllDefsListForReading.Remove(item);
            }
        }
    }
}