using UnityEngine;
using Verse;

namespace DinosaurSettings
{
    // Token: 0x02000003 RID: 3
    public class DinosaurSettings : Mod
    {
        // Token: 0x04000003 RID: 3
        public DinoSettings settings;

        // Token: 0x06000005 RID: 5 RVA: 0x0000215E File Offset: 0x0000035E
        public DinosaurSettings(ModContentPack content) : base(content)
        {
            GetSettings<DinoSettings>();
        }

        // Token: 0x06000006 RID: 6 RVA: 0x00002170 File Offset: 0x00000370
        public override string SettingsCategory()
        {
            return "Jurassic RimWorld";
        }

        // Token: 0x06000007 RID: 7 RVA: 0x00002177 File Offset: 0x00000377
        public override void DoSettingsWindowContents(Rect inRect)
        {
            GetSettings<DinoSettings>().DoWindowContents(inRect);
        }
    }
}