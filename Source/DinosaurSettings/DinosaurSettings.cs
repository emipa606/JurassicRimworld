using Mlie;
using UnityEngine;
using Verse;

namespace DinosaurSettings;

public class DinosaurSettings : Mod
{
    public static string currentVersion;
    public static ModContentPack ThisContentPack;
    private readonly DinoSettings settings;

    public DinosaurSettings(ModContentPack content) : base(content)
    {
        settings = GetSettings<DinoSettings>();
        ThisContentPack = content;
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public override string SettingsCategory()
    {
        return "Jurassic RimWorld";
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        settings.DoWindowContents(inRect);
    }
}