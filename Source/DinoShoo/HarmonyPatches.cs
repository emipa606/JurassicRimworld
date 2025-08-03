using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace DinoShoo;

[StaticConstructorOnStartup]
public class HarmonyPatches
{
    static HarmonyPatches()
    {
        new Harmony("mehni.RimWorld.forSerpy.bigdinosleave").PatchAll(Assembly.GetExecutingAssembly());
    }
}

[HarmonyPatch(typeof(ThinkNode_ConditionalExitTimedOut), "Satisfied")]
public static class ThinkNode_ConditionalExitTimedOut_Satisfied
{
    public static void Postfix(ref Pawn pawn)
    {
        if (pawn.mindState.exitMapAfterTick == -99999 && pawn.RaceProps.baseBodySize >= 5f &&
            pawn.Faction == null)
        {
            pawn.mindState.exitMapAfterTick = Find.TickManager.TicksGame + Rand.RangeInclusive(90000, 150000);
        }
    }
}