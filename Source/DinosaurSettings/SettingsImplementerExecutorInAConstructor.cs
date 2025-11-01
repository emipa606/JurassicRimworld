using System.Linq;
using Verse;

namespace DinosaurSettings;

[StaticConstructorOnStartup]
internal static class SettingsImplementerExecutorInAConstructor
{
    static SettingsImplementerExecutorInAConstructor()
    {
        // Ensure the ModContentPack reference is initialized (static constructors may run before Mod ctor)
        DinosaurSettings.ThisContentPack ??= LoadedModManager.GetMod<DinosaurSettings>()?.Content;

        // Apply wild spawn disabling only if setting off and we have a content pack reference
        if (!DinoSettings.dinosCanSpawnWild && DinosaurSettings.ThisContentPack != null)
        {
            var dinoList = DefDatabase<PawnKindDef>.AllDefsListForReading.Where(def =>
                def.modContentPack == DinosaurSettings.ThisContentPack);
            foreach (var pawnKindDef in dinoList)
            {
                var wildBiomes = pawnKindDef.RaceProps?.wildBiomes; // Guard against null RaceProps or wildBiomes
                if (wildBiomes == null)
                {
                    continue;
                }

                foreach (var animalBiomeRecord in wildBiomes)
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
        [
            DefDatabase<ResearchProjectDef>.GetNamed("DNAReconstruction"),
            DefDatabase<ResearchProjectDef>.GetNamed("AmberExtraction")
        ];
        var enumerable = DefDatabase<ThingDef>.AllDefsListForReading.Where(x =>
        {
            var researchPrereqs = x.researchPrerequisites;
            if (researchPrereqs == null || researchPrereqs.Count == 0)
            {
                return false;
            }

            return dinoResearchDefs.Contains(researchPrereqs[0]);
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