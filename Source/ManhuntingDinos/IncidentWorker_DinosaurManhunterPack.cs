using RimWorld;
using Verse;

namespace ManhuntingDinos
{
    // Token: 0x02000002 RID: 2
    public class IncidentWorker_DinosaurManhunterPack : IncidentWorker
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            var map = (Map) parms.target;
            bool result;
            if (!DinosaurManhunterPackIncidentUtility.TryFindManhunterAnimalKind(parms.points, map.Tile,
                out var pawnKindDef))
            {
                result = false;
            }
            else
            {
                if (!RCellFinder.TryFindRandomPawnEntryCell(out var intVec, map, CellFinder.EdgeRoadChance_Animal))
                {
                    result = false;
                }
                else
                {
                    var list = DinosaurManhunterPackIncidentUtility.GenerateAnimals(pawnKindDef, map.Tile,
                        parms.points * 1.4f);
                    var rot = Rot4.FromAngleFlat((map.Center - intVec).AngleFlat);
                    foreach (var pawn in list)
                    {
                        var intVec2 = CellFinder.RandomClosewalkCellNear(intVec, map, 10);
                        GenSpawn.Spawn(pawn, intVec2, map, rot);
                        pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent);
                        pawn.mindState.exitMapAfterTick = Find.TickManager.TicksGame + Rand.Range(60000, 135000);
                    }

                    Find.LetterStack.ReceiveLetter("LetterLabelManhunterPackArrived".Translate(),
                        "ManhunterPackArrived".Translate(pawnKindDef.GetLabelPlural()), LetterDefOf.ThreatBig, list[0]);
                    Find.TickManager.slower.SignalForceNormalSpeedShort();
                    LessonAutoActivator.TeachOpportunity(ConceptDefOf.ForbiddingDoors, OpportunityType.Critical);
                    LessonAutoActivator.TeachOpportunity(ConceptDefOf.AllowedAreas, OpportunityType.Important);
                    result = true;
                }
            }

            return result;
        }
    }
}