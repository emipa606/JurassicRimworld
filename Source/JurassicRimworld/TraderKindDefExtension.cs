using System.Collections.Generic;
using Verse;

namespace JurassicRimworld
{
    // Token: 0x02000005 RID: 5
    public class TraderKindDefExtension : DefModExtension
    {
        // Token: 0x04000001 RID: 1
        public bool AddToAllFactions = false;

        // Token: 0x04000002 RID: 2
        public List<string> CarrierTradeTags = new List<string>();

        // Token: 0x04000003 RID: 3
        public bool logging = false;
    }
}