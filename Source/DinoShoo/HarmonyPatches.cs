using HarmonyLib;
using RimWorld;
using Verse;

namespace DinoShoo
{
    // Token: 0x02000002 RID: 2
    [StaticConstructorOnStartup]
    public class HarmonyPatches
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        static HarmonyPatches()
        {
            var harmony = new Harmony("mehni.RimWorld.forSerpy.bigdinosleave");
            harmony.Patch(AccessTools.Method(typeof(ThinkNode_ConditionalExitTimedOut), "Satisfied"), null,
                new HarmonyMethod(typeof(HarmonyPatches), "DinoShoo_PostFix"));
        }

        // Token: 0x06000002 RID: 2 RVA: 0x000020A0 File Offset: 0x000002A0
        private static void DinoShoo_PostFix(ref Pawn pawn)
        {
            if (pawn.mindState.exitMapAfterTick == -99999 && pawn.RaceProps.baseBodySize >= 5f &&
                pawn.Faction == null)
            {
                pawn.mindState.exitMapAfterTick = Find.TickManager.TicksGame + Rand.RangeInclusive(90000, 150000);
            }
        }
    }
}