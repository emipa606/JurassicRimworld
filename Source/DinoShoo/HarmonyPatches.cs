using HarmonyLib;
using RimWorld;
using Verse;

namespace DinoShoo;

[StaticConstructorOnStartup]
public class HarmonyPatches
{
    static HarmonyPatches()
    {
        var harmony = new Harmony("mehni.RimWorld.forSerpy.bigdinosleave");
        harmony.Patch(AccessTools.Method(typeof(ThinkNode_ConditionalExitTimedOut), "Satisfied"), null,
            new HarmonyMethod(typeof(HarmonyPatches), "DinoShoo_PostFix"));
    }

    private static void DinoShoo_PostFix(ref Pawn pawn)
    {
        if (pawn.mindState.exitMapAfterTick == -99999 && pawn.RaceProps.baseBodySize >= 5f &&
            pawn.Faction == null)
        {
            pawn.mindState.exitMapAfterTick = Find.TickManager.TicksGame + Rand.RangeInclusive(90000, 150000);
        }
    }
}