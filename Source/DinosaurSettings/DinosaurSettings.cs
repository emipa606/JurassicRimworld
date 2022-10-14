using Mlie;
using UnityEngine;
using Verse;

namespace DinosaurSettings;

public class DinosaurSettings : Mod
{
    public static string currentVersion;
    public DinoSettings settings;

    public DinosaurSettings(ModContentPack content) : base(content)
    {
        settings = GetSettings<DinoSettings>();
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(
                ModLister.GetActiveModWithIdentifier("Mlie.JurassicRimworld"));
    }

    public override string SettingsCategory()
    {
        return "Jurassic RimWorld";
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        GetSettings<DinoSettings>().DoWindowContents(inRect);
    }
}