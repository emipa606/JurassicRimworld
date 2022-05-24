using UnityEngine;
using Verse;

namespace DinosaurSettings;

public class DinosaurSettings : Mod
{
    public DinoSettings settings;

    public DinosaurSettings(ModContentPack content) : base(content)
    {
        GetSettings<DinoSettings>();
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