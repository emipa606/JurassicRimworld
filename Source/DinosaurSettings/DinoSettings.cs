using UnityEngine;
using Verse;

namespace DinosaurSettings;

public class DinoSettings : ModSettings
{
    public static bool dinosCanSpawnWild = true;

    public static bool dinosCanBeReconstructed = true;

    public void DoWindowContents(Rect inRect)
    {
        var listing_Standard = new Listing_Standard();
        var color = GUI.color;
        listing_Standard.Begin(inRect);
        Text.Font = GameFont.Medium;
        Text.Anchor = TextAnchor.MiddleCenter;
        GUI.color = Color.yellow;
        listing_Standard.Label("JDP_ChangedSettings".Translate());
        GUI.color = color;
        Text.Font = GameFont.Small;
        Text.Anchor = TextAnchor.UpperLeft;
        listing_Standard.Label("JDP_Settings".Translate());
        listing_Standard.Gap();
        listing_Standard.CheckboxLabeled("JDP_Life".Translate(),
            ref dinosCanSpawnWild,
            "JDP_LifeInfo".Translate());
        listing_Standard.Gap();
        listing_Standard.CheckboxLabeled("JDP_Raptors".Translate(), ref dinosCanBeReconstructed,
            "JDP_RaptorsInfo".Translate());
        if (DinosaurSettings.currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("JDP_CurrentModVersion".Translate(DinosaurSettings.currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
        Mod.GetSettings<DinoSettings>().Write();
    }

    public override void ExposeData()
    {
        Scribe_Values.Look(ref dinosCanSpawnWild, "dinosCanSpawnWild", true);
        Scribe_Values.Look(ref dinosCanBeReconstructed, "dinosCanBeReconstructed", true);
    }
}