using UnityEngine;
using Verse;

namespace DinosaurSettings
{
    // Token: 0x02000002 RID: 2
    public class DinoSettings : ModSettings
    {
        // Token: 0x04000001 RID: 1
        public static bool dinosCanSpawnWild = true;

        // Token: 0x04000002 RID: 2
        public static bool dinosCanBeReconstructed = true;

        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        public void DoWindowContents(Rect inRect)
        {
            var listing_Standard = new Listing_Standard();
            var color = GUI.color;
            listing_Standard.Begin(inRect);
            Text.Font = GameFont.Medium;
            Text.Anchor = TextAnchor.MiddleCenter;
            GUI.color = Color.yellow;
            listing_Standard.Label("CHANGED SETTINGS NEED A GAME RESTART TO TAKE EFFECT. BLAME MEHNI.");
            GUI.color = color;
            Text.Font = GameFont.Small;
            Text.Anchor = TextAnchor.UpperLeft;
            listing_Standard.Label("Settings");
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("Life cannot be contained. Life breaks free. Life finds a way",
                ref dinosCanSpawnWild,
                "If disabled, no dinosaurs will come wandering on the map. You'll only be able to get dinos through reconstruction.");
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("You bred raptors?", ref dinosCanBeReconstructed,
                "Your scientists were so preoccupied with whether or not they could, they didn’t stop to think if they should. \n\n Note: if disabled, no dino reconstruction.");
            listing_Standard.End();
            Mod.GetSettings<DinoSettings>().Write();
        }

        // Token: 0x06000002 RID: 2 RVA: 0x00002120 File Offset: 0x00000320
        public override void ExposeData()
        {
            Scribe_Values.Look(ref dinosCanSpawnWild, "dinosCanSpawnWild", true);
            Scribe_Values.Look(ref dinosCanBeReconstructed, "dinosCanBeReconstructed", true);
        }
    }
}