using RimWorld;
using Verse;
using Verse.AI;

namespace MomCanWePlayOnTheHoloscope;

public class JobDriver_PlayHoloscope : JobDriver_SitFacingBuilding
{
    protected override void ModifyPlayToil(Toil toil)
    {
        base.ModifyPlayToil(toil);
        toil.WithEffect(() => DefDatabase<EffecterDef>.GetNamed("PlayHoloscope"),
            () => TargetA.Thing.OccupiedRect().ClosestCellTo(pawn.Position));
    }
}