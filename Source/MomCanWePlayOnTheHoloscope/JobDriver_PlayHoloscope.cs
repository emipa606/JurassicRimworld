using RimWorld;
using Verse;
using Verse.AI;

namespace MomCanWePlayOnTheHoloscope
{
    // Token: 0x02000002 RID: 2
    public class JobDriver_PlayHoloscope : JobDriver_SitFacingBuilding
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        protected override void ModifyPlayToil(Toil toil)
        {
            base.ModifyPlayToil(toil);
            toil.WithEffect(() => DefDatabase<EffecterDef>.GetNamed("PlayHoloscope"),
                () => TargetA.Thing.OccupiedRect().ClosestCellTo(pawn.Position));
        }
    }
}